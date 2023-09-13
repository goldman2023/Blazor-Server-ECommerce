using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using QuickTie.Cloud.Repository;
using QuickTie.Data;
using QuickTie.Data.Attributes;
using QuickTie.Data.Models;
using System.Reflection;

namespace QuickTie.Portal.Data.Repository.Services
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMemoryCache _cache;
        private readonly IMongoClient _client;
        private readonly IMongoCollection<TDocument> _collection;
        private readonly string _cacheName;

        public MongoRepository(IMongoDbSettings settings, IMemoryCache cache)
        {
            _client = new MongoClient(settings.ConnectionString);

            var database = _client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
            _cache = cache;
            _cacheName = _collection.CollectionNamespace.CollectionName;
        }

        private string GetCollectionName(Type documentType)
        {
            var attribute = documentType.GetCustomAttribute<BsonCollectionAttribute>();
            return attribute?.CollectionName ?? string.Empty;
        }

        public virtual IMongoQueryable<TDocument> GetQueryable()
        {
            return _collection.AsQueryable();
        }

        public virtual async Task<IEnumerable<TDocument>> FindByFilterAsync(IMongoQueryable<TDocument> collectionQuery, int skip = 0, int take = 0)
        {
            if (skip > 0)
            {
                collectionQuery = collectionQuery.Skip(skip);
            }
            if (take > 0)
            {
                collectionQuery = collectionQuery.Take(take);
            }

            String filterString = collectionQuery.Expression.ToString();
            var cacheEntry = await _cache.GetOrCreateAsync($"{_cacheName}_{filterString}_{skip}_{take}", async entry =>
            {
                entry.AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(15));
                return await collectionQuery.ToListAsync();
            });

            return cacheEntry;
        }

        public async Task<long> GetCountByFilterAsync(IMongoQueryable<TDocument> collectionQuery)
        {
            return await collectionQuery.CountAsync();
        }

        public virtual async Task<TDocument> FindByIdAsync(string id)
        {
            var cacheEntry = await _cache.GetOrCreateAsync($"{_cacheName}_{id}", async entry =>
            {
                entry.AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(15));
                return await _collection.Find(doc => doc.Id == id).SingleOrDefaultAsync();
            });

            return cacheEntry;
        }
    }
}