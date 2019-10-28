using ProCrib.ApplicationLogic.Entities;
using ProCrib.ApplicationLogic.Interfaces.Services;
using ProCrib.Domain;
using ProCrib.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCrib.ApplicationLogic.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IBaseRepository<Property> _propertyRepository;

        public PropertyService(IBaseRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<PropertyEntity> AddPropertyAsync(PropertyEntity propertyEntity)
        {
            if (string.IsNullOrWhiteSpace(propertyEntity.Name))
            {
                throw new ArgumentNullException("Property name can not be empty");
            }
                

            var property = new Property
            {
                Name = propertyEntity.Name,
                Description = propertyEntity.Description
            };

            _propertyRepository.Add(property);
            await _propertyRepository.SaveAsync();

            return new PropertyEntity
            {
                Id = property.Id,
                Name = property.Name,
                Description = property.Description
            };
        }

        public IEnumerable<PropertyEntity> GetAllPropertyAsync()
        {
            var properties = _propertyRepository.All();

            return properties.Select(p => new PropertyEntity
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            });
        }

        public PropertyEntity GetPropertyAsync(PropertyEntity propertyEntity)
        {
            if (propertyEntity.Id == Guid.Empty)
                throw new ArgumentNullException("Property id can not be empty");

            var property = _propertyRepository.Where(p => p.Id == propertyEntity.Id).FirstOrDefault();

            if (property == null)
                throw new NullReferenceException($"Property with id {propertyEntity.Id} does not exist");

            return new PropertyEntity
            {
                Id = property.Id,
                Name = property.Name,
                Description = property.Description
            };
        }

        public IEnumerable<PropertyEntity> GetUserProperties()
        {
            throw new NotImplementedException();
        }
    }
}
