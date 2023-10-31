
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DvdApi
{
    public static class DatabaseConnection
    {
        public static string? GetConnectionString()
        {
            // Build configuration
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Directory where the json files are located
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            // Retrieve connection string from appsettings.json
            string? connectionStringTemplate = configurationRoot.GetConnectionString("PostgreSqlConnection");

            // Get password from environment variable
            string? password = Environment.GetEnvironmentVariable("DB_DVD");

            if (connectionStringTemplate != null && password != null)
            {
                // Replace the placeholder with the actual password
                return connectionStringTemplate.Replace("{password}", password);
            }
            else
            {
                // Handle the case where either the connection string or password is missing.
                // You can throw an exception, return null, or handle it in another way depending on your application needs.
                throw new InvalidOperationException("Connection string or password is missing.");
            }
        }
    }
}


