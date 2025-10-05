namespace ERP.BL.ServicesBL.SeedingBL
{
    public class PaymentMehodsSeedServicesBL(IUnitOfWork _unitOfWork)
    {
        public async Task SeedDefaultPaymentMethodsAsync()
        {
            int count = 1;
            foreach (var paymentMethod in Enum.GetValues(typeof(ePaymentMethod)).Cast<ePaymentMethod>())
            {
                if (!await _unitOfWork.Repository<PaymentMethod>().ExistAsync(p => p.Name == paymentMethod.ToString()))
                {
                    await _unitOfWork.Repository<PaymentMethod>().SaveAsync(new PaymentMethod
                    {
                        Id = count,
                        Name = paymentMethod.ToString(),
                    });
                }
                count++;
            }
            await _unitOfWork.CompleteAsync();
        }
    }
}
