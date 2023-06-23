namespace TweetBook.Contracts
{
    public static class ApiRoutes
    {
        private const string Route = "api";
        
        private const string Version = "v1";
        
        private const string Base = Route + "/" + Version;

        public static class Post
        {
            public const string GetAll = Base + "/posts";
        }
    }
}