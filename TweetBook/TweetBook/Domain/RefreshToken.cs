﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TweetBook.Domain
{
    public class RefreshToken
    {
        
        [Key]
        public string Token { get; set; }
        
        public string JwtId { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public DateTime ExpiryTime { get; set; }
        
        public bool Used { get; set; }
        
        public bool Invalidated { get; set; }
        
        public string UserId { get; set; }
    }
}