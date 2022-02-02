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
    public class ServicesController : ApiController
    {
        private LaboratoryDatabaseEntities db = new LaboratoryDatabaseEntities();

        /// <summary> 
        /// Getting a list of services 
        /// </summary>
        /// <returns>Collecton of services.</returns>
        public IHttpActionResult GetServices()
        {
            return Ok(db.Services.ToList().ConvertAll(s => new ServiceModel(s)));
        }

        /// <summary>
        /// Getting a service.
        /// </summary>
        /// <param name="id">ID service.</param>
        /// <returns>If the request is successful, the service with the given ID.
        /// On unsuccessful request - NotFound.</returns>
        [ResponseType(typeof(Service))]
        public IHttpActionResult GetService(int id)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
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