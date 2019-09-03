using ProCrib.ApplicationLogic.Entities.Adverts;
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
    public class AdvertService : IAdvertService
    {
        private readonly IBaseRepository<Advert> _advertRepository;
        private readonly IBaseRepository<Property> _propertyRepository;
        private readonly IBaseRepository<Apartment> _apartmentRepository;

        public AdvertService(IBaseRepository<Advert> advertRepository,
            IBaseRepository<Property> propertyRepository,
            IBaseRepository<Apartment> apartmentRepository)
        {
            _advertRepository = advertRepository;
            _propertyRepository = propertyRepository;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<AdvertEntity> CreateAdvertAsync(AdvertEntity advertEntity)
        {
            if(advertEntity.ApartmentId == Guid.Empty)
            {
                throw new ArgumentNullException("Advert id can not be empty");
            }

            if (string.IsNullOrWhiteSpace(advertEntity.Title))
            {
                throw new ArgumentNullException("Advert title can not be empty");
            }

            if (advertEntity.Price == 0)
            {
                throw new ArgumentNullException("Advert price can not be empty");
            }

            var advert = new Advert
            {
                ApartmentId = advertEntity.ApartmentId,
                Title = advertEntity.Title,
                Description = advertEntity.Description,
                Price = advertEntity.Price,
                IsActive = true,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };

            _advertRepository.Add(advert);
            await _advertRepository.SaveAsync();

            return new AdvertEntity
            {
                Id = advert.Id,
                ApartmentId = advert.ApartmentId,
                Title = advert.Title,
                Description = advert.Description,
                Price = advert.Price,
                IsActive = advert.IsActive,
                CreatedAt = advert.CreatedAt,
                UpdatedAt = advert.UpdatedAt
            };
        }

        public IEnumerable<AdvertEntity> GetAllAdvertsAsync()
        {
            var adverts = _advertRepository.Where(a => a.IsActive == true);

            return adverts.Select(a => new AdvertEntity
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
        }

        public IEnumerable<AdvertEntity> GetPropertyAdvertsAsync(AdvertEntity advertEntity)
        {
            if(advertEntity.PropertyId == Guid.Empty)
            {
                throw new ArgumentNullException("Property Id can not be empty");
            }

            var property = _propertyRepository.Where(p => p.Id == advertEntity.PropertyId).FirstOrDefault();

            if(property == null)
            {
                throw new NullReferenceException($"Property with id {advertEntity.PropertyId} does not exist");
            }

            var propertyApartmentIds = _apartmentRepository.Where(a => a.PropertyId == property.Id).Select(x => x.Id);

            var adverts = _advertRepository.Where(a => propertyApartmentIds.Contains(a.Id) && a.IsActive == true);

            return adverts.Select(a => new AdvertEntity
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
        }
    }
}
