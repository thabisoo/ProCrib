using System;
using System.Collections.Generic;
using System.Text;

namespace ProCrib.ApplicationLogic.Entities.Posts
{
    public class PostEntity
    {
        public Guid Id { get; set; }

        public Guid PropertyId { get; set; }

        public string Body { get; set; }

        public int Likes { get; set; }

        public string Username { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
