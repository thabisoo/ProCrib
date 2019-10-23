using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProCrib.ApplicationLogic.Interfaces.Services;
using ProCrib.ApplicationLogic.ViewModels.Properties;

namespace ProCrib.Controllers.MVC
{
    public class MobileController : Controller
    {
        private readonly IPropertyService _propertyService;

        public MobileController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }


        public IActionResult PropertyList()
        {
            var properties = _propertyService.GetAllPropertyAsync();

            var result = properties.Select(p => new PropertyViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            });

            return View(result);
        }

        public IActionResult Mine()
        {
            return View();
        }

        public IActionResult Scan()
        {
            return View();
        }
    }
}