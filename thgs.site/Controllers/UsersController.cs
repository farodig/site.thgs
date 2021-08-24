using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thgs.database;
using thgs.database.Models;
using thgs.site.Models;

namespace thgs.site.Controllers
{
    public class UsersController : Controller
    {
        private readonly ThgsDbContext _context;

        public UsersController(ThgsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            // Количество элементов на странице
            int pageSize = 1000;

            // Всего записей
            var count = await _context.Players.CountAsync();

            // Запрос
            var players = await _context.Players
                .Include(a => a.User).ThenInclude(a => a.UserInfo)
                .Include(a => a.GameSessions)
                .OrderByDescending(a => a.GameSessions.Count)
                .Skip((page - 1) * pageSize).Take(pageSize)
                .ToListAsync();

            // Модель с пагинацией
            UsersViewModel viewModel = new UsersViewModel
            {
                PagePaginationModel = new PagePaginationModel(count, page, pageSize),
                Users = players.Select(a => new UserModel(a)).ToList()
            };

            return View(viewModel);
        }
    }
}
