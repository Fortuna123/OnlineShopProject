using Microsoft.AspNetCore.Mvc;
using OnlineShopProject.Data;
using OnlineShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagsController : Controller
    {
        private ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET Index Action Method
        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        //GET Create Action Method
        public ActionResult Create()
        {
            return View();
        }

        //POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags Name)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Add(Name);
                await _db.SaveChangesAsync();
                TempData["save"] = "Tag has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(Name);
        }

        //GET Edit Action Method
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTag = _db.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }

        //POST Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTags specialTag)
        {
            if (ModelState.IsValid)
            {
                _db.Update(specialTag);
                await _db.SaveChangesAsync();
                TempData["update"] = "Tag has been updated";
                return RedirectToAction(nameof(Index));
            }

            return View(specialTag);
        }

        //GET Details Action Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTag = _db.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }

        //POST Details Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecialTags Name)
        {
            return RedirectToAction(nameof(Index));
        }

        //GET Delete Action Method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTag = _db.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }

        //POST Delete Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpecialTags Name)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != Name.Id)
            {
                return NotFound();
            }

            var specialTag = _db.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Remove(specialTag);
                await _db.SaveChangesAsync();
                TempData["deleteProduct"] = "Tag has been deleted";
                return RedirectToAction(nameof(Index));
            }

            return View(Name);
        }
    }
}
