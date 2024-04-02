using Microsoft.Extensions.Options;
using MongoDB.Driver;
using prodrentapi.Models;

namespace prodrentapi.services;

public class ProdutoService: IProdutoService
{
    private readonly IMongoCollection<ProdutoModel> _produtoCollection;

    public ProdutoService(
        IOptions<MongoDBSettings> produtoDBSettings)
    {
        var mongoClient = new MongoClient(
            produtoDBSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            produtoDBSettings.Value.DatabaseName);

        _produtoCollection = mongoDatabase.GetCollection<ProdutoModel>("Produto");
    }

    public async Task<List<ProdutoModel>> GetAsync() =>
        await _produtoCollection.Find(_ => true).ToListAsync();

    public async Task<ProdutoModel?> GetAsync(String id) =>
        await _produtoCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ProdutoModel newProd) =>
        await _produtoCollection.InsertOneAsync(newProd);

    public async Task UpdateAsync(String id, ProdutoModel updatedProd) =>
        await _produtoCollection.ReplaceOneAsync(x => x.id == id, updatedProd);

    public async Task RemoveAsync(String id) =>
        await _produtoCollection.DeleteOneAsync(x => x.id == id);
}