﻿namespace TweetBook.Contracts.V1
{
    public static class ApiRoutes
    {
        private const string Route = "api";
        
        private const string Version = "v1";
        
        private const string Base = Route + "/" + Version;

        public static class Post
        {
            public const string GetAll = Base + "/posts";
            
            public const string Update = Base + "/posts/{postId}";
            
            public const string Delete = Base + "/posts/{postId}";

            public const string Get = Base + "/posts/{postId}";
            
            public const string Create = Base + "/posts";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";
        }

        public static class Tags
        {
            public const string GetAll = Base + "/tags";
            
            public const string Get = Base + "/tags/{tagId}"; 
            
            public const string Create = Base + "/tags";
            
            public const string Delete = Base + "/tags/{tagId}";
        }
    }
}