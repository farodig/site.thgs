using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thgs.database;

namespace thgs.site.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ThgsDbContext _context;

        public ProfileController(ThgsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
