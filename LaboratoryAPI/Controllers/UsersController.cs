using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LaboratoryAPI.Entities;
using LaboratoryAPI.Models;

namespace LaboratoryAPI.Controllers
{
    public class UsersController : ApiController
    {
        private LaboratoryDatabaseEntities db = new LaboratoryDatabaseEntities();

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        /// <param name="shortUser">Объект имеющий свойства Login и Password.</param>
        /// <returns>При успешной авторизации - Пользователя с данным логином и паролем.
        /// При неуспешной авторизации  - NotFound.</returns>
        [Route("api/Users/Autorization")]
        public IHttpActionResult Authorization(ShortUser shortUser)
        {
            if(db.Users.ToList().FirstOrDefault(u => u.Login == shortUser.Login && u.Password == shortUser.Password) is User authUser)
            {
                return Ok(new UserModel(authUser));
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// <param name="user">Пользователь, которого нужно зарегистрировать.</param>
        /// <returns>Ok - При успешной регистрации.
        /// BadRequest - При ошибке регистрации.</returns>
        [Route("api/Users/Registration")]
        public IHttpActionResult Registration(User user)
        {
            try
            {
                var regUser = db.Users.ToList().FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password);
                if(regUser == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Редактирует информацию о пользователе (Номер телефона, Email, Пароль).
        /// </summary>
        /// <param name="userID">ID пользователя.</param>
        /// <param name="user">Пользователь с изменненой информацией.</param>
        /// <returns>Пользователя с редактированной информацией. В ином случае NotFound.</returns>
        [Route("api/Users/EditProfile")]
        public IHttpActionResult PutUser(int userID, UserEditData user)
        {
            try
            {
                var dbUser = db.Users.Find(userID);
                if (user.HasPhoneNumber)
                    dbUser.PhoneNumber = user.PhoneNumber;
                if(user.HasEmail)
                    dbUser.Email = user.Email;
                if(user.HasPassword)
                    dbUser.Password = user.Password;
                db.SaveChanges();
                return Ok(new UserModel(dbUser));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        /// <summary>
        /// Получение списка сервисов у пользователя.
        /// </summary>
        /// <param name="userID">ID пользователя.</param>
        /// <returns>При успешном запросе - список услуг у пользвателя.
        /// При неуспешном запросе - NotFound.</returns>
        [Route("api/Users/Services")]
        public IHttpActionResult GetServices(int userID)
        {
            try
            {
                var user = db.Users.Find(userID);
                return Ok(user.Services.ToList().ConvertAll(s => new ServiceModel(s)));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Добавление нового сервиcа в список пользователя.
        /// </summary>
        /// <param name="userID">ID пользователя.</param>
        /// <param name="serviceID">ID сервиса.</param>
        /// <returns>При успешном запросе - добавленную услугу.
        /// При неуспешном запросе - NotFound.</returns>
        [Route("api/Users/Services")]
        public IHttpActionResult AddService(int userID, int serviceID)
        {
            try
            {
                var user = db.Users.Find(userID);
                var service = db.Services.Find(serviceID);
                user.Services.Add(service);
                db.SaveChanges();
                return Ok(service);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Удаление сервиcа из списка пользователя.
        /// </summary>
        /// <param name="userID">ID пользователя.</param>
        /// <param name="serviceID">ID сервиса.</param>
        /// <returns>При успешном запросе - удаленную услугу.
        /// При неуспешном запросе - NotFound.</returns>
        [Route("api/Users/Services")]
        public IHttpActionResult DeleteService(int userID, int serviceID)
        {
            try
            {
                var user = db.Users.Find(userID);
                var service = db.Services.Find(serviceID);
                user.Services.Remove(service);
                db.SaveChanges();
                return Ok(service);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}