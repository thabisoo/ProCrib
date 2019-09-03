using System;
using System.Collections.Generic;
using System.Text;

namespace ProCrib.ApplicationLogic.Entities
{
    public class ApartmentEntity
    {
        public Guid Id { get; set; }

        public Guid PropertyId { get; set; }

        public string Number { get; set; }

        public PropertyEntity Property {get; set;}
    }
}
