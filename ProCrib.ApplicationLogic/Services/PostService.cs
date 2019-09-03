using ProCrib.ApplicationLogic.Entities;
using ProCrib.ApplicationLogic.Entities.Posts;
using ProCrib.ApplicationLogic.Interfaces.Services;
using ProCrib.Domain;
using ProCrib.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCrib.ApplicationLogic.Services
{
    public class PostService : IPostService
    {
        private readonly IBaseRepository<Post> _postRepository;
        private readonly IBaseRepository<Property> _propertyRepository;

        public PostService(IBaseRepository<Post> postRepository,
            IBaseRepository<Property> propertyRepository)
        {
            _postRepository = postRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<PostEntity> CreatePostAsync(PostEntity postEntity)
        {
            if(postEntity.PropertyId == Guid.Empty)
            {
                throw new ArgumentNullException("Property id can not be empty");
            }

            if (string.IsNullOrWhiteSpace(postEntity.Body))
            {
                throw new ArgumentNullException("Post body can not be empty");
            }

            var property = _propertyRepository.Where(p => p.Id == postEntity.PropertyId).FirstOrDefault();

            if(property == null)
            {
                throw new NullReferenceException($"Property with id {postEntity.PropertyId} does not exist");
            }

            var post = new Post
            {
                PropertyId = property.Id,
                Body = postEntity.Body,
                Likes = 0,
                CreatedAt = DateTimeOffset.Now
            };

            _postRepository.Add(post);
            await _postRepository.SaveAsync();

            return new PostEntity
            {
                Id = post.Id,
                PropertyId = post.PropertyId,
                Body = post.Body,
                Date = post.CreatedAt,
                Likes = post.Likes
            };
        }

        public PostListEntity GetPropertyPostsAsync(PostEntity postEntity)
        {
            if(postEntity.PropertyId == Guid.Empty)
            {
                throw new ArgumentNullException($"Property id can not be empty");
            }

            var property = _propertyRepository.Where(p => p.Id == postEntity.PropertyId).FirstOrDefault();

            if (property == null)
            {
                throw new NullReferenceException($"Property with id {postEntity.PropertyId} does not exits");
            }

            var posts = _postRepository.Where(p => p.PropertyId == property.Id).OrderByDescending(p => p.CreatedAt);

            return new PostListEntity
            {
                Property = new PropertyEntity
                {
                    Id = property.Id,
                    Name = property.Name
                },
                Posts = posts.Select(p => new PostEntity
                {
                    Id = p.Id,
                    Body = p.Body,
                    Date = p.CreatedAt,
                    Likes = p.Likes,
                    Username = "Thabiso Motsoko"
                })
            };
        }

        public async Task<PostEntity> LikePostAsync(PostEntity postEntity)
        {
            var post = _postRepository.Where(p => p.Id == postEntity.Id && p.PropertyId == postEntity.PropertyId).FirstOrDefault();

            if(post == null)
            {
                throw new NullReferenceException($"Post with id {postEntity.Id} from property with id {postEntity.PropertyId} does not exist");
            }

            post.Likes++;

            _postRepository.Update(post);
            await _postRepository.SaveAsync();

            return new PostEntity
            {
                Id = post.Id,
                Body = post.Body,
                Date = post.CreatedAt,
                Likes = post.Likes,
                Username = "Thabiso Motsoko"
            };
        }
    }
}
