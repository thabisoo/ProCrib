using System;
using System.Collections.Generic;
using System.Text;

namespace ProCrib.ApplicationLogic.Entities.Posts
{
    public class PostListEntity
    {
        public PropertyEntity Property { get; set; }

        public IEnumerable<PostEntity> Posts { get; set; }
    }
}
