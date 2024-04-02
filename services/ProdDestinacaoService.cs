using Microsoft.Extensions.Options;
using MongoDB.Driver;
using prodrentapi.Models;

namespace prodrentapi.services;

public class ProdutoDestinacaoService
{
    private readonly IMongoCollection<ProdutoDestinacaoModel> _ProdutoDestinacaoCollection;

    public ProdutoDestinacaoService(
        IOptions<MongoDBSettings> ProdutoDestinacaoDBSettings)
    {
        var mongoClient = new MongoClient(
            ProdutoDestinacaoDBSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            ProdutoDestinacaoDBSettings.Value.DatabaseName);

        _ProdutoDestinacaoCollection = mongoDatabase.GetCollection<ProdutoDestinacaoModel>("ProdutoDestinacao");
    }

    public async Task<List<ProdutoDestinacaoModel>> GetAsync() =>
        await _ProdutoDestinacaoCollection.Find(_ => true).ToListAsync();

    public async Task<ProdutoDestinacaoModel?> GetAsync(String id) =>
        await _ProdutoDestinacaoCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ProdutoDestinacaoModel newProdutoDestinacao) =>
        await _ProdutoDestinacaoCollection.InsertOneAsync(newProdutoDestinacao);

    public async Task UpdateAsync(String id, ProdutoDestinacaoModel updatedProdutoDestinacao) =>
        await _ProdutoDestinacaoCollection.ReplaceOneAsync(x => x.id == id, updatedProdutoDestinacao);

    public async Task RemoveAsync(String id) =>
        await _ProdutoDestinacaoCollection.DeleteOneAsync(x => x.id == id);
}