using BulkyBook.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {

            IEnumerable<Category1> categoryList = _db.Categories1;
            return View(categoryList);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category1 obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The displayorder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories1.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories1.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category1 obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The displayorder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories1.Update(obj);
                _db.SaveChanges();
				TempData["Success"] = "Category Updated Successfully";
				return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories1.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories1.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Categories1.Remove(obj);
                _db.SaveChanges();
			TempData["Success"] = "Category Removed Successfully";
			return RedirectToAction("Index");
        }
    }
}