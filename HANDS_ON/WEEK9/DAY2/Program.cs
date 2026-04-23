
using ContactManagement.API.Performance.Repositories;
using ContactManagement.API.Performance.Services;
using Microsoft.AspNetCore.RateLimiting;

namespace ContactManagement.API.Performance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Dependency Injection
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IContactService, ContactService>();

            // Memory Cache
            builder.Services.AddMemoryCache();

            // Rate Limiting
            builder.Services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("fixed", opt =>
                {
                    opt.PermitLimit = 5;
                    opt.Window = TimeSpan.FromSeconds(60);
                    opt.QueueLimit = 0;
                });

                options.RejectionStatusCode = 429;
            });


            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            // Apply Rate Limiting
            app.UseRateLimiter();

            app.UseAuthorization();


            app.MapControllers().RequireRateLimiting("fixed"); // Apply to endpoints

            app.Run();
        }
    }
}
