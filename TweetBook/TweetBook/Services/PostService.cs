using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Contracts.V1;
using TweetBook.Contracts.V1.Responses;
using TweetBook.Data;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }

        public async Task<bool> CreatePost(Post post, List<string> tags)
        {
            await _dataContext.Posts.AddAsync(post);

            foreach (var tag in tags)
            {
                await _dataContext.Tags.AddAsync(new Tag
                {
                    Name = tag,
                    PostId = post.Id
                });
            }

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<PostsResponse> GetPosts()
        {
            var posts = await _dataContext.Posts.ToListAsync();

            return new PostsResponse
            {
                Items = posts.Select(x => new PostResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Tags = _dataContext.Tags.Where(xx => xx.PostId == x.Id)
                })
            };
        }

        public async Task<Post> GetPostById(Guid id)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdatePost(Post postToUpdate)
        {
            _dataContext.Posts.Update(postToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeletePost(Guid id)
        {
            var post = await GetPostById(id);

            if (post == null)
            {
                return false;
            }
            
            _dataContext.Posts.Remove(post);
            var tags = _dataContext.Tags.Where(x => x.PostId == post.Id);
            foreach (var tag in tags)
            {
                _dataContext.Tags.Remove(tag);
            }
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> UserOwnPostAsync(Guid postId, string userId)
        {
            var post = await _dataContext.Posts.AsNoTracking().SingleOrDefaultAsync(x => x.Id == postId);

            if (post == null)
            {
                return false;
            }

            if (post.UserId != userId)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _dataContext.Tags.ToListAsync();
        }

        public async Task<bool> DeleteTagAsync(Guid id)
        {
            var tag = await _dataContext.Tags.SingleOrDefaultAsync(x => x.Id == id);

            if (tag == null)
            {
                return false;
            }

            _dataContext.Tags.Remove(tag);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<Tag> GetTagAsync(Guid id)
        {
            return await _dataContext.Tags.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateTagAsync(Tag tag)
        {
            await _dataContext.Tags.AddAsync(tag);
            var result = await _dataContext.SaveChangesAsync();

            return result > 0;
        }
    }
}