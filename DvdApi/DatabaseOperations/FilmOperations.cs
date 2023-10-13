using DvdApi.Models;
using Npgsql;

namespace DvdApi.DatabaseOperations
{
    public class FilmOperations
    {
        private readonly string connectionString;

        public FilmOperations()
        {
            connectionString = DatabaseConnection.GetConnectionString();
        }

        // Example method to get all films
        public async Task<List<Film>> GetAllFilmsAsync()
        {
            var films = new List<Film>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("SELECT * FROM public.film", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        films.Add(new Film
                        {
                            FilmId = reader.GetInt32(reader.GetOrdinal("film_id")),
                            // Other properties
                            // ...
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update"))
                        });
                    }
                }
            }
             
            return films;
        }

        public async Task<Film> GetFilmAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM public.film WHERE film_id = @id";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Film
                        {
                            FilmId = reader.GetInt32(reader.GetOrdinal("film_id")),
                            // ... other fields
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update"))
                        };
                    }
                }
            }
            return null; // Return null if no film was found with the provided ID
        }

        public async Task<Film> AddFilmAsync(Film film)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                //string query = "INSERT INTO public.film (/* fields except film_id */) VALUES (/* @parameters */) RETURNING film_id";
                //var command = new NpgsqlCommand(query, connection);

                string query = "INSERT INTO public.film (title, description) VALUES (@title, @description)";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("title", film.Title);
                    command.Parameters.AddWithValue("description", film.Description);

                    // Execute the command
                    await command.ExecuteNonQueryAsync();
                }


                // Execute the query and get the ID of the newly inserted row
                //film.FilmId = (int)await command.ExecuteScalarAsync();
            }
            return film; // Return the film with the newly assigned ID
        }

        public async Task<bool> UpdateFilmAsync(Film film)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE public.film SET /* fields = @parameters, except film_id */ WHERE film_id = @id";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", film.FilmId);

                // Add command.Parameters.AddWithValue() for each field to be updated
                // ...

                var affectedRows = await command.ExecuteNonQueryAsync();
                return affectedRows > 0; // Return true if the update was successful
            }
        }

        public async Task<bool> DeleteFilmAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM public.film WHERE film_id = @id";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                var affectedRows = await command.ExecuteNonQueryAsync();
                return affectedRows > 0; // Return true if the delete was successful
            }
        }
    }
}
