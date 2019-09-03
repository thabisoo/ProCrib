using ProCrib.ApplicationLogic.Entities.Adverts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProCrib.ApplicationLogic.Interfaces.Services
{
    public interface IAdvertService
    {
        Task<AdvertEntity> CreateAdvertAsync(AdvertEntity advertEntity);

        IEnumerable<AdvertEntity> GetAllAdvertsAsync();

        IEnumerable<AdvertEntity> GetPropertyAdvertsAsync(AdvertEntity advertEntity);
    }
}
