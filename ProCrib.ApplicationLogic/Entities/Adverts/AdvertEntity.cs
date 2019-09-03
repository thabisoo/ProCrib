﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProCrib.ApplicationLogic.Entities.Adverts
{
    public class AdvertEntity
    {
        public Guid Id { get; set; }

        public Guid ApartmentId { get; set; }

        public Guid PropertyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
