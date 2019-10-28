using System;
using System.Collections.Generic;
using System.Text;

namespace ProCrib.ApplicationLogic.ViewModels.Properties
{
    public class ListPropertiesViewModel
    {
        public IEnumerable<PropertyViewModel> Properties { get; set; }

        public AddPropertyViewModel AddProperty { get; set; }
    }
}
