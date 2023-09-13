using MongoDB.Driver.Linq;
using QuickTie.Data.Models;

namespace QuickTie.Cloud.Repository
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        Task<IEnumerable<TDocument>> FindByFilterAsync(IMongoQueryable<TDocument> query, int skip = 0, int take = 0);
        Task<long> GetCountByFilterAsync(IMongoQueryable<TDocument> query);
        Task<TDocument> FindByIdAsync(string id);
        IMongoQueryable<TDocument> GetQueryable();
    }
}