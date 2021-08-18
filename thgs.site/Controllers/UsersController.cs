using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thgs.database;

namespace thgs.site.Controllers
{
    public class UsersController : Controller
    {
        private readonly ThgsDbContext _context;

        public UsersController(ThgsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()// async Task<IActionResult> Index()
        {
            return View(null);// await _context.Users.ToListAsync());
        }
    }
}
