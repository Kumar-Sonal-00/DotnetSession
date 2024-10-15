
using EmployeeServiceAPI.Repository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EmployeeServiceAPI
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

            builder.Services.AddDbContext<EmpDbContext>(options =>
            {
                var conStr = builder.Configuration.GetConnectionString("conStr");
                options.UseSqlServer(conStr);
            });

            builder.Services.AddDbContext<UserDbContext>(options =>
            {
                var conStr = builder.Configuration.GetConnectionString("conStr");
                options.UseSqlServer(conStr);
            });

            builder.Services.AddScoped<IEmpDataAccessLayer,EmpDataAccessLayer>();

            //add the jwt beared token authentication middleware
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey=new SymmetricSecurityKey(key)
                };                
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("clients-allowed", opt =>
                {
                    opt.AllowAnyMethod();
                    opt.AllowAnyHeader();
                    opt.AllowAnyOrigin();
                });
            });


            


            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetService<EmpDbContext>().Database.Migrate();
                scope.ServiceProvider.GetService<UserDbContext>().Database.Migrate();

                var context = app.Services.GetService<EmpDbContext>();
                context.Database.Migrate();
                var context2 = app.Services.GetService<UserDbContext>();
                context2.Database.Migrate();
            }
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
                app.UseSwaggerUI();
            //}

            //use the authentication before authorization- imp
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("clients-allowed");
            app.Run();
        }
    }
}
