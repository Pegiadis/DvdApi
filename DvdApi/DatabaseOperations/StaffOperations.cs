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

    }
}
