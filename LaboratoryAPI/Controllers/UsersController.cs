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
        /// Authorization.
        /// </summary>
        /// <param name="shortUser">Object with Login and Password properties.</param>
        /// <returns>After successful authorization - the User with the given login and password.
        /// In case of unsuccessful authorization - NotFound.</returns>
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
        /// Registration.
        /// </summary>
        /// <param name="user">User to register.</param>
        /// <returns>Ok - On successful registration.
        /// BadRequest - On registration failure.</returns>
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
        /// Edits information about the user (Phone number, Email, Password).
        /// </summary>
        /// <param name="userID">User ID.</param>
        /// <param name="user">User with modified information.</param>
        /// <returns>User with edited information. Otherwise NotFound.</returns>
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