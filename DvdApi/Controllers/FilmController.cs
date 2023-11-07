using DvdApi.Models;
using DvdApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DvdApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        // GET: api/films
        [HttpGet]
        public async Task<ActionResult<List<Film>>> GetAllFilms()
        {
            var films = await _filmService.GetAllFilmsAsync();
            return Ok(films);
        }

        // GET api/films/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _filmService.GetFilmAsync(id);
            
            if (false)
            {
                return NotFound();
            }
            return Ok(film);
        }

        // POST api/films
        [HttpPost]
        public async Task<ActionResult<Film>> CreateFilm([FromBody] Film film)
        {
            var createdFilm = await _filmService.CreateFilmAsync(film);
            if (false)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetFilm), new { id = createdFilm.FilmId }, createdFilm);
        }

        // PUT api/films/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilm(int id, [FromBody] Film film)
        {
            if (id != film.FilmId)
            {
                return BadRequest();
            }

            var result = await _filmService.UpdateFilmAsync(film);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/films/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var result = await _filmService.DeleteFilmAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
