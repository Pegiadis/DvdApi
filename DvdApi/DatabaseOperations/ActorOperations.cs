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

        internal Task<bool> AddActorAsync(Actor actor)
        {
            throw new NotImplementedException();
        }

        internal Task<bool> DeleteActorAsync(int id)
        {
            throw new NotImplementedException();
        }

        internal Task<Actor> GetActorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        internal Task<bool> UpdateActorAsync(Actor actor)
        {
            throw new NotImplementedException();
        }

        // Similar methods for other operations (Create, Update, Delete, etc.) and for the 'Film' entity
    }

}
