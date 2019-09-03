using System;
using System.Collections.Generic;
using System.Text;

namespace ProCrib.Domain.Models
{
    public class Advert
    {
        public Guid Id { get; set; }

        public Guid ApartmentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool IsActive { get; set; }

        public virtual Apartment Apartment { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
