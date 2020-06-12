using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Purposes.Models;

namespace Purposes.Controllersvb
{
    public class SmartListsController : Controller
    {
        PurposeContext db;
        public SmartListsController(PurposeContext context)
        {
            db = context;
        }

        public async Task<IActionResult> AllPurposes()
        {
            ViewBag.Type = "All purposes";
            return View("~/Views/SmartLists/Index.cshtml", await db.Purposes.ToListAsync());
        }

        public async Task<IActionResult> TodaysPurposes()
        {
            ViewBag.Type = "Today's purposes";
            return View("~/Views/SmartLists/Index.cshtml", await db.Purposes.Where(p => p.Due == DateTime.Now.Date).ToListAsync());
        }

        public async Task<IActionResult> ImportantPurposes()
        {
            ViewBag.Type = "Important purposes";
            return View("~/Views/SmartLists/Index.cshtml", await db.Purposes.Where(p => p.Importance == Importance.Important).ToListAsync());
        }

        public async Task<IActionResult> PlannedPurposes()
        {
            ViewBag.Type = "Planned purposes";
            return View("~/Views/SmartLists/Index.cshtml", await db.Purposes.Where(p => p.Due >= DateTime.Now.Date && !p.IsCompleted).ToListAsync());
        }
    }
}