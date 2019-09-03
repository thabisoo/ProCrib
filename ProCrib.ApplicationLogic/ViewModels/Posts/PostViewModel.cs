using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProCrib.ApplicationLogic.ViewModels.Posts
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        public Guid PropertyId { get; set; }

        public string Username { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Blurb { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }
    }
}
