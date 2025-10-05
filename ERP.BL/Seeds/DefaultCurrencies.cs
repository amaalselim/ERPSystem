namespace ERP.BL.Seeds
{
    public class DefaultCurrencies(CurrenciesSeedServicesBL _currenciesSeedServicesBL)
    {
        public async Task SeedDefaultCurrencyAsync()
        {
            await _currenciesSeedServicesBL.SeedDefaultCurrencyAsync();
        }
    }
}
