using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thgs.database.Models
{
    /// <summary>
    /// Игровая сессия
    /// </summary>
    public class GameSession
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на игрока
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// Время начала сессии
        /// </summary>
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// Время завершения сессии
        /// </summary>
        public DateTime? StopDateTime { get; set; }

        /// <summary>
        /// Результат игровой сессии
        /// </summary>
        public bool? GameResult { get; set; }
    }
}
