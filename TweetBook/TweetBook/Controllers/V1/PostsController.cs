using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Contracts;
using TweetBook.Domain;

namespace TweetBook.Controllers.V1
{
    public class PostsController : Controller
    {
        private readonly List<Post> _posts;
        
        public PostsController()
        {
            _posts = new List<Post>();

            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }
        
        [HttpGet(ApiRoutes.Post.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }
    }
}