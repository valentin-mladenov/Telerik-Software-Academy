namespace MongoDbChat.Data
{
    using MongoDB.Driver;

    using MongoDbChat.Model;

    public class MongoDbContext
    {
        private const string ConnectionString = "mongodb://admin:telerik@ds035280.mongolab.com:35280/crowdchat";
        private const string DatabaseName = "crowdchat";
        
        // I can't show my UN and pass sorry. It wont work that way.
        // private const string ConnectionString = "mongodb://*******:*******@ds063859.mongolab.com:63859/hudsonvsm_chat_db";
        // private const string DatabaseName = "hudsonvsm_chat_db";

        private MongoDatabase mongoDatabase;

        public MongoDbContext()
            : this(ConnectionString, DatabaseName)
        {
        }

        public MongoDbContext(string connectionString, string databaseName)
        {
            var mongoClient = new MongoClient(connectionString);
            var mongoServer = mongoClient.GetServer();
            this.mongoDatabase = mongoServer.GetDatabase(databaseName);
        }

        public MongoCollection<Message> Posts
        {
            get
            {
                return this.GetCollection<Message>("Message");
            }
        }

        public MongoCollection<User> Users
        {
            get
            {
                return this.GetCollection<User>("Users");
            }
        }

        private MongoCollection<T> GetCollection<T>(string collectionName)
        {
            return this.mongoDatabase.GetCollection<T>(collectionName);
        }
    }
}