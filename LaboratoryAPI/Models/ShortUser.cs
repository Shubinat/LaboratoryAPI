using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryAPI.Models
{
    /// <summary>
    /// Entity uses for user's authorization.
    /// </summary>
    public class ShortUser
    {
        /// <summary>
        /// User login.
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// User password.
        /// </summary>
        public string Password { get; set; }
    }
}