namespace MongoDbChat.Model
{
    using System;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User
    {
        public User(string name)
        {
            this.Name = name;
            this.LoginTime = DateTime.Now;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Name { get; set; }

        public DateTime LoginTime { get; set; }
    }
}