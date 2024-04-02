using prodrentapi.Models;

namespace prodrentapi.services;
    public interface IProdutoService
    {
        Task<List<ProdutoModel>> GetAsync();
        Task<ProdutoModel?> GetAsync(string id);
        Task CreateAsync(ProdutoModel newProd);
        Task UpdateAsync(string id, ProdutoModel updatedProd);
        Task RemoveAsync(string id);
    }