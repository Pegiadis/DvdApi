// FilmController.cs
using DvdApi.Models;
using DvdApi.Services; // Ensure this using statement is here
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DvdApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly FilmService _filmService; // Change to FilmService

        public FilmController(FilmService filmService) // Change to FilmService
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Film>>> GetAllFilms()
        {
            return await _filmService.GetAllFilmsAsync(); // Change to use FilmService
        }

        // Other action methods corresponding to CRUD operations
        // ...
    }
}