using System;
using Swashbuckle.AspNetCore.Filters;
using TweetBook.Contracts.V1.Responses;

namespace TweetBook.SwaggerExamples.Responses
{
    public class TagResponseExample : IExamplesProvider<TagResponse>
    {
        public TagResponse GetExamples()
        {
            return new TagResponse 
            {
                Id = Guid.NewGuid(),
                Name = "tag name",
                PostId = Guid.NewGuid()
            };
        }
    }
}