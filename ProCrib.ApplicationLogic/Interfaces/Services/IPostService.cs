using ProCrib.ApplicationLogic.Entities.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProCrib.ApplicationLogic.Interfaces.Services
{
    public interface IPostService
    {
        Task<PostEntity> CreatePostAsync(PostEntity postEntity);

        PostListEntity GetPropertyPostsAsync(PostEntity postEntity);

        Task<PostEntity> LikePostAsync(PostEntity postEntity);
    }
}
