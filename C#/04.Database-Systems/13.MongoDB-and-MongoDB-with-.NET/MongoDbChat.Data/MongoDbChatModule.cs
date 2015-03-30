namespace MongoDbChat.Data
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    using MongoDB.Driver.Builders;

    using MongoDbChat.Model;

    public class MongoDbChatModule
    {
        private readonly MongoDbContext mongoDbContext;

        public MongoDbChatModule(MongoDbContext mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
        }

        private long PostsCountOnLastCheck { get; set; }

        public void AddPost(Message message)
        {
            this.mongoDbContext.Posts.Insert(message);
        }

        public Task<bool> HaveNewPosts()
        {
            return Task.Run(() =>
            {
                var newPostCount = this.mongoDbContext.Posts.Count();
                var haveNewPosts = newPostCount != this.PostsCountOnLastCheck;
                if (haveNewPosts)
                {
                    this.PostsCountOnLastCheck = newPostCount;
                }
                return haveNewPosts;
            });
        }

        public StringBuilder GenerateAllPostsAsString(DateTime startDate, DateTime endDate)
        {
            var postsAsString = new StringBuilder();
            var findPostsInDateRangeQuery = Query<Message>.Where(post => post.PostTime >= startDate && post.PostTime <= endDate);
            var posts = this.mongoDbContext.Posts.Find(findPostsInDateRangeQuery);
            foreach (var post in posts)
            {
                postsAsString.AppendLine(this.GenerateOnePostAsString(post));
            }
            if (postsAsString.Length >= 2)
            {
                postsAsString.Length -= 2;
            }
            return postsAsString;
        }

        public string GenerateOnePostAsString(Message message)
        {
            var formattedDate = message.PostTime.ToLocalTime().ToString("dd.MM.yyyy hh:mm:ss");
            return string.Format("[{0}] {1}: {2}", formattedDate, message.User.Name, message.Text);
        }
    }
}