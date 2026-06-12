using Journey.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Journey.WebAppMVC.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourService tourService;

        public ToursController(ITourService tourService)
        {
            this.tourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult> Collection()
        {
            return View((await tourService.GetToursAsync()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
