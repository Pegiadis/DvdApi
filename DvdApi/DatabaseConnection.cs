namespace DvdApi;

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
        return configurationRoot.GetConnectionString("PostgreSqlConnection");
    }
}