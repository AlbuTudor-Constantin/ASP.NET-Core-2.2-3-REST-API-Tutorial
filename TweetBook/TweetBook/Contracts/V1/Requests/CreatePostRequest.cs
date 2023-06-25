using System;
using System.Collections.Generic;
using System.Linq;

namespace TweetBook.Contracts.V1.Requests
{
    public class CreatePostRequest
    {
        public string Name { get; set; }

        public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();
    }
}