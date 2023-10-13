using DvdApi.Models;
using DvdApi.DatabaseOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DvdApi.Services
{
    public class FilmService
    {
        private readonly FilmOperations _filmOperations;

        public FilmService(FilmOperations filmOperations)
        {
            _filmOperations = filmOperations;
        }

        public Task<List<Film>> GetAllFilmsAsync()
        {
            // You can add business logic here if needed
            return _filmOperations.GetAllFilmsAsync();
        }

        // Add other methods corresponding to CRUD operations here
        // ...
    }
}