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
    }
}
