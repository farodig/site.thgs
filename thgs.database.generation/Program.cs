using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using thgs.database.Models;

namespace thgs.database.generation
{
    class Program
    {
        /// <summary>
        /// Количество генерируемых пользователей
        /// </summary>
        const int GENERATE_USER_COUNT = 10000;

        /// <summary>
        /// Список мужских имён для заполнения
        /// </summary>
        static readonly string[] MALE_NAMES = new string[] { "Maxim", "Vasya", "Kolya", "Petya", "Alexey", "Vladimir" };

        /// <summary>
        /// Список женских имён
        /// </summary>
        static readonly string[] FEMALE_NAMES = new string[] { "Alisa", "Anya", "Katya", "Veronika", "Kristina", "Masha", "Dasha" };

        /// <summary>
        /// Максимальная дата рождения пользоваталей
        /// </summary>
        static readonly DateTime BEGIN_AGE_DATE = new DateTime(1900, 1, 1);

        /// <summary>
        /// Минимальная дата рождения пользователей
        /// </summary>
        static readonly DateTime END_AGE_DATE = new DateTime(DateTime.Now.Year - 4, 1, 1);

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ThgsDbContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            var startGameDate = new DateTime(DateTime.Now.Year - 1, 1, 1);
            TimeSpan gameTimeSpan = DateTime.Now - startGameDate;

            var rnd = new Random();

            // Подключение к БД
            using (ThgsDbContext db = new ThgsDbContext(options))
            {
                // Генерация пользователей
                for (int i = 0; i < GENERATE_USER_COUNT; i++)
                {
                    // Пол
                    var sex = (byte)rnd.Next(0, 2);

                    // Имя
                    var name = (sex == 0) ?
                        FEMALE_NAMES[rnd.Next(0, FEMALE_NAMES.Length)]
                        : MALE_NAMES[rnd.Next(0, MALE_NAMES.Length)];

                    // Дата рождения
                    var birthDate = BEGIN_AGE_DATE + new TimeSpan(0, rnd.Next(0, (int)(END_AGE_DATE - BEGIN_AGE_DATE).TotalMinutes), 0);

                    // Новый пользователь
                    User user = new User();
                    user.UserInfo = new UserInfo { Name = name, Sex = sex, BirthDate = birthDate };

                    // Генерация игровых персонажей
                    user.Players = new List<Player>();
                    for (int p = 0; p < rnd.Next(0, 6); p++)
                    {
                        // Расса
                        var race = (byte)rnd.Next(0, 2);

                        // Пол персонажа
                        var psex = (byte)rnd.Next(0, 2);

                        // Новый персонаж
                        var player = new Player { Race = race, Sex = psex };

                        // Генерация игровых сессий
                        player.GameSessions = new List<GameSession>();
                        for (int s = 0; s < rnd.Next(0, 100); s++)
                        {
                            // Игра началась?
                            var IsSessionStarted = rnd.Next(0, 2) > 0 ? true : false;
                            var sessionStartDate = IsSessionStarted ? startGameDate + new TimeSpan(0, rnd.Next(0, (int)gameTimeSpan.TotalMinutes), 0) : default(DateTime?);

                            // Известен результат?
                            var rndSuccess = rnd.Next(-1, 2);
                            var Success = IsSessionStarted ? rndSuccess > 0 ? true : rndSuccess < 0 ? false : (bool?)null : (bool?)null;

                            // Дата окончания сессии
                            var sessionEndDate = Success != null ? sessionStartDate + new TimeSpan(0, rnd.Next(0, (int)(DateTime.Now - sessionStartDate.Value).TotalMinutes), 0) : default(DateTime?);
                            var session = new GameSession { Id = Guid.NewGuid(), StartDateTime = sessionStartDate, GameResult = Success, StopDateTime = sessionEndDate };

                            // Добавить игровую сессию
                            player.GameSessions.Add(session);
                        }

                        // Добавить игрового персонажа
                        user.Players.Add(player);
                    }

                    // Добавить пользователя
                    db.Users.Add(user);
                }

                // Сохранить изменения в базе данных
                db.SaveChanges();
            }
        }
    }
}
