using Journey.Services.Contracts;
using Journey.WebAppMVC.Models;
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
        public async Task<ActionResult> Collection(int page = 1)
        {
            var pageSize = 10;

            // Это надо на другой уровень, но я хотел попробовать пагинацию на сайте
            var tours = await tourService.GetToursAsync();
            var statistic = tourService.CalculateStatistics(tours);

            var count = tours.Count();

            tours = tours
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var viewModel = new ToursCollectionViewModel()
            {
                Tours = tours,
                Statistics = statistic,
                Page = page,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            return View(viewModel);
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
                return RedirectToAction(nameof(Collection));
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
                return RedirectToAction(nameof(Collection));
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
                return RedirectToAction(nameof(Collection));
            }
            catch
            {
                return View();
            }
        }
    }
}
