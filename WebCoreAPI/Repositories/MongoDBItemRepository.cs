using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreAPI.Entities;

namespace WebCoreAPI.Repositories
{
    public class MongoDBItemRepository : IItemRepository
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDBItemRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            this.itemCollection = database.GetCollection<Item>(collectionName);
        }

        public async Task CreateItemAsync(Item item)
        {
            await itemCollection.InsertOneAsync(item);
        }

        public async Task DeleteItemAsync(Guid Id)
        {
            var filter = filterBuilder.Eq(item => item.Id, Id);
            await itemCollection.DeleteOneAsync(filter);
        }

        public async Task<Item> getItemAsync(Guid Id)
        {
            var filter = filterBuilder.Eq(item => item.Id, Id);
            return await itemCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await itemCollection.Find(f => true).ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await itemCollection.ReplaceOneAsync(filter, item);
        }
    }
}
