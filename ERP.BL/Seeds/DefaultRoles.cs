
namespace ERP.BL.Seeds
{
    public class DefaultRoles(RolesSeedServicesBL _rolesSeedServicesBL)
    {
        public async Task SeedDefaultRolesAsync()
        {
            await _rolesSeedServicesBL.SeedDefaultRolesAsync();
        }
    }
}
