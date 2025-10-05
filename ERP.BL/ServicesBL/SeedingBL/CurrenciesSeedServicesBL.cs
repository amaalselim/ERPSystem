namespace ERP.BL.ServicesBL.SeedingBL
{
    public class CurrenciesSeedServicesBL(IUnitOfWork _unitOfWork)
    {
        public async Task SeedDefaultCurrencyAsync()
        {
            int count = 1;
            foreach (var currency in Enum.GetValues(typeof(eCurrency)).Cast<eCurrency>())
            {
                if (!await _unitOfWork.Repository<Currency>().ExistAsync(c => c.Name == currency.ToString()))
                {
                    await _unitOfWork.Repository<Currency>().SaveAsync(new Currency
                    {
                        Id = count,
                        Name = currency.ToString(),
                        Code = currency.ToString()
                    });
                }
                count++;
            }
            await _unitOfWork.CompleteAsync();
        }
    }
}
