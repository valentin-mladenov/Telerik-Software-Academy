// FOR TEST PURPOSESONLY
// NOT WORKING WITH  TELERIK ACADEMY DB

namespace MongoDbChat.ConsoleApp
{
    using System;

    using MongoDbChat.Data;

    using MongoDbChat.Model;

    public class ConsoleApp
    {
        private static readonly MongoDbContext mongoDbContext = new MongoDbContext();
        private static readonly MongoDbChatModule crowdChatModule = new MongoDbChatModule(mongoDbContext);
        
        private static void PrintAllPosts()
        {
            var postsAsString = crowdChatModule.GenerateAllPostsAsString(DateTime.MinValue, DateTime.MaxValue);
            Console.WriteLine(postsAsString);
            Console.WriteLine("\nNumber of posts: {0}\n", mongoDbContext.Posts.Count());
        }

        private static void AddPost()
        {
            var postWithRandomContent = new Message()
            {
                PostTime = DateTime.Now,
                Text = Guid.NewGuid().ToString(),
                User = new User("admin")
            };
            crowdChatModule.AddPost(postWithRandomContent);
        }

        public static void Main()
        {
            AddPost();
            PrintAllPosts();
        }
    }
}
