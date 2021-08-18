using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thgs.database.Models
{
    /// <summary>
    /// Информация о пользователе
    /// </summary>
    [Owned]
    [Index(nameof(Name))]
    public class UserInfo
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пол пользователя
        /// </summary>
        public byte Sex { get; set; }

        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
