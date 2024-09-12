using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellingKoi.Data;
using SellingKoi.Models.Entities;
using SellingKoi.Services;

namespace SellingKoi.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> CustomerManagement()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return View(customers);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            //var idNullable = await _customerService.GetIdByNameAsync(name);
            //if (!idNullable.HasValue)
            //{
            //    return NotFound($"Customer with name '{name}' not found.");
            //}

            if (id == null)
            {
                return NotFound($"Customer with id '{id}' not found.");
            }

            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID '{id}' not found.");
            }
            return View(customer);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddCustomerAsync(customer);
                return RedirectToAction(nameof(CustomerManagement));
            }
            return View(customer);
        }

        //edit customer

        public async Task<IActionResult> EditCustomer(Guid id)
        {

            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }   
            return View(customer);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomer(Guid id, [Bind("Id,Name,Email,Phone,Address")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _customerService.UpdateCustomerAsync(customer);
                    return RedirectToAction(nameof(CustomerManagement));
                }
                catch (Exception ex)
                {
                    // Log the error
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(customer);
        }

        //Negate customer's account
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> NegateCustomer(Guid id)
        {
            try
            {
                await _customerService.NegateCustomerAsync(id);
                TempData["SuccessMessage"] = "Customer account has been negated successfully.";
                return RedirectToAction(nameof(CustomerManagement));
            }
            catch (KeyNotFoundException)
            {
                TempData["ErrorMessage"] = $"Customer with ID {id} not found.";
                return RedirectToAction(nameof(CustomerManagement));
            }
            catch (Exception ex)
            {
                // Log the exception
                TempData["ErrorMessage"] = "An error occurred while updating the customer status.";
                return RedirectToAction(nameof(CustomerManagement));
            }
        }


    }
}

