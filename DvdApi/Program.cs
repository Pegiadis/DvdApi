
using DvdApi.DatabaseOperations;
using DvdApi.Services;
using Microsoft.OpenApi.Models;


namespace DvdApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Register InventoryService and InventoryOperations for DI
            builder.Services.AddScoped<InventoryService>();
            builder.Services.AddScoped<InventoryOperations>();

            // Register StaffService and StaffOperations for DI
            builder.Services.AddScoped<StaffService>();
            builder.Services.AddScoped<StaffOperations>();


            // Register CustomerService and CustomerOperations for DI
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<CustomerOperations>();   


            // Register FilmService and FilmOperations for DI
            builder.Services.AddScoped<FilmService>();
            builder.Services.AddScoped<FilmOperations>();

            // Register ActorService and ActorOperations for DI
            builder.Services.AddScoped<ActorService>();
            builder.Services.AddScoped<ActorOperations>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Pegiadis",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/johndoe"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

            var app = builder.Build();

            // Configure the app to listen on the port provided by the environment variable
            var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            app.Urls.Add($"http://0.0.0.0:{port}");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

