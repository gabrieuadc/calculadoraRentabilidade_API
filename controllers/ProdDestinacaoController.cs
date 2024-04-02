using Microsoft.AspNetCore.Mvc;
using prodrentapi.Models;
using prodrentapi.services;

namespace prodrentapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoDestinacaoController : ControllerBase
{
    private readonly ProdutoDestinacaoService _ProdutoDestinacaoService;

    public ProdutoDestinacaoController(ProdutoDestinacaoService ProdutoDestinacaoService) =>
        _ProdutoDestinacaoService = ProdutoDestinacaoService;

    [HttpGet]
    public async Task<ActionResult<List<ProdutoDestinacaoModel>>> Get()
    {
        try{

        }        
        catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }
        var destinations = await _ProdutoDestinacaoService.GetAsync();
        return destinations;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoDestinacaoModel>> Get(String id)
    {        
        try{
            var ProdutoDestinacao = await _ProdutoDestinacaoService.GetAsync(id);

            if (ProdutoDestinacao is null)
            {
                return NotFound();
            }

            return ProdutoDestinacao;
        }        
        catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post(ProdutoDestinacaoModel newdestiny)
    {        
        try{
            await _ProdutoDestinacaoService.CreateAsync(newdestiny);

            return CreatedAtAction(nameof(Get), new { id = newdestiny.id }, newdestiny);
        }        
        catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(String id, ProdutoDestinacaoModel updateddestiny)
    {
                
        try{
            var destiny = await _ProdutoDestinacaoService.GetAsync(id);

            if (destiny is null)
            {
                return NotFound();
            }

            updateddestiny.id = destiny.id;

            await _ProdutoDestinacaoService.UpdateAsync(id, updateddestiny);

            return NoContent();
        }        
        catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(String id)
    {        
        try{
            var destiny = await _ProdutoDestinacaoService.GetAsync(id);

            if (destiny is null)
            {
                return NotFound();
            }

            await _ProdutoDestinacaoService.RemoveAsync(id);

            return NoContent();
        }        
        catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }
}