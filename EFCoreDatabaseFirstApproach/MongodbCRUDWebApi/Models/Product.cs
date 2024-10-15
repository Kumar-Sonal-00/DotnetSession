
using MongoDB.Bson.Serialization.Attributes;

namespace MongodbCRUDWebApi.Models
{
    public class Product
    {
        [BsonId]
        public string ProductId {  get; set; }  //_id column mapping    
        public string Description { get; set; }
        public int Price { get; set; }
    }    
}
