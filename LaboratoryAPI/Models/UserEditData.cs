using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LaboratoryAPI.Models
{
    /// <summary>
    /// Сущность используемая для редактирования пользователя.
    /// </summary>
    public class UserEditData
    {
        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Имеет-ли пароль.
        /// </summary>
        internal bool HasPassword => !string.IsNullOrWhiteSpace(Password);
        /// <summary>
        /// Имеет-ли Email.
        /// </summary>
        internal bool HasEmail => !string.IsNullOrWhiteSpace(Email);
        /// <summary>
        /// Имеет-ли номер телефона.
        /// </summary>
        internal bool HasPhoneNumber => !string.IsNullOrWhiteSpace(PhoneNumber);
    }
}