using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purpose.Models;

namespace Purpose.Controllers
{
    public class HomeController : Controller
    {
        private PurposeContext db;
        public HomeController(PurposeContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
