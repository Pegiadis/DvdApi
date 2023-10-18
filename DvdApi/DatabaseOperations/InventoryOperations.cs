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

    }
}