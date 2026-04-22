
using ContactManagement.API.Middleware;
using ContactManagement.API.Services;

namespace ContactManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

         

            // Add services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Contact API", Version = "v1" });
            });
            // Dependency Injection
            builder.Services.AddSingleton<IContactService, ContactService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // Middleware pipeline
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();   // Serves the JSON spec
            app.UseSwaggerUI(); // Serves the interactive UI

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
