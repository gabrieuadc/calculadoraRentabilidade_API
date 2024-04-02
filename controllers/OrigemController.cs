using Microsoft.AspNetCore.Mvc;
using prodrentapi.Models;
using prodrentapi.services;

namespace prodrentapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrigemController : ControllerBase
{
    private readonly OrigemService _OrigemService;

    public OrigemController(OrigemService origemService) =>
        _OrigemService = origemService;

    [HttpGet]
    public async Task<ActionResult<List<OrigemModel>>> Get()
    {
        try{
            var origins = await _OrigemService.GetAsync();
            return origins;
        }
        catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrigemModel>> Get(String id)
    {
        try{
            var origem = await _OrigemService.GetAsync(id);

            if (origem is null)
            {
                return NotFound();
            }

            return origem;
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post(OrigemModel newProd)
    {
        try{
            await _OrigemService.CreateAsync(newProd);
            return CreatedAtAction(nameof(Get), new { id = newProd.id }, newProd);
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(String id, OrigemModel updatedOrigin)
    {
        try{
            var origin = await _OrigemService.GetAsync(id);

            if (origin is null)
            {
                return NotFound();
            }

            updatedOrigin.id = origin.id;

            await _OrigemService.UpdateAsync(id, updatedOrigin);

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
            var origin = await _OrigemService.GetAsync(id);

            if (origin is null)
            {
                return NotFound();
            }

            await _OrigemService.RemoveAsync(id);

            return NoContent();

        }
        catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }
}