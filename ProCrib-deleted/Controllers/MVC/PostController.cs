using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProCrib.ApplicationLogic.Interfaces.Services;
using ProCrib.ApplicationLogic.ViewModels.Posts;
using ProCrib.ApplicationLogic.ViewModels.Properties;

namespace ProCrib.Controllers.MVC
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(Guid Id)
        {
            Id = Guid.Parse("E91470BC-8155-4944-E28D-08D728A64E61");
            var postList = _postService.GetPropertyPostsAsync(new ApplicationLogic.Entities.Posts.PostEntity
            {
                PropertyId = Id,
            });

            var result = new PostListViewModel
            {
                Property = new PropertyViewModel
                {
                    Id = postList.Property.Id,
                    Name = postList.Property.Name
                },
                Posts = postList.Posts.Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Body = p.Body,
                    Date = p.Date,
                    Likes = p.Likes,
                    Username = p.Username
                })
            };

            return View(result);
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewPost(PostViewModel model)
        {
            model.PropertyId = Guid.Parse("E91470BC-8155-4944-E28D-08D728A64E61");
            
            var post = await _postService.CreatePostAsync(new ApplicationLogic.Entities.Posts.PostEntity
            {
                PropertyId = model.PropertyId,
                Body = model.Body
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Like(PostViewModel model)
        {
            model.PropertyId = Guid.Parse("E91470BC-8155-4944-E28D-08D728A64E61");

            var post = await _postService.CreatePostAsync(new ApplicationLogic.Entities.Posts.PostEntity
            {
                PropertyId = model.PropertyId,
                Body = model.Body
            });

            return RedirectToAction("Index");
        }
    }
}