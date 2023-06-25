using System;
using System.ComponentModel.DataAnnotations;

namespace TweetBook.Domain
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public Guid PostId { get; set; }
    }
}