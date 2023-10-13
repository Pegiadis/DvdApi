using DvdApi.Models;
using DvdApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly ActorService _actorService;

    public ActorController()
    {
        _actorService = new ActorService();
    }

    // GET: api/actors
    [HttpGet]
    public async Task<ActionResult<List<Actor>>> GetActors()
    {
        return Ok(await _actorService.GetAllActorsAsync());
    }

    // GET api/actors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Actor>> GetActor(int id)
    {
        var actor = await _actorService.GetActorByIdAsync(id);
        if (actor == null)
        {
            return NotFound();
        }
        return Ok(actor);
    }
}