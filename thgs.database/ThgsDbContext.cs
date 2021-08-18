using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thgs.database.Models;
using Microsoft.EntityFrameworkCore;

namespace thgs.database
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class ThgsDbContext : DbContext
    {
        /// <summary>
        /// Конфигурация с параметрами контекста
        /// </summary>
        /// <param name="options"></param>
        public ThgsDbContext(DbContextOptions<ThgsDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();


            //User user1 = new User();
            //user1.UserInfo = new UserInfo { Name = "Maxim", Sex = 1, BirthDate = new DateTime(1988, 4, 10) };
            //User user2 = new User();
            //user2.UserInfo = new UserInfo { Name = "Alisa", Sex = 0, BirthDate = new DateTime(1992, 9, 24) };
            //User user3 = new User();

            //// Добавление
            //Users.Add(user1);
            //Users.Add(user2);
            //Users.Add(user3);
            //SaveChanges();
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Информация о пользователях
        /// </summary>
        public DbSet<UserInfo> UserInfo { get; set; }

        /// <summary>
        /// Игроки
        /// </summary>
        public DbSet<Player> Players { get; set; }

        /// <summary>
        /// Игровые сессии
        /// </summary>
        public DbSet<GameSession> GameSessions { get; set; }

    }
}
