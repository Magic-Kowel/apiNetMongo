using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication6.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }  
        public int Stock { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Categories { get; set; }
    }
}
