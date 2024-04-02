using Microsoft.Extensions.Options;
using MongoDB.Driver;
using prodrentapi.Models;

namespace prodrentapi.services;

public class ProdutoRentabilidadeService
{
    private readonly IMongoCollection<ProdutoRentabilidadeModel> _ProdutoRentabilidadeCollection;

    public ProdutoRentabilidadeService(
        IOptions<MongoDBSettings> ProdutoRentabilidadeDBSettings)
    {
        var mongoClient = new MongoClient(
            ProdutoRentabilidadeDBSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            ProdutoRentabilidadeDBSettings.Value.DatabaseName);

        _ProdutoRentabilidadeCollection = mongoDatabase.GetCollection<ProdutoRentabilidadeModel>("ProdutoRentabilidade");
    }

    public async Task<List<ProdutoRentabilidadeModel>> GetAsync() =>
        await _ProdutoRentabilidadeCollection.Find(_ => true).ToListAsync();

    public async Task<ProdutoRentabilidadeModel?> GetAsync(String id) =>
        await _ProdutoRentabilidadeCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ProdutoRentabilidadeModel newProdutoRentabilidade) =>
        await _ProdutoRentabilidadeCollection.InsertOneAsync(newProdutoRentabilidade);

    public async Task UpdateAsync(String id, ProdutoRentabilidadeModel updatedProdutoRentabilidade) =>
        await _ProdutoRentabilidadeCollection.ReplaceOneAsync(x => x.id == id, updatedProdutoRentabilidade);

    public async Task RemoveAsync(String id) =>
        await _ProdutoRentabilidadeCollection.DeleteOneAsync(x => x.id == id);
}