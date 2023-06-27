using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Contracts.V1;
using TweetBook.Contracts.V1.Requests;
using TweetBook.Data;
using TweetBook.Domain;
using TweetBook.Extensions;
using TweetBook.Services;

namespace TweetBook.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TagsController : Controller
    {
        private readonly IPostService _postService;
        private readonly DataContext _dataContext;

        public TagsController(IPostService postService, DataContext dataContext)
        {
            _postService = postService;
            _dataContext = dataContext;
        }
        
        [HttpPost(ApiRoutes.Tags.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
        {
            var tag = new Tag
            {
                Name = request.Name,
                PostId = _dataContext.Posts.First().Id
            };

            await _postService.CreateTagAsync(tag);

            return CreatedAtAction(nameof(Get), new { tagId = tag.Id }, tag);
        }

        [HttpGet(ApiRoutes.Tags.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid tagId)
        {
            var tag = await _postService.GetTagAsync(tagId);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }
        
        [HttpGet(ApiRoutes.Tags.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetAllTagsAsync());
        }
        
        

        [HttpDelete(ApiRoutes.Tags.Delete)]
        [Authorize(Policy = "MushWorkForChapsas")]
        public async Task<IActionResult> Delete([FromRoute] Guid tagId)
        {
            var deleted = await _postService.DeleteTagAsync(tagId);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}