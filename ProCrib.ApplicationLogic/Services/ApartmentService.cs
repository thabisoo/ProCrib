using ProCrib.ApplicationLogic.Entities;
using ProCrib.ApplicationLogic.Interfaces.Services;
using ProCrib.Domain;
using ProCrib.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProCrib.ApplicationLogic.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IBaseRepository<Apartment> _apartmentRepository;
        public ApartmentService(IBaseRepository<Apartment> apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public async Task<ApartmentEntity> AddApartmentAsync(ApartmentEntity apartmentEntity)
        {
            var apartment = new Apartment
            {
                Number = apartmentEntity.Number,
                PropertyId = apartmentEntity.PropertyId
            };

            _apartmentRepository.Add(apartment);
            await _apartmentRepository.SaveAsync();

            return new ApartmentEntity();
        }
    }
}
