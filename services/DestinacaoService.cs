using Microsoft.Extensions.Options;
using MongoDB.Driver;
using prodrentapi.Models;

namespace prodrentapi.services;

public class DestinacaoService
{
    private readonly IMongoCollection<DestinacaoModel> _DestinacaoCollection;

    public DestinacaoService(
        IOptions<MongoDBSettings> DestinacaoDBSettings)
    {
        var mongoClient = new MongoClient(
            DestinacaoDBSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            DestinacaoDBSettings.Value.DatabaseName);

        _DestinacaoCollection = mongoDatabase.GetCollection<DestinacaoModel>("Destinacao");
    }

    public async Task<List<DestinacaoModel>> GetAsync() =>
        await _DestinacaoCollection.Find(_ => true).ToListAsync();

    public async Task<DestinacaoModel?> GetAsync(String id) =>
        await _DestinacaoCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(DestinacaoModel newDestinacao) =>
        await _DestinacaoCollection.InsertOneAsync(newDestinacao);

    public async Task UpdateAsync(String id, DestinacaoModel updatedDestinacao) =>
        await _DestinacaoCollection.ReplaceOneAsync(x => x.id == id, updatedDestinacao);

    public async Task RemoveAsync(String id) =>
        await _DestinacaoCollection.DeleteOneAsync(x => x.id == id);
}