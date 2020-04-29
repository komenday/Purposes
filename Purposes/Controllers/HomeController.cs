using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Purposes.Models;

namespace Purposes.Controllers
{
    public class HomeController : Controller
    {
        PurposeContext db;
        public HomeController(PurposeContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index() => View(await db.Purposes.ToListAsync());

        [HttpGet]
        public IActionResult CreatePurpose()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurpose(Purpose purpose)
        {
            db.Purposes.Add(purpose);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditPurpose(int? id)
        {
            if (id != null)
            {
                Purpose purpose = await db.Purposes.FirstOrDefaultAsync(p => p.Id == id);
                if (purpose != null)
                    return View(purpose);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditPurpose(Purpose purpose)
        {
            db.Purposes.Update(purpose);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("DeletePurpose")]
        public async Task<IActionResult> ConfirmDeletePurpose(int? id)
        {
            if (id != null)
            {
                Purpose purpose = await db.Purposes.FirstOrDefaultAsync(p => p.Id == id);
                if (purpose != null)
                    return View(purpose);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePurpose(int? id)
        {
            if (id != null)
            {
                Purpose purpose = await db.Purposes.FirstOrDefaultAsync(p => p.Id == id);
                if (purpose != null)
                {
                    db.Purposes.Remove(purpose);
                    await db.SaveChangesAsync();
                    return RedirectToActionPermanent("Index");
                }
            }
            return NotFound();
        }
    }
}
