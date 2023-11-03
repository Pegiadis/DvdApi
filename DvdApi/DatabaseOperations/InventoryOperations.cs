using Npgsql;
using DvdApi.Models;

namespace DvdApi.DatabaseOperations
{
    public class InventoryOperations
    {
        private readonly string? _connectionString;

        public InventoryOperations()
        {
            _connectionString = DatabaseConnection.GetConnectionString();
        }

        public async Task<List<Inventory>> GetAllInventoryAsync()
        {
            var inventory = new List<Inventory>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                   var command = new NpgsqlCommand("SELECT * FROM public.inventory", connection);

                   using (var reader = await command.ExecuteReaderAsync())
                   {
                       while (await reader.ReadAsync())
                       {
                        inventory.Add(new Inventory
                        {
                            InventoryId = reader.GetInt32(reader.GetOrdinal("inventory_id")),
                            FilmId = reader.GetInt32(reader.GetOrdinal("film_id")),
                            StoreId = reader.GetInt32(reader.GetOrdinal("store_id")),
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update"))
                        });
                    }
                }
            }

            return inventory;
            
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM public.inventory WHERE inventory_id = @id";

                var command = new NpgsqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Inventory
                        {
                            InventoryId = reader.GetInt32(reader.GetOrdinal("inventory_id")),
                            FilmId = reader.GetInt32(reader.GetOrdinal("film_id")),
                            StoreId = reader.GetInt32(reader.GetOrdinal("store_id")),
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update"))
                        };
                    }
                }
            }

            return null;
        }


        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO public.inventory (film_id, store_id, last_update) VALUES (@film_id, @store_id, @last_update) RETURNING inventory_id";

                var command = new NpgsqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@id", inventory.InventoryId);
                command.Parameters.AddWithValue("@film_id", inventory.FilmId);
                command.Parameters.AddWithValue("@store_id", inventory.StoreId);
                command.Parameters.AddWithValue("@last_update", inventory.LastUpdate);

                var id = (int)await command.ExecuteScalarAsync();

                inventory.InventoryId = id;

                return inventory;
            }
        }


        public async Task<Inventory> UpdateInventoryAsync(Inventory inventory)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE public.inventory SET film_id = @film_id, store_id = @store_id, last_update = @last_update WHERE inventory_id = @id";

                var command = new NpgsqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", inventory.InventoryId);
                command.Parameters.AddWithValue("@film_id", inventory.FilmId);
                command.Parameters.AddWithValue("@store_id", inventory.StoreId);
                command.Parameters.AddWithValue("@last_update", inventory.LastUpdate);

                await command.ExecuteNonQueryAsync();

                return inventory;
            }
        }


        public async Task<bool> DeleteInventoryAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM public.inventory WHERE inventory_id = @id";

                var command = new NpgsqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                var affectedRows = await command.ExecuteNonQueryAsync();
                return affectedRows > 0;
            }
        }

    }
}