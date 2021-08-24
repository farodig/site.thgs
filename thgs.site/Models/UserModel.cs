using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thgs.database.Models;

namespace thgs.site.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="player"></param>
        public UserModel(Player player)
        {
            // Имя игрока
            Name = player.User.UserInfo.Name;

            // Пол
            Sex = player.Sex == 0 ? "Female" : "Male";

            // Расса
            Race = player.Race == 0 ? "Human" : "Alien";

            // Количество сыгранных игр
            GameCount = player.GameSessions.Count;

            // Количество побед к поражениям
            WinRate = player.GameSessions.Count(a => a.GameResult == true) + "/" + player.GameSessions.Count(a => a.GameResult == false);
        }

        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол
        /// </summary>
        public string Sex { get; }

        /// <summary>
        /// Расса
        /// </summary>
        public string Race { get; }

        /// <summary>
        /// Количество сыгранных игр
        /// </summary>
        public int GameCount { get; }

        /// <summary>
        /// Количество побед к поражениям
        /// </summary>
        public string WinRate { get; }
    }
}
