using ProCrib.ApplicationLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProCrib.ApplicationLogic.Interfaces.Services
{
    public interface IApartmentService
    {
        Task<ApartmentEntity> AddApartmentAsync(ApartmentEntity apartmentEntity);
    }
}
