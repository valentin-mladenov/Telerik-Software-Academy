namespace MongoDbChat.Model
{
    using System;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Text { get; set; }

        public DateTime PostTime { get; set; }

        public User User { get; set; }
    }
}