using LaboratoryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryAPI.Models
{
    /// <summary>
    /// Сущность пользователя.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// ID пользователя.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronimyc { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public System.DateTime BirthDate { get; set; }
        /// <summary>
        /// Номер полиса.
        /// </summary>
        public string PolicyNumber { get; set; }
        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public string PassportNumber { get; set; }
        /// <summary>
        /// Серия паспорта.
        /// </summary>
        public string PassportSeria { get; set; }
        /// <summary>
        /// Номер телефона.
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