using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DockerDemo.Entities
{
    public class Product
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
