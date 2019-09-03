using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProCrib.ApplicationLogic.Entities;
using ProCrib.ApplicationLogic.Interfaces.Services;
using ProCrib.ApplicationLogic.ViewModels.Properties;

namespace ProCrib.Controllers.MVC
{
    [Route("/properties")]
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        //public IActionResult Index()
        //{
        //    var properties = _propertyService.GetAllPropertyAsync();

        //    var result = properties.Select(p => new PropertyViewModel
        //    {
        //        Id = p.Id,
        //        Name = p.Name,
        //        Description = p.Description
        //    });

        //    return View(result);
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var property = await _propertyService.AddPropertyAsync(new PropertyEntity
            {
                Name = model.Name,
                Description = model.Description
            });

            return Ok(property);
        }

        [HttpGet("{id}")]
        public IActionResult Details(Guid id)
        {
            var property = _propertyService.GetPropertyAsync(new PropertyEntity
            {
                Id = id
            });

            var result = new PropertyViewModel
            {
                Id = property.Id,
                Name = property.Name,
                Description = property.Description
            };

            return View(result);
        }
    }
}