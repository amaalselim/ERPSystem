namespace ERP.BL.Seeds
{
    public class DefaultPaymentMethods(PaymentMehodsSeedServicesBL _paymentMehodsSeedServicesBL)
    {
        public async Task SeedDefaultPaymentMethodsAsync()
        {
            await _paymentMehodsSeedServicesBL.SeedDefaultPaymentMethodsAsync();
        }
    }
}
