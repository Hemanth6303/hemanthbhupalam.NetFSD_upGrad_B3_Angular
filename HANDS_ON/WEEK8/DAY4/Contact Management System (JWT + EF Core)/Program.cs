using Contact_Management_System__JWT___EF_Core_.Data;
using Contact_Management_System__JWT___EF_Core_.Repositories.Implementations;
using Contact_Management_System__JWT___EF_Core_.Repositories.Interfaces;
using Contact_Management_System__JWT___EF_Core_.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Contact_Management_System__JWT___EF_Core_.Services;

namespace Contact_Management_System__JWT___EF_Core_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controllers
            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DB
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // DI
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<JwtService>();

            // ✅ READ JWT FROM appsettings.json
            var jwtSettings = builder.Configuration.GetSection("Jwt");

            // JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings["Key"]))
                    };
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); // IMPORTANT: before Authorization
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}