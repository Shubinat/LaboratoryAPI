using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LaboratoryAPI.Models
{
    /// <summary>
    /// Entity what uses for edit user data.
    /// </summary>
    public class UserEditData
    {
        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Has password.
        /// </summary>
        internal bool HasPassword => !string.IsNullOrWhiteSpace(Password);
        /// <summary>
        /// Has email.
        /// </summary>
        internal bool HasEmail => !string.IsNullOrWhiteSpace(Email);
        /// <summary>
        /// Has phone number.
        /// </summary>
        internal bool HasPhoneNumber => !string.IsNullOrWhiteSpace(PhoneNumber);
    }
}