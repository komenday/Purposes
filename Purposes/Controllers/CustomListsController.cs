using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Purposes.Models;

namespace Purposes.Controllers
{
    public class CustomListsController : Controller
    {
        PurposeContext db;
        public CustomListsController(PurposeContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                CustomList selected = await db.CustomLists.FirstOrDefaultAsync(p => p.Id == id);
                if (selected != null)
                {
                    return View(selected);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCustomList()
        {
            ViewBag.AllPurposes = new MultiSelectList(await db.Purposes.ToListAsync(), "Id", "Name", "Select purposes");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomList(CustomList customList)
        {
            db.CustomLists.Add(customList);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddPurposeToList(int? id)
        {
            if (id != null)
            {
                ViewBag.purposeId = id;
                ViewBag.Lists = new SelectList(db.CustomLists, "Id", "Name");
                return View(await db.CustomLists.ToListAsync());
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddPurposeToList(int? listId, int? purposeId)
        {
            CustomList selected = await db.CustomLists.FirstOrDefaultAsync(l => l.Id == listId);
            selected.SelectedPurposes.Add(await db.Purposes.FirstOrDefaultAsync(p => p.Id == purposeId));
            await db.SaveChangesAsync();
            return RedirectToActionPermanent("Index", "Home");
        }

        [HttpGet]
        [ActionName("RemovePurposeFromList")]
        public async Task<IActionResult> ConfirmRemovePurposeFromList(int? listId, int? purposeId)
        {
            if (listId != null && purposeId != null)
            {
                CustomList customList = await db.CustomLists.FirstOrDefaultAsync(p => p.Id == listId);
                Purpose purpose = customList.SelectedPurposes.FirstOrDefault(p => p.Id == purposeId);
                if (purpose != null)
                {
                    return View(purpose);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RemovePurposeFromList(int? listId, int? purposeId)
        {
            if (listId != null && purposeId != null)
            {
                CustomList customList = await db.CustomLists.FirstOrDefaultAsync(p => p.Id == listId);
                Purpose purpose = customList.SelectedPurposes.FirstOrDefault(p => p.Id == purposeId);
                if (purpose != null)
                {
                    customList.SelectedPurposes.Remove(purpose);
                    await db.SaveChangesAsync();
                    return RedirectToActionPermanent("Index", listId);
                }
            }
            return NotFound();
        }
    }
}