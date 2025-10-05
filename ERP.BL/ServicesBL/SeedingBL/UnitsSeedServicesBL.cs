namespace ERP.BL.ServicesBL.SeedingBL
{
    public class UnitsSeedServicesBL(IUnitOfWork _unitOfWork)
    {
        public async Task SeedDefaultUnitsAsync()
        {
            int Count = 1;
            foreach (var unit in Enum.GetValues(typeof(eUnit)).Cast<eUnit>())
            {
                bool existingUnit = await _unitOfWork.Repository<Unit>().ExistAsync(u => u.Name == unit.ToString());
                if (!existingUnit)
                {
                    await _unitOfWork.Repository<Unit>().SaveAsync(new Unit
                    {
                        Id = Count,
                        Name = unit.ToString(),
                        Quantity = Count
                    });
                }
                Count++;
            }
            await _unitOfWork.CompleteAsync();
        }
    }
}
