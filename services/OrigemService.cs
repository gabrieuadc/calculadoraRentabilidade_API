using Microsoft.Extensions.Options;
using MongoDB.Driver;
using prodrentapi.Models;

namespace prodrentapi.services;

public class OrigemService
{
    private readonly IMongoCollection<OrigemModel> _OrigemCollection;

    public OrigemService(
        IOptions<MongoDBSettings> OrigemDBSettings)
    {
        var mongoClient = new MongoClient(
            OrigemDBSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            OrigemDBSettings.Value.DatabaseName);

        _OrigemCollection = mongoDatabase.GetCollection<OrigemModel>("Origem");
    }

    public async Task<List<OrigemModel>> GetAsync() =>
        await _OrigemCollection.Find(_ => true).ToListAsync();

    public async Task<OrigemModel?> GetAsync(String id) =>
        await _OrigemCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(OrigemModel newOrigem) =>
        await _OrigemCollection.InsertOneAsync(newOrigem);

    public async Task UpdateAsync(String id, OrigemModel updatedOrigem) =>
        await _OrigemCollection.ReplaceOneAsync(x => x.id == id, updatedOrigem);

    public async Task RemoveAsync(String id) =>
        await _OrigemCollection.DeleteOneAsync(x => x.id == id);
}