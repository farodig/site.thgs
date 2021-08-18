using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thgs.database.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Информация о пользователе
        /// </summary>
        public UserInfo UserInfo { get; set; }

        /// <summary>
        /// Сессия
        /// </summary>
        public string Session { get; set; }

        /// <summary>
        /// Авторизация по логину/паролю
        /// </summary>
        public string LoginPasswordAuth { get; set; }

        /// <summary>
        /// Авторизация через вконтакте
        /// </summary>
        public string VKAuth { get; set; }

        /// <summary>
        /// Авторизация через google
        /// </summary>
        public string GoogleAuth { get; set; }

        /// <summary>
        /// Авторизация через mail
        /// </summary>
        public string MailAuth { get; set; }

        /// <summary>
        /// Игроки пользователя (аккаунты)
        /// </summary>
        public List<Player> Players { get; set; }
    }
}
