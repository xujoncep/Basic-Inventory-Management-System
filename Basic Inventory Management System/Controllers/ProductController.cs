using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.IService;

namespace Basic_Inventory_Management_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IDDLService _ddlService;
        public ProductController(IProductService productService, IDDLService ddlService)
        {
            _productService = productService;
            _ddlService = ddlService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _productService.GetAllProduct();
            return View(data);
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Product model = new Product();
            model.CategoryDDL = await _ddlService.GetCategoryDDL();
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                var data = await _productService.Create(model);
                if (data)
                {
                    TempData["success"] = "Product Successfuly Created";
                }
                else
                {
                    TempData["failed"] = "Saved Failed";
                }
                return RedirectToAction("Index");
            }
            model.CategoryDDL = await _ddlService.GetCategoryDDL();
            return View(model);
        }
       
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _productService.GetProductById(id);
            if (data == null)
            {
                ViewBag.ErrorMessage = "Product Not Found";
                return View("NotFound");
            }
            data.CategoryDDL = await _ddlService.GetCategoryDDL(data.CategoryId);
            return View(data);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                var data = await _productService.Edit(model);
                if (data)
                {
                    TempData["success"] = "Product Successfuly Updated";
                }
                else
                {
                    TempData["failed"] = "Update Failed";
                }
                return RedirectToAction("Index");
            }
            model.CategoryDDL = await _ddlService.GetCategoryDDL(model.CategoryId);
            return View(model);
        }
        
        [HttpPost]
        public async Task<JsonResult> IsProductExist(int ProductId, string ProductName)
        {
            bool result = await _productService.IsProductExist(ProductId, ProductName);
            return Json(!result);
        }
    }
}
