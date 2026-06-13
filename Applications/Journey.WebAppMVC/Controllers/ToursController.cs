using Journey.Models;
using Journey.Services.Contracts;
using Journey.WebAppMVC.Constants;
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
        public async Task<IActionResult> Collection(int page = 1)
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
        public IActionResult Create()
        {
            return View(ViewNames.Upsert, new TourUpsertViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TourUpsertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(ViewNames.Upsert, model);
            }

            var tour = new Tour
            {
                Location = model.Location,
                NightCount = model.NightCount,
                DepartureDate = model.DepartureDate,
                CostPerVacationer = model.CostPerVacationer,
                VacationerCount = model.VacationerCount,
                WiFiAvailabble = model.WiFiAvailable,
                Surcharge = model.Surcharge
            };

            await tourService.AddTourAsync(tour);

            return RedirectToAction(nameof(Collection));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tour = (await tourService.GetToursAsync()).SingleOrDefault(x => x.Id == id);

            if (tour == null)
            {
                return NotFound();
            }

            var model = new TourUpsertViewModel
            {
                Id = tour.Id,
                Location = tour.Location,
                NightCount = tour.NightCount,
                DepartureDate = tour.DepartureDate,
                CostPerVacationer = tour.CostPerVacationer,
                VacationerCount = tour.VacationerCount,
                WiFiAvailable = tour.WiFiAvailabble,
                Surcharge = tour.Surcharge
            };

            return View(ViewNames.Upsert, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TourUpsertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(ViewNames.Upsert, model);
            }

            var tour = (await tourService.GetToursAsync()).SingleOrDefault(x => x.Id == model.Id);

            if (tour == null)
            {
                return NotFound();
            }

            tour.Id = (int)model.Id!;
            tour.Location = model.Location;
            tour.NightCount = model.NightCount;
            tour.DepartureDate = model.DepartureDate;
            tour.CostPerVacationer = model.CostPerVacationer;
            tour.VacationerCount = model.VacationerCount;
            tour.WiFiAvailabble = model.WiFiAvailable;
            tour.Surcharge = model.Surcharge;

            await tourService.UpdateTourAsync(tour);

            return RedirectToAction(nameof(Collection));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            return RedirectToAction(nameof(Collection));
        }
    }
}
