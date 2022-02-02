using LaboratoryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryAPI.Models
{
    /// <summary>
    /// User model.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// ID user.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Login.
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Surname.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Patronimyc.
        /// </summary>
        public string Patronimyc { get; set; }
        /// <summary>
        /// Date of Birth.
        /// </summary>
        public System.DateTime BirthDate { get; set; }
        /// <summary>
        /// Number of Policy.
        /// </summary>
        public string PolicyNumber { get; set; }
        /// <summary>
        /// Number of Passport.
        /// </summary>
        public string PassportNumber { get; set; }
        /// <summary>
        /// Seria of Passport.
        /// </summary>
        public string PassportSeria { get; set; }
        /// <summary>
        /// Number of Phone.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        public UserModel(User user)
        {
            ID = user.ID;
            Login = user.Login;
            Password = user.Password;
            Surname = user.Surname;
            Name = user.Name;
            Patronimyc = user.Patronimyc;
            BirthDate = user.BirthDate;
            PolicyNumber = user.PolicyNumber;
            PassportNumber = user.PassportNumber;
            PassportSeria = user.PassportSeria;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
        }
    }
}