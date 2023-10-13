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
            _filmOperations = new FilmOperations(); // Consider dependency injection for this dependency.
        }

        public async Task<List<Film>> GetAllFilmsAsync()
        {
            try
            {
                return await _filmOperations.GetAllFilmsAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Consider how you want to handle exceptions - rethrow, return null, return a default value, etc.
                throw; // or handle differently according to your requirements
            }
        }

        public async Task<Film> GetFilmAsync(int id)
        {
            if (id <= 0)
            {
                // Log and handle the error appropriately
                // You might want to throw an exception or return null
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            try
            {
                return await _filmOperations.GetFilmAsync(id);
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                throw; // or handle differently
            }
        }

        public async Task<Film> CreateFilmAsync(Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            // You might want to add further validation here

            try
            {
                return await _filmOperations.AddFilmAsync(film);
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                throw; // or handle differently
            }
        }

        public async Task<bool> UpdateFilmAsync(Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            // Further validation

            try
            {
                return await _filmOperations.UpdateFilmAsync(film);
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                throw; // or handle differently
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
                // Log and handle the exception
                throw; // or handle differently
            }
        }
    }
}
