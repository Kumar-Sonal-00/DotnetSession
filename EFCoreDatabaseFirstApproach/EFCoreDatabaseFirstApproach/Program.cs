
using EFCoreDatabaseFirstApproach.BusinessLayer;
using EFCoreDatabaseFirstApproach.DataAccessLayer;
using EFCoreDatabaseFirstApproach.Models;
using EFCoreDatabaseFirstApproach.RepositoryLayer;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstApproach
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

            //configure dependecny injection for DbContext and conectionstring configuration
            builder.Services.AddDbContext<EmpDbContext>(options =>
            {
                var conStr=builder.Configuration.GetConnectionString("constr");
                options.UseSqlServer(conStr);
            });

            //configure the dependency injection for all the components
            builder.Services.AddScoped<IEmpDataAccessLayer,EmpDataAccessLayer>();
            builder.Services.AddScoped<IEmpRepositoryLayer, EmpRepositoryLayer>();
            builder.Services.AddScoped<IEmpBusinessLayer, EmpBusinessLayer>();

            //add the Global Exception Middleware
            builder.Services.AddSingleton<GlobalExceptionHandler>();
          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.MapControllers();

            app.Run();
        }
    }
}
