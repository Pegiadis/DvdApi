using DvdApi.Models;
using Npgsql;

namespace DvdApi.DatabaseOperations
{
    public class CustomerOperations
    {
        private readonly string connectionString;
        public CustomerOperations()
        {
            connectionString = DatabaseConnection.GetConnectionString();
        }

        // Get all customers
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var customers = new List<Customer>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("SELECT * FROM public.customer", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = reader.GetInt32(reader.GetOrdinal("customer_id")),
                            StoreId = reader.GetInt32(reader.GetOrdinal("store_id")),
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            AddressId = reader.GetInt32(reader.GetOrdinal("address_id")),
                            Activebool = reader.GetBoolean(reader.GetOrdinal("activebool")),
                            CreateDate = reader.GetDateTime(reader.GetOrdinal("create_date")),
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update")),
                            Active = reader.GetInt32(reader.GetOrdinal("active"))
                        });
                    }
                }
            }

            return customers;
        }

    }
}
