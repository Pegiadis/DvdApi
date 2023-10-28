using DvdApi.Models;
using DvdApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DvdApi.Controllers
{
    [ApiController]
    [Route("dvd/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;  // Change ActorService to IActorService

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }


        // GET: api/actors
        [HttpGet]
        public async Task<ActionResult<List<Actor>>> GetActors()
        {
            return Ok(await _actorService.GetAllActorsAsync());
        }

        // GET api/actors/{id}
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

        // POST api/actors
        [HttpPost]
        public async Task<ActionResult<Actor>> CreateActor([FromBody] Actor actor)
        {
            var createdActor = await _actorService.AddActorAsync(actor);
            if (createdActor == null)
            {
                return BadRequest(); // or another more appropriate status code
            }

            return CreatedAtAction(nameof(GetActor), new { id = createdActor.ActorId }, createdActor);
        }


        // PUT api/actors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor(int id, [FromBody] Actor actor)
        {
            if (id != actor.ActorId)
            {
                return BadRequest();
            }

            var result = await _actorService.UpdateActorAsync(actor);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var result = await _actorService.DeleteActorAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
