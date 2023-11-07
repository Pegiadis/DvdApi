using Npgsql;
using DvdApi.Models;

namespace DvdApi.DatabaseOperations
{
    public class StaffOperations
    {
        private readonly string connectionString;

        public StaffOperations()
        {
            connectionString = DatabaseConnection.GetConnectionString();
        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            var staff = new List<Staff>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                   var command = new NpgsqlCommand("SELECT * FROM public.staff", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        staff.Add(new Staff
                        {
                            StaffId = reader.GetInt32(reader.GetOrdinal("staff_id")),
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            AddressId = reader.GetInt32(reader.GetOrdinal("address_id")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            StoreId = reader.GetInt32(reader.GetOrdinal("store_id")),
                            Active = reader.GetBoolean(reader.GetOrdinal("active")),
                            Username = reader.GetString(reader.GetOrdinal("username")),
                            Password = reader.GetString(reader.GetOrdinal("password")),
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update"))
                        });
                    }
                }
            }

            return staff;
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            var staff = new Staff();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("SELECT * FROM public.staff WHERE staff_id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        staff = new Staff
                        {
                            StaffId = reader.GetInt32(reader.GetOrdinal("staff_id")),
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            AddressId = reader.GetInt32(reader.GetOrdinal("address_id")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            StoreId = reader.GetInt32(reader.GetOrdinal("store_id")),
                            Active = reader.GetBoolean(reader.GetOrdinal("active")),
                            Username = reader.GetString(reader.GetOrdinal("username")),
                            Password = reader.GetString(reader.GetOrdinal("password")),
                            LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update"))
                        };
                    }
                }
            }

            return staff;
        }


        public async Task<Staff> AddStaffAsync(Staff staff)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("INSERT INTO public.staff (first_name, last_name, address_id, email, store_id, active, username, password, last_update) VALUES (@first_name, @last_name, @address_id, @email, @store_id, @active, @username, @password, @last_update)");
                command.Parameters.AddWithValue("first_name", staff.FirstName);
                command.Parameters.AddWithValue("last_name", staff.LastName);
                command.Parameters.AddWithValue("address_id", staff.AddressId);
                command.Parameters.AddWithValue("email", staff.Email);
                command.Parameters.AddWithValue("store_id", staff.StoreId);
                command.Parameters.AddWithValue("active", staff.Active);
                command.Parameters.AddWithValue("username", staff.Username);
                command.Parameters.AddWithValue("password", staff.Password);
                command.Parameters.AddWithValue("last_update", staff.LastUpdate);

                await command.ExecuteNonQueryAsync();
            }

            return staff;
        }

        public async Task<Staff> UpdateStaffAsync(int id, Staff staff)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("UPDATE public.staff SET first_name = @first_name, last_name = @last_name, address_id = @address_id, email = @email, store_id = @store_id, active = @active, username = @username, password = @password");
                command.Parameters.AddWithValue("first_name", staff.FirstName);
                command.Parameters.AddWithValue("last_name", staff.LastName);
                command.Parameters.AddWithValue("address_id", staff.AddressId);
                command.Parameters.AddWithValue("email", staff.Email);
                command.Parameters.AddWithValue("store_id", staff.StoreId);
                command.Parameters.AddWithValue("active", staff.Active);
                command.Parameters.AddWithValue("username", staff.Username);
                command.Parameters.AddWithValue("password", staff.Password);
                command.Parameters.AddWithValue("last_update", staff.LastUpdate);

                await command.ExecuteNonQueryAsync();
            }

            return staff;
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("DELETE FROM public.staff WHERE staff_id = @id");
                command.Parameters.AddWithValue("id", id);

                var affectedRows = await command.ExecuteNonQueryAsync();
                return affectedRows > 0;
            }
        }

    }
}
