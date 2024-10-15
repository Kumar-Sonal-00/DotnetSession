
using EFCodeCodeFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeCodeFirstApproach
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configure DbContext and connection string
            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                var conStr = builder.Configuration.GetConnectionString("conStr");
                options.UseSqlServer(conStr);
            });

            var app = builder.Build();

            //run the database migrations
            using (var scope=app.Services.CreateScope())
            {
                scope.ServiceProvider.GetService<ProductDbContext>().Database.Migrate();
            }

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
