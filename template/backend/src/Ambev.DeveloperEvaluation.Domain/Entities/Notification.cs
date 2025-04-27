using MongoDB.Bson.Serialization.Attributes;


namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Notification
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("body")]
        public string Body { get; set; }
        [BsonElement("orderid")]
        public Guid OrderId { get; set; }
    }
}
