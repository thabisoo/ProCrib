using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProCrib.ApplicationLogic.ViewModels.Properties
{
    public class PropertyViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please provide property name.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
