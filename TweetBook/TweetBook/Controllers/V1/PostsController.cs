using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using TweetBook.Contracts;
using TweetBook.Contracts.V1;
using TweetBook.Contracts.V1.Requests;
using TweetBook.Contracts.V1.Responses;
using TweetBook.Domain;
using TweetBook.Services;

namespace TweetBook.Controllers.V1
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        
        [HttpGet(ApiRoutes.Post.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetPosts());
        }
        
        [HttpGet(ApiRoutes.Post.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid postId)
        {
            var post = await _postService.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }
            
            return Ok(post);
        }
        
        [HttpPut(ApiRoutes.Post.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid postId,
            [FromBody] UpdatePostRequest request)
        {
            var post = new Post
            {
                Id = postId,
                Name = request.Name
            };

            var updated = await _postService.UpdatePost(post);

            if (!updated)
            {
                return NotFound();
            }

            return Ok(post);
        }
        
        [HttpDelete(ApiRoutes.Post.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid postId)
        {
            var deleted = await _postService.DeletePost(postId);

            if (!deleted)
            {
                return NoContent();
            }

            return Ok();
        }

        [HttpPost(ApiRoutes.Post.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Name = postRequest.Name };
            
            await _postService.CreatePost(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUrl + "/" + ApiRoutes.Post.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };
            return Created(location, response);
        }
    }
}