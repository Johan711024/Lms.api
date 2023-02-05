using Lms.Data;
using Lms.Data.Data;

namespace Lms.api.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<LmsapiContext>();
                try
                {
                    await SeedData.InitAsync(db, serviceProvider);
                }
                catch (Exception e)
                {
                    throw;
                }

            }
        }
    }
}
