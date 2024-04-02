using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prodrentapi.Models;
using prodrentapi.services;

namespace prodrentapi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService) =>
        _produtoService = produtoService;

    [HttpGet]
    public async Task<ActionResult<List<ProdutoModel>>> Get()
    {
        try{
            var produtos = await _produtoService.GetAsync();
            // return StatusCode(StatusCodes.Status200OK);
            return produtos;
        }
        catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoModel>> Get(String id)
    {
        try{
            var prod = await _produtoService.GetAsync(id);

            if (prod is null)
            {
                return NotFound();
            }

            return prod;
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post(ProdutoModel newProd)
    {
        try{
            await _produtoService.CreateAsync(newProd);

            return CreatedAtAction(nameof(Get), new { id = newProd.id }, newProd);
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(String id, ProdutoModel updatedProd)
    {
        try{
            var prod = await _produtoService.GetAsync(id);

            if (prod is null)
            {
                return NotFound();
            }

            updatedProd.id = prod.id;

            await _produtoService.UpdateAsync(id, updatedProd);

            return NoContent();
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(String id)
    {
        try{
            var prod = await _produtoService.GetAsync(id);

            if (prod is null)
            {
                return NotFound();
            }

            await _produtoService.RemoveAsync(id);

            return NoContent();
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }
}