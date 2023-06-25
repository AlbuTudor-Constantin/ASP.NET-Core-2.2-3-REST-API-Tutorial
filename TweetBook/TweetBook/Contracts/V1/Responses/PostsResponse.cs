using System.Collections.Generic;
using System.Linq;

namespace TweetBook.Contracts.V1.Responses
{
    public class PostsResponse
    {
        public IEnumerable<PostResponse> Items { get; set; } = Enumerable.Empty<PostResponse>();
    }
}