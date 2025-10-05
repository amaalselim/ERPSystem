namespace ERP.BL.Seeds
{
    public class DBIntializer
    {
        public static async Task SeedDBAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            try
            {
                var defaultRoleServices = scope.ServiceProvider.GetRequiredService<DefaultRoles>();
                var defaultUnitsServices = scope.ServiceProvider.GetRequiredService<DefaultUnits>();
                var defaultCurrenciesServices = scope.ServiceProvider.GetRequiredService<DefaultCurrencies>();
                var defaultPaymentMethodsServices = scope.ServiceProvider.GetRequiredService<DefaultPaymentMethods>();

                await defaultRoleServices.SeedDefaultRolesAsync();
                await defaultUnitsServices.SeedDefaultUnitsAsync();
                await defaultCurrenciesServices.SeedDefaultCurrencyAsync();
                await defaultPaymentMethodsServices.SeedDefaultPaymentMethodsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "." + ex.Source);
                throw;
            }

        }
    }
}
