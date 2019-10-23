using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProCrib.ApplicationLogic.Interfaces.Services;
using ProCrib.ApplicationLogic.ViewModels.Adverts;

namespace ProCrib.Controllers.MVC
{
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public IActionResult Index()
        {
            var adverts = _advertService.GetAllAdvertsAsync();

            var result = adverts.Select(a => new AdvertViewModel
            {
                Id = a.Id,
                ApartmentId = a.ApartmentId,
                Title = a.Title,
                Description = a.Description,
                Price = a.Price,
                IsActive = a.IsActive,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            });

            return View(result);
        }

        public IActionResult NewAdvert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewAdvert(AdvertViewModel model)
        {
            model.ApartmentId = Guid.Parse("E317E343-DE94-4974-BECD-E48310FCEAA0");

            var advert = await _advertService.CreateAdvertAsync(new ApplicationLogic.Entities.Adverts.AdvertEntity
            {
                ApartmentId = model.ApartmentId,
                Title = model.Title,
                Description = model.Description,
                Price =  model.Price
            });

            return RedirectToAction("Index");
        }
    }
}