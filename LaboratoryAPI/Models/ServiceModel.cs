using LaboratoryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryAPI.Models
{
    /// <summary>
    /// Сущность представляющяя сервис поликлиники.
    /// </summary>
    public class ServiceModel
    {
        /// <summary>
        /// ID сервиса.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Цена.
        /// </summary>
        public Nullable<decimal> Price { get; set; }

        public ServiceModel(Service service) 
        {
            ID = service.ID;
            Name = service.Name;
            Description = service.Description;
            Price = service.Price;
        }
    }
}