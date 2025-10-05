using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Web.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectionServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(connectionString));

            return services;
        }
    }
}
