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
        /// Получение списка услуг.
        /// </summary>
        /// <returns>Коллекция услуг.</returns>
        public IHttpActionResult GetServices()
        {
            return Ok(db.Services.ToList().ConvertAll(s => new ServiceModel(s)));
        }

        /// <summary>
        /// Получение услуги.
        /// </summary>
        /// <param name="id">ID услуги.</param>
        /// <returns>При успешном запросе - услугу с данным ID.
        /// При неуспешном запросе - NotFound.</returns>
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