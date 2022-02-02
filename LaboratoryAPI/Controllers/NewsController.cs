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
        ///Getting a list of news 
        /// </summary>
        /// <returns>Collecton of news.</returns>
        public IHttpActionResult GetNews()
        {
            return Ok(db.News.ToList().ConvertAll(n => new NewsModel(n)).OrderByDescending(n => n.CreatingDate).ToList());
        }

        /// <summary>
        /// Getting a news.
        /// </summary>
        /// <param name="id">ID news.</param>
        /// <returns>
        ///If the request is successful, the news with the given ID.
        /// If the request fails - NotFound.</returns>
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