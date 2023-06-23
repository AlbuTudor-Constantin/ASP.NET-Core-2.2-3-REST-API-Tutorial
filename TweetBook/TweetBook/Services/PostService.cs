using System;
using System.Collections.Generic;
using System.Linq;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts;

        public PostService()
        {
            _posts = new List<Post>();

            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post Name {i}"
                });
            }
        }
        
        public List<Post> GetPosts()
        {
            return _posts;
        }

        public Post GetPostById(Guid id)
        {
            return _posts.SingleOrDefault(x => x.Id == id);
        }

        public bool UpdatePost(Post postToUpdate)
        {
            var postIndex = _posts.FindIndex(x => x.Id == postToUpdate.Id);

            if (postIndex == -1)
            {
                return false;
            }

            _posts[postIndex] = postToUpdate;
            return true;
        }

        public bool DeletePost(Guid id)
        {
            var deleted = _posts.RemoveAll(x => x.Id == id);

            return deleted > 0;
        }
    }
}