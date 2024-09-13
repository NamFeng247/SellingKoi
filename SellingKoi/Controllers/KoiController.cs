using Microsoft.AspNetCore.Mvc;
using SellingKoi.Models;
using SellingKoi.Models.Entities;
using SellingKoi.Services;

namespace SellingKoi.Controllers
{
    public class KoiController : Controller
    {
        private readonly IKoiService _koiService;
        public KoiController(IKoiService koiService)
        {
            _koiService = koiService;
        }


        public async Task<IActionResult> KoiManagement()
        {
            var kois = await _koiService.GetAllKoisAsync();
            if(kois == null)
            {
                return NotFound("No Koi are found !"); 
            }
            return View(kois);
        }


        public async Task<IActionResult> Details(Guid id)
        {
  

            if (id == null)
            {
                return NotFound($"Koi with id '{id}' not found.");
            }

            var koi = await _koiService.GetKoiByIdAsync(id);
            if (koi == null)
            {
                return NotFound($"Koi with ID '{id}' not found.");
            }
            return View(koi);
        }

        public IActionResult CreateKoi()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateKoi(KOI koi)
        {
            if (ModelState.IsValid)
            {
                await _koiService.CreateKoiAsync(koi);
                return RedirectToAction(nameof(KoiManagement));
            }
            return View(koi);
        }

        public async Task<IActionResult> EditKoi(Guid id)
        {

            var koi= await _koiService.GetKoiByIdAsync(id);
            if (koi == null)
            {
                return NotFound();
            }
            return View(koi);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> EditKoi(Guid id, [Bind("Id,Name,Type,Age,Price,Description,FarmID,Length")] KOI koi)
        {
            if (id != koi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _koiService.UpdateKoiAsync(koi);
                    return RedirectToAction(nameof(KoiManagement));
                }
                catch (Exception ex)
                {
                    // Log the error
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(koi);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> NegateKoi(Guid id)
        {
            try
            {
                await _koiService.NegateKoiAsync(id);
                TempData["SuccessMessage"] = "Customer account has been negated successfully.";
                return RedirectToAction(nameof(KoiManagement));
            }
            catch (KeyNotFoundException)    
            {
                TempData["ErrorMessage"] = $"Customer with ID {id} not found.";
                return RedirectToAction(nameof(KoiManagement));
            }
            catch (Exception ex)
            {
                // Log the exception
                TempData["ErrorMessage"] = "An error occurred while updating the customer status.";
                return RedirectToAction(nameof(KoiManagement));
            }
        }
    }
}
