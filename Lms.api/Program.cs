using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lms.Data.Data;
using Lms.api.Extensions;
using Lms.Core.Repositories;
using Lms.Data.Repositories;

namespace Lms.api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LmsapiContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LmsapiContext") ?? throw new InvalidOperationException("Connection string 'LmsapiContext' not found.")));

            // Add services to the container.

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddControllers(opt => opt.ReturnHttpNotAcceptable = true)
                .AddNewtonsoftJson()
                .AddXmlDataContractSerializerFormatters();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            

            builder.Services.AddAutoMapper(typeof(MapperProfile));


            var app = builder.Build();

            await app.SeedDataAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            // CORS - Allow calling the API from WebBrowsers
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
                .SetIsOriginAllowed(origin => true));// Allow any origin  

            app.Run();
        }
    }
}