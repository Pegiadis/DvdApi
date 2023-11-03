using DvdApi.DatabaseOperations;
using DvdApi.Services;
using Microsoft.OpenApi.Models;

namespace DvdApi
{
    public static class Program
    {
        // Main method
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            RegisterServices(builder.Services);
            ConfigureSwagger(builder.Services);

            var app = builder.Build();

            ConfigureApp(app);

            app.Run();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Register Controllers
            services.AddControllers();

            // Inventory
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<InventoryOperations>();

            // Staff
            services.AddScoped<IStaffService,StaffService>();
            services.AddScoped<StaffOperations>();

            // Customer
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<CustomerOperations>();

            // Film
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<FilmOperations>();

            // Actor
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ActorOperations>();
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
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
        }

        private static void ConfigureApp(WebApplication app)
        {
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
        }
    }
}
