using Microsoft.AspNetCore.Mvc;
using prodrentapi.Models;
using prodrentapi.services;

namespace prodrentapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService) =>
        _usuarioService = usuarioService;

    [HttpGet]
    public async Task<List<UsuarioModel>> Get() =>
        await _usuarioService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel>> Get(String id)
    {
        var user = await _usuarioService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UsuarioModel newUser)
    {
        await _usuarioService.CreateAsync(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.id }, newUser);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(String id, UsuarioModel updatedUser)
    {
        var user = await _usuarioService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        updatedUser.id = user.id;

        await _usuarioService.UpdateAsync(id, updatedUser);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(String id)
    {
        var user = await _usuarioService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        await _usuarioService.RemoveAsync(id);

        return NoContent();
    }
}