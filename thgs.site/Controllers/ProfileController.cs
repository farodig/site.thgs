using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thgs.database;

namespace thgs.site.Controllers
{
    //[Authorize]
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

        //public ActionResult Login()
        //{
        //    return View();
        //}

        //public ActionResult Logout()
        //{
        //    return View();
        //}
    }
}
