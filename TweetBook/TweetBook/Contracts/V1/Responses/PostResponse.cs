using System;
using System.Collections.Generic;
using System.Linq;
using TweetBook.Domain;

namespace TweetBook.Contracts.V1.Responses
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public IEnumerable<Tag> Tags { get; set; } = Enumerable.Empty<Tag>();
    }
}