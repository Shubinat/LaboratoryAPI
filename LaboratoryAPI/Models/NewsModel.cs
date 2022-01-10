using LaboratoryAPI.Entities;
using System;

namespace LaboratoryAPI.Models
{
    /// <summary>
    /// Сущность представляющяя новость поликлиники.
    /// </summary>
    public class NewsModel
    {
        /// <summary>
        /// ID новости.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дата публикации.
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