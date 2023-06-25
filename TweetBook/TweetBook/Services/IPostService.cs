using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetBook.Contracts.V1.Responses;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public interface IPostService
    {
        Task<bool> CreatePost(Post post, List<string> tags);

        Task<PostsResponse> GetPosts();

        Task<Post> GetPostById(Guid id);

        Task<bool> UpdatePost(Post postToUpdate);

        Task<bool> DeletePost(Guid id);

        Task<bool> UserOwnPostAsync(Guid postId, string userId);

        Task<List<Tag>> GetAllTagsAsync();
    }
}