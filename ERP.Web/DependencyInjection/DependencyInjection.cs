using ERP.BL.ServicesBL.InventoryBL;
using Microsoft.AspNetCore.Identity;

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

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<RolesSeedServicesBL>();
            builder.Services.AddScoped<UnitsSeedServicesBL>();
            builder.Services.AddScoped<CurrenciesSeedServicesBL>();
            builder.Services.AddScoped<PaymentMehodsSeedServicesBL>();

            builder.Services.AddScoped<ProductsServicesBL>();

            //Seeding
            builder.Services.AddScoped<DefaultRoles>();
            builder.Services.AddScoped<DefaultUnits>();
            builder.Services.AddScoped<DefaultCurrencies>();
            builder.Services.AddScoped<DefaultPaymentMethods>();
            builder.Services.AddScoped<DBIntializer>();

            return services;
        }
    }
}
