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
    public class NewsController : ApiController
    {
        private LaboratoryDatabaseEntities db = new LaboratoryDatabaseEntities();

        /// <summary>
        /// Получение списка новостей.
        /// </summary>
        /// <returns>Коллекция новостей.</returns>
        public IHttpActionResult GetNews()
        {
            return Ok(db.News.ToList().ConvertAll(n => new NewsModel(n)).OrderByDescending(n => n.CreatingDate).ToList());
        }

        /// <summary>
        /// Получение новости.
        /// </summary>
        /// <param name="id">ID новости.</param>
        /// <returns>При успешном запросе - новость с данным ID.
        /// При неуспешном запросе - NotFound.</returns>
        [ResponseType(typeof(News))]
        public IHttpActionResult GetNews(int id)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            return Ok(new NewsModel(news));
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