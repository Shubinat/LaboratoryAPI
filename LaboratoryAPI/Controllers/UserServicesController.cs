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
    public class UserServicesController : ApiController
    {
        private LaboratoryDatabaseEntities db = new LaboratoryDatabaseEntities();

        /// <summary> 
        /// Getting a list of user's services.
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <returns>Collecton of UserService.</returns>
        public IHttpActionResult GetUserServices(int userID)
        {
            try
            {
                var user = db.Users.Find(userID);
                return Ok(user.UserServices.ToList().ConvertAll(s => new UserServiceModel(s)).OrderByDescending(s => s.Date).ToList());

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary> 
        /// Getting an user's service.
        /// </summary>
        /// <param name="userServiceID">UserService ID</param>
        /// <returns>Collecton of UserService.</returns>
        public IHttpActionResult GetUserService(int userServiceID)
        {
            try
            {
                var userService = db.UserServices.Find(userServiceID);
                return Ok(new UserServiceModel(userService));

            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        /// <summary> 
        /// Add an user's service.
        /// </summary>
        /// <param name="userService">UserService</param>
        /// <returns>Added UserService.</returns>
        public IHttpActionResult AddUserService(UserService userService)
        {
            try
            {
                var uservice = db.UserServices.Add(userService);
                return Ok(new UserServiceModel(uservice));

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary> 
        /// Deleting an user's service.
        /// </summary>
        /// <param name="userServiceID">UserService ID</param>
        /// <returns>Deleted UserService.</returns>
        public IHttpActionResult DeleteUserService(int userServiceID)
        {
            try
            {
                var userService = db.UserServices.Find(userServiceID);
                db.UserServices.Remove(userService);
                return Ok(new UserServiceModel(userService));

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
