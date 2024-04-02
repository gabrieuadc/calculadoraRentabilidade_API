using Microsoft.AspNetCore.Mvc;
using prodrentapi.Models;
using prodrentapi.services;

namespace prodrentapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoOrigemController : ControllerBase
{
    private readonly ProdutoOrigemService _ProdutoOrigemService;

    public ProdutoOrigemController(ProdutoOrigemService ProdutoOrigemService) =>
        _ProdutoOrigemService = ProdutoOrigemService;

    [HttpGet]
    public async Task<ActionResult<List<ProdutoOrigemModel>>> Get()
    {
        var prodorigins = await _ProdutoOrigemService.GetAsync();
        return prodorigins;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoOrigemModel>> Get(String id)
    {
        try{
            var ProdutoOrigem = await _ProdutoOrigemService.GetAsync(id);

            if (ProdutoOrigem is null)
            {
                return NotFound();
            }

            return ProdutoOrigem;
        }catch(Exception ex){
                return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post(ProdutoOrigemModel newdestiny)
    {
        try{
            await _ProdutoOrigemService.CreateAsync(newdestiny);
            return CreatedAtAction(nameof(Get), new { id = newdestiny.id }, newdestiny);
        }catch(Exception ex){
                return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(String id, ProdutoOrigemModel updatedorigin)
    {
        try{
            var prodorigin = await _ProdutoOrigemService.GetAsync(id);

            if (prodorigin is null)
            {
                return NotFound();
            }

            updatedorigin.id = prodorigin.id;

            await _ProdutoOrigemService.UpdateAsync(id, updatedorigin);

            return NoContent();
        }catch(Exception ex){
                return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(String id)
    {
        try{
            var origin = await _ProdutoOrigemService.GetAsync(id);

            if (origin is null)
            {
                return NotFound();
            }

            await _ProdutoOrigemService.RemoveAsync(id);

            return NoContent();
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }
}