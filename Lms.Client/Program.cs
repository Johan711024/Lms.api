using System.Net.Http.Headers;
using Lms.Client.Clients;

namespace Lms.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            


            builder.Services.AddControllersWithViews();

            //1.
            builder.Services.AddHttpClient();

            //2
            builder.Services.AddHttpClient("CodeEventsClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7255/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });


            builder.Services.AddHttpClient("SomeOtherClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7255");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            //3

            builder.Services.AddHttpClient<IGameClient, GameClient>();
            //    (client =>
            //{
            //    client.BaseAddress = new Uri("");
            //});

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}