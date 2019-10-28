using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProCrib.ApplicationLogic.Entities;
using ProCrib.ApplicationLogic.Interfaces.Services;
using ProCrib.ApplicationLogic.ViewModels.Properties;

namespace ProCrib.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public IActionResult Index()
        {
            var model = new ListPropertiesViewModel
            {
                Properties = _propertyService.GetAllPropertyAsync().Select(p => new PropertyViewModel 
                { 
                    Id = p.Id,
                    Name = p.Name
                }),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPropertyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _propertyService.AddPropertyAsync(new PropertyEntity
            {
                Name = model.Name,
                Description = model.Description
            });

            return Redirect("Index");
        }
    }
}