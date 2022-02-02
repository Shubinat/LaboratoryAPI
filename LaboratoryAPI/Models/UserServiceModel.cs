using LaboratoryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryAPI.Models
{
    /// <summary>
    /// Entity representing the user's service.
    /// </summary>
    public class UserServiceModel
    {
        /// <summary>
        /// ID.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Service ID.
        /// </summary>
        public int ServiceID { get; set; }
        /// <summary>
        /// User ID.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Date of receipt.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Polyclinic service.
        /// </summary>
        public ServiceModel Service { get; set; }

        public UserServiceModel(UserService userService)
        {
            ID = userService.ID;
            Service = new ServiceModel(userService.Service);
            Date = userService.Date;
            ServiceID = userService.ServiceID;
            UserID = userService.UserID;
        }
    }
}
