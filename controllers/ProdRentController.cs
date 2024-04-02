using Microsoft.AspNetCore.Mvc;
using prodrentapi.Models;
using prodrentapi.services;

namespace prodrentapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoRentabilidadeController : ControllerBase
{
    private readonly ProdutoRentabilidadeService _ProdutoRentabilidadeService;

    public ProdutoRentabilidadeController(ProdutoRentabilidadeService ProdutoRentabilidadeService) =>
        _ProdutoRentabilidadeService = ProdutoRentabilidadeService;

    [HttpGet]
    public async Task<ActionResult<List<ProdutoRentabilidadeModel>>> Get()
    {
        try{
            
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }
        var profitabilitys = await _ProdutoRentabilidadeService.GetAsync();
        return profitabilitys;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoRentabilidadeModel>> Get(String id)
    {
                
        try{
            var ProdutoRentabilidade = await _ProdutoRentabilidadeService.GetAsync(id);

            if (ProdutoRentabilidade is null)
            {
                return NotFound();
            }

            return ProdutoRentabilidade;
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post(ProdutoRentabilidadeModel newdestiny)
    {
        try{
            await _ProdutoRentabilidadeService.CreateAsync(newdestiny);

            return CreatedAtAction(nameof(Get), new { id = newdestiny.id }, newdestiny);
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(String id, ProdutoRentabilidadeModel updatedprofitability)
    {
        try{
            var profitability = await _ProdutoRentabilidadeService.GetAsync(id);

            if (profitability is null)
            {
                return NotFound();
            }

            updatedprofitability.id = profitability.id;

            await _ProdutoRentabilidadeService.UpdateAsync(id, updatedprofitability);

        return NoContent();
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(String id)
    {
        try{
            var profitability = await _ProdutoRentabilidadeService.GetAsync(id);

            if (profitability is null)
            {
                return NotFound();
            }

            await _ProdutoRentabilidadeService.RemoveAsync(id);

            return NoContent();
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }
}