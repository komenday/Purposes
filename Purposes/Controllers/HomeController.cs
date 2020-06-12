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
using Purposes.ViewModels;

namespace Purposes.Controllers
{
    public class HomeController : Controller
    {
        PurposeContext db;
        public HomeController(PurposeContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(string name, int page = 1, SortState sortOrder = SortState.CreationDesc)
        {
            int pageSize = 3;

            IQueryable<Purpose> purposes = db.Purposes;
            if (!string.IsNullOrEmpty(name))
            {
                purposes = purposes.Where(p => p.Name.Contains(name));
            }

            switch (sortOrder)
            {
                case SortState.CreationAsc:
                    purposes = purposes.OrderBy(s => s.CreationDate);
                    break;
                case SortState.NameAsc:
                    purposes = purposes.OrderBy(s => s.Name);
                    break;
                case SortState.NameDesc:
                    purposes = purposes.OrderByDescending(s => s.Name);
                    break;
                case SortState.DateAsc:
                    purposes = purposes.OrderBy(s => s.Due);
                    break;
                case SortState.DateDesc:
                    purposes = purposes.OrderByDescending(s => s.Due);
                    break;
                case SortState.CompletedAsc:
                    purposes = purposes.OrderBy(s => s.IsCompleted);
                    break;
                case SortState.CompletedDesc:
                    purposes = purposes.OrderByDescending(s => s.IsCompleted);
                    break;
                case SortState.ImportanceAsc:
                    purposes = purposes.OrderBy(s => s.Importance);
                    break;
                case SortState.ImportanceDesc:
                    purposes = purposes.OrderByDescending(s => s.Importance);
                    break;
                default:
                    purposes = purposes.OrderByDescending(s => s.CreationDate);
                    break;
            }

            var count = await purposes.CountAsync();
            var items = await purposes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            GeneralViewModel general = new GeneralViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(name),
                Purposes = items
            };

            return View(general);
        }

        [HttpGet]
        public IActionResult CreatePurpose() => View();

        [HttpPost]
        public async Task<IActionResult> CreatePurpose(Purpose purpose)
        {
            db.Purposes.Add(purpose);
            await db.SaveChangesAsync();
            return RedirectToActionPermanent("Index");
        }

        public async Task<IActionResult> EditPurpose(int? id)
        {
            if (id != null)
            {
                Purpose purpose = await db.Purposes.FirstOrDefaultAsync(p => p.Id == id);
                if (purpose != null)
                {
                    return View(purpose);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditPurpose(Purpose purpose)
        {
            db.Purposes.Update(purpose);
            await db.SaveChangesAsync();
            return RedirectToActionPermanent("Index");
        }

        [HttpGet]
        [ActionName("DeletePurpose")]
        public async Task<IActionResult> ConfirmDeletePurpose(int? id)
        {
            if (id != null)
            {
                Purpose purpose = await db.Purposes.FirstOrDefaultAsync(p => p.Id == id);
                if (purpose != null)
                {
                    return View(purpose);
                }
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
