using prodrentapi.Models;

namespace prodrentapi.services;
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetAsync();
        Task<UsuarioModel?> GetAsync(string id);
        Task CreateAsync(UsuarioModel newUser);
        Task UpdateAsync(string id, UsuarioModel updatedUser);
        Task RemoveAsync(string id);

        Task <UsuarioModel> AuthenticateAsync(string username, string email);
    }