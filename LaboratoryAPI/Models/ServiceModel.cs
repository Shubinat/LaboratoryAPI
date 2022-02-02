using LaboratoryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryAPI.Models
{
    /// <summary>
    /// Entity representing the polyclinic service.
    /// </summary>
    public class ServiceModel
    {
        /// <summary>
        /// ID service.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Price.
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