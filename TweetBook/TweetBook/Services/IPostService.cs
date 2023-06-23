using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TweetBook.Domain;

namespace TweetBook.Services
{
    public interface IPostService
    {
        Task<bool> CreatePost(Post post);

        Task<List<Post>> GetPosts();

        Task<Post> GetPostById(Guid id);

        Task<bool> UpdatePost(Post postToUpdate);

        Task<bool> DeletePost(Guid id);
    }
}