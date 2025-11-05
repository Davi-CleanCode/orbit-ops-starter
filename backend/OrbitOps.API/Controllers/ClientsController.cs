
using Microsoft.AspNetCore.Mvc;
using OrbitOps.API.Services;
using OrbitOps.API.Models;

namespace OrbitOps.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _svc;
    public ClientsController(IClientService svc) { _svc = svc; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _svc.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) 
    {
        var c = await _svc.GetByIdAsync(id);
        if (c == null) return NotFound();
        return Ok(c);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Client client)
    {
        var created = await _svc.CreateAsync(client);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ok = await _svc.DeleteAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}
