using ProCrib.ApplicationLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProCrib.ApplicationLogic.Interfaces.Services
{
    public interface IPropertyService
    {
        Task<PropertyEntity> AddPropertyAsync(PropertyEntity propertyEntity);

        PropertyEntity GetPropertyAsync(PropertyEntity propertyEntity);

        IEnumerable<PropertyEntity> GetAllPropertyAsync();
    }
}
