using System;
using System.Collections.Generic;
using System.Text;

namespace ProCrib.Domain.Models
{
    public class Apartment
    {
        public Guid Id { get; set; }

        public Guid PropertyId { get; set; }

        public string Number { get; set; }

        public virtual Property Property { get; set; }
    }
}
