using LaboratoryAPI.Entities;
using System;

namespace LaboratoryAPI.Models
{
    /// <summary>
    /// Entity representing the news of the polyclinic.
    /// </summary>
    public class NewsModel
    {
        /// <summary>
        /// ID news.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Creating date.
        /// </summary>
        public DateTime CreatingDate { get; set; }

        public NewsModel(News news)
        {
            ID = news.ID;
            Title = news.Title;
            Description = news.Description;
            CreatingDate = news.CreatingDate;
        }
    }
}