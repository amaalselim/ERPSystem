namespace ERP.BL.Seeds
{
    public class DefaultUnits(UnitsSeedServicesBL _unitsSeedServicesBL)
    {
        public async Task SeedDefaultUnitsAsync()
        {
            await _unitsSeedServicesBL.SeedDefaultUnitsAsync();
        }
    }
}
