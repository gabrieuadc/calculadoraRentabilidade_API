using MongoDB.Driver;
using prodrentapi.Models;
using Microsoft.Extensions.Options;
using prodrentapi.services;

namespace prodrentapi.services;

public class UsuarioService: IUsuarioService{



    private readonly IMongoCollection<UsuarioModel> _usuarioCollection;
    public UsuarioService(IOptions<MongoDBSettings> usuarioDBSettings){

        var mongoClient = new MongoClient(
            usuarioDBSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            usuarioDBSettings.Value.DatabaseName);

        _usuarioCollection = mongoDatabase.GetCollection<UsuarioModel>("Usuario");

    }

    public async Task<List<UsuarioModel>> GetAsync() =>
        await _usuarioCollection.Find(_ => true).ToListAsync();

    public async Task<UsuarioModel?> GetAsync(String id) =>
        await _usuarioCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(UsuarioModel newUser) =>
        await _usuarioCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(String id, UsuarioModel updatedUser) =>
        await _usuarioCollection.ReplaceOneAsync(x => x.id == id, updatedUser);

    public async Task RemoveAsync(String id) =>
        await _usuarioCollection.DeleteOneAsync(x => x.id == id);

    public async Task<UsuarioModel> AuthenticateAsync(string username, string passsword)
        {
            var user = await _usuarioCollection.Find(x => x.Nome == username && x.Senha == passsword).FirstOrDefaultAsync();

            // Console.WriteLine(user);
            if(user == null){
                return null;
            }
            
            // Console.WriteLine(user.ToString());
            return user;


        }


}