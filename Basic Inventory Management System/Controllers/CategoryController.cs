using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.IService;

namespace Basic_Inventory_Management_System.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _catService;

        public CategoryController(ICategoryService catService)
        {
            _catService = catService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _catService.GetAllCetegory();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var data = await _catService.Create(model);
                if (data)
                {
                    TempData["success"] = "Successfuly Created";
                }
                else
                {
                    TempData["failed"] = "Saved Failed";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _catService.GetCategoryById(id);
            if (data == null)
            {
                ViewBag.ErrorMessage = "Category Not Found";
                return View("NotFound");
            }

            return View(data);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                var data = await _catService.Edit(model);
                if (data)
                {
                    TempData["success"] = "Successfuly Updated";
                }
                else
                {
                    TempData["failed"] = "Update Failed";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
