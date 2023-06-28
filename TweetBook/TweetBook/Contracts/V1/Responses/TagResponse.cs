using System;

namespace TweetBook.Contracts.V1.Responses
{
    public class TagResponse
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public Guid PostId { get; set; }
    }
}