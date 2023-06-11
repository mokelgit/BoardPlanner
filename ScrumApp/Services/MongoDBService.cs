using ScrumApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ScrumApp.Services
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            _database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        }
        //Insert One
        public async Task CreateAsync<T>(string collectionName, T item)
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(item);
        }
        //Find All
        public async Task<List<T>> GetAsync<T>(string collectionName)
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);
            var filter = new BsonDocument();
            var documents = await collection.Find(filter).ToListAsync();
            return documents;
        }

        //Find Query

        public async Task<List<T>> GetQueryAsync<T>(string collectionName, string user_name)
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("User_Name", user_name);
            var documents = await collection.Find(filter).ToListAsync();
            return documents;
        }

    }
}