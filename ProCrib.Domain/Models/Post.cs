using System;
using System.Collections.Generic;
using System.Text;

namespace ProCrib.Domain.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public Guid PropertyId { get; set; }

        public string Body { get; set; }

        public int Likes { get; set; }

        public virtual Property Property { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
}
