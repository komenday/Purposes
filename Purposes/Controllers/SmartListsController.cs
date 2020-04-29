using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Purposes.Controllers
{
    public class SmartListsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}