using Microsoft.AspNetCore.Mvc;
using prodrentapi.Models;
using prodrentapi.services;

namespace prodrentapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DestinacaoController : ControllerBase
{
    private readonly DestinacaoService _DestinacaoService;

    public DestinacaoController(DestinacaoService DestinacaoService) =>
        _DestinacaoService = DestinacaoService;

    [HttpGet]
    public async Task<ActionResult<List<DestinacaoModel>>> Get()
    {
        try{
            var destinations = await _DestinacaoService.GetAsync();
            return destinations;
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DestinacaoModel>> Get(String id)
    {
        try{
            var Destinacao = await _DestinacaoService.GetAsync(id);

            if (Destinacao is null)
            {
                return NotFound();
            }

            return Destinacao;
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post(DestinacaoModel newdestiny)
    {
        try{
            await _DestinacaoService.CreateAsync(newdestiny);

            return CreatedAtAction(nameof(Get), new { id = newdestiny.id }, newdestiny);
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(String id, DestinacaoModel updateddestiny)
    {
        try{
            var destiny = await _DestinacaoService.GetAsync(id);

            if (destiny is null)
            {
                return NotFound();
            }

            updateddestiny.id = destiny.id;

            await _DestinacaoService.UpdateAsync(id, updateddestiny);

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
            var destiny = await _DestinacaoService.GetAsync(id);

            if (destiny is null)
            {
                return NotFound();
            }

            await _DestinacaoService.RemoveAsync(id);

            return NoContent();
        }
        catch(Exception ex){
            return StatusCode(StatusCodes.Status502BadGateway,$"Error:{ex.Message}");
        }

    }
}