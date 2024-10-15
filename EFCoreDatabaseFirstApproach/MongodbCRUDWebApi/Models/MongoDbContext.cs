using MongoDB.Driver;

namespace MongodbCRUDWebApi.Models
{
    public class MongoDbContext
    {
        MongoClient client;
        IMongoDatabase database;

        public MongoDbContext()
        {
            client= new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("ProductDb");
        }

        public IMongoCollection<Product> Products => database.GetCollection<Product>("products"); //this is the collection name in mongodb database
    }
}
