using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thgs.database.Models
{
    /// <summary>
    /// Игрок (аккаунт)
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [Required]
        public byte Sex { get; set; }

        /// <summary>
        /// Расса
        /// </summary>
        [Required]
        public byte Race { get; set; }

        /// <summary>
        /// Игровые сессии
        /// </summary>
        public List<GameSession> GameSessions { get; set; }
    }
}
