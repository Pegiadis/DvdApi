using System.Security.Cryptography.X509Certificates;
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


        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = new Customer();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("SELECT * FROM public.customer WHERE customer_id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        customer = new Customer
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
                        };
                    }
                }
            }

            return customer;

        }

        public async Task<Customer> AddCustomerAsync(Customer customer1)
        {
            var customer = new Customer();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("INSERT INTO public.customer (store_id, first_name, last_name, email, address_id, activebool, create_date, last_update, active) VALUES (@store_id, @first_name, @last_name, @email, @address_id, @activebool, @create_date, @last_update, @active)",
                    connection);
                command.Parameters.AddWithValue("store_id", customer.StoreId);
                command.Parameters.AddWithValue("first_name", customer.FirstName);
                command.Parameters.AddWithValue("last_name", customer.LastName);
                command.Parameters.AddWithValue("email", customer.Email);
                command.Parameters.AddWithValue("address_id", customer.AddressId);
                command.Parameters.AddWithValue("activebool", customer.Activebool);
                command.Parameters.AddWithValue("create_date", customer.CreateDate);
                command.Parameters.AddWithValue("last_update", customer.LastUpdate);
                command.Parameters.AddWithValue("active", customer.Active);

                await command.ExecuteNonQueryAsync();
            }

            return customer;
        }


        public async Task<Customer> UpdateCustomerAsync(Customer customer1)
        {
            var customer = new Customer();

            using (var connection = new NpgsqlConnection(connectionString))

            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("UPDATE public.customer SET store_id = @store_id, first_name = @first_name, last_name = @last_name, email = @email,"
                                                + "address_id = @address_id, activebool = @activebool, create_date = @create_date, last_update = @last_update, active = @active WHERE customer_id = @id",
                    connection);
                command.Parameters.AddWithValue("id", customer.CustomerId);
                command.Parameters.AddWithValue("store_id", customer.StoreId);
                command.Parameters.AddWithValue("first_name", customer.FirstName);
                command.Parameters.AddWithValue("last_name", customer.LastName);
                command.Parameters.AddWithValue("email", customer.Email);
                command.Parameters.AddWithValue("address_id", customer.AddressId);
                command.Parameters.AddWithValue("activebool", customer.Activebool);
                command.Parameters.AddWithValue("create_date", customer.CreateDate);
                command.Parameters.AddWithValue("last_update", customer.LastUpdate);
                command.Parameters.AddWithValue("active", customer.Active);

                await command.ExecuteNonQueryAsync();
            }

            return customer;
        }


        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var customer = new Customer();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("DELETE FROM public.customer WHERE customer_id = @id", connection);
                command.Parameters.AddWithValue("id", customer.CustomerId);

                await command.ExecuteNonQueryAsync();
            }

            return customer;
        }




    }
}
