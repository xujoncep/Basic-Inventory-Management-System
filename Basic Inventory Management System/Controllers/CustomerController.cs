using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.IService;

namespace Basic_Inventory_Management_System.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _cService;
        public CustomerController(ICustomerService cService)
        {
            _cService = cService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _cService.GetAllCustomer();
            return View(data);
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                var data = await _cService.Create(model);
                if (data)
                {
                    TempData["success"] = "Customer Successfuly Added!";
                }
                else
                {
                    TempData["failed"] = "Saved Failed!!";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
       
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _cService.GetCustomerById(id);
            if (data == null)
            {
                ViewBag.ErrorMessage = "Customer Not Found!!";
                return View("NotFound");
            }
            return View(data);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer model)
        {
            if (ModelState.IsValid)
            {
                var data = await _cService.Edit(model);
                if (data)
                {
                    TempData["success"] = "Customer Successfuly Updated!";
                }
                else
                {
                    TempData["failed"] = "Update Failed!!";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> IsCustomerCodeExist(int CustomerId, string CustomerCode)
        {
            bool result = await _cService.IsCustomerCodeExist(CustomerId, CustomerCode);
            return Json(!result);
        }
    }
}
