using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProCrib.ApplicationLogic.Interfaces.Services;
using ProCrib.ApplicationLogic.ViewModels.Properties;
using ProCrib.Models;

namespace ProCrib.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyService _propertyService;

        public HomeController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public IActionResult Index()
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
