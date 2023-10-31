using DvdApi.DatabaseOperations;
using DvdApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DvdApi.Services
{
    public class FilmService
    {
        private readonly FilmOperations _filmOperations;

        public FilmService()
        {
            _filmOperations = new FilmOperations(); 
        }

        public async Task<List<Film>> GetAllFilmsAsync()
        {
            try
            {
                return await _filmOperations.GetAllFilmsAsync();
            }
            catch (Exception ex)
            {
                // Log the exception.
                throw;
            }
        }

        public async Task<Film> GetFilmAsync(int id)
        {
            if (id <= 0)
            {
                
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            try
            {
                return await _filmOperations.GetFilmAsync(id);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task<Film> CreateFilmAsync(Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            

            try
            {
                return await _filmOperations.AddFilmAsync(film);
            }
            catch (Exception ex)
            {
                
                throw; 
            }
        }

        public async Task<bool> UpdateFilmAsync(Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            

            try
            {
                return await _filmOperations.UpdateFilmAsync(film);
            }
            catch (Exception ex)
            {
                
                throw; 
            }
        }

        public async Task<bool> DeleteFilmAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            try
            {
                return await _filmOperations.DeleteFilmAsync(id);
            }
            catch (Exception ex)
            {
                
                throw; 
            }
        }
    }
}
