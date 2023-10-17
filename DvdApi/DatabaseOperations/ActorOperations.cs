using DvdApi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DvdApi.DatabaseOperations
{

    public class ActorOperations
    {
        private readonly string connectionString;

        public ActorOperations()
        {
            connectionString = DatabaseConnection.GetConnectionString();
        }

        // Example method to get all actors
        public async Task<List<Actor>> GetAllActorsAsync()
        {
            var actors = new List<Actor>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("SELECT * FROM public.actor", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        actors.Add(new Actor
                        {
                            ActorId = reader.GetInt32(reader.GetOrdinal("actor_id")),
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update"))
                        });
                    }
                }
            }

            return actors;
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM public.actor WHERE actor_id = @id";

                var command = new NpgsqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Actor
                        {
                            ActorId = reader.GetInt32(reader.GetOrdinal("actor_id")),
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update"))
                        };
                    }
                }
            }

            return null; // Return null if no actor was found with the provided ID
        }

        public async Task<Actor> AddActorAsync(Actor actor)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                // Include the "RETURNING *" clause to retrieve the inserted record
                string query = "INSERT INTO public.actor (first_name, last_name, last_update) VALUES (@first_name, @last_name, @last_update) RETURNING *";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@first_name", actor.FirstName);
                command.Parameters.AddWithValue("@last_name", actor.LastName);
                command.Parameters.AddWithValue("@last_update", actor.LastUpdate);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        // Assuming actor_id is auto-incremented by the database and is fetched here
                        return new Actor
                        {
                            ActorId = reader.GetInt32(reader.GetOrdinal("actor_id")),
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update"))
                        };
                    }
                }
            }
            return null; // if no record was inserted, return null
        }


        public async Task<bool> UpdateActorAsync(Actor actor)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE public.actor SET first_name = @first_name, last_name = @last_name, last_update = @last_update WHERE actor_id = @id";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", actor.ActorId);
                command.Parameters.AddWithValue("@first_name", actor.FirstName);
                command.Parameters.AddWithValue("@last_name", actor.LastName);
                command.Parameters.AddWithValue("@last_update", actor.LastUpdate);

                var affectedRows = await command.ExecuteNonQueryAsync();
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteActorAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM public.actor WHERE actor_id = @id";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                var affectedRows = await command.ExecuteNonQueryAsync();
                return affectedRows > 0;
            }
        }
    }

}
