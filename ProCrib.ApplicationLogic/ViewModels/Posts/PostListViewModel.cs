using ProCrib.ApplicationLogic.ViewModels.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProCrib.ApplicationLogic.ViewModels.Posts
{
    public class PostListViewModel
    {
        public PropertyViewModel Property { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
