using Microsoft.AspNetCore.Mvc;
using prodrentapi.repositories;

public class MyApiController : ControllerBase
{
    private readonly MongoDBHelper _mongoDBHelper;

    public MyApiController(MongoDBHelper mongoDBHelper)
    {
        _mongoDBHelper = mongoDBHelper;
    }

    [HttpPost("create-collection")]
    public async Task<IActionResult> CreateCollection(string collectionName)
    {
        try
        {
            await _mongoDBHelper.CreateCollectionAsync(collectionName);
            return Ok($"Coleção '{collectionName}' criada com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro ao criar a coleção.");
        }
    }
}
