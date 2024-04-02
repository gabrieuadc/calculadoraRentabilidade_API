using Microsoft.Extensions.Options;
using MongoDB.Driver;
using prodrentapi.Models;

namespace prodrentapi.services;

public class ProdutoOrigemService
{
    private readonly IMongoCollection<ProdutoOrigemModel> _ProdutoOrigemCollection;

    public ProdutoOrigemService(
        IOptions<MongoDBSettings> ProdutoOrigemDBSettings)
    {
        var mongoClient = new MongoClient(
            ProdutoOrigemDBSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            ProdutoOrigemDBSettings.Value.DatabaseName);

        _ProdutoOrigemCollection = mongoDatabase.GetCollection<ProdutoOrigemModel>("ProdutoOrigem");
    }

    public async Task<List<ProdutoOrigemModel>> GetAsync() =>
        await _ProdutoOrigemCollection.Find(_ => true).ToListAsync();

    public async Task<ProdutoOrigemModel?> GetAsync(String id) =>
        await _ProdutoOrigemCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ProdutoOrigemModel newProdutoOrigem) =>
        await _ProdutoOrigemCollection.InsertOneAsync(newProdutoOrigem);

    public async Task UpdateAsync(String id, ProdutoOrigemModel updatedProdutoOrigem) =>
        await _ProdutoOrigemCollection.ReplaceOneAsync(x => x.id == id, updatedProdutoOrigem);

    public async Task RemoveAsync(String id) =>
        await _ProdutoOrigemCollection.DeleteOneAsync(x => x.id == id);
}