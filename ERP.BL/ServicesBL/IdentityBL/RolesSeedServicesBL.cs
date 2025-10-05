
namespace ERP.BL.ServicesBL.IdentityBL
{
    public class RolesSeedServicesBL(RoleManager<IdentityRole> _roleManager)
    {
        public async Task SeedDefaultRolesAsync()
        {
            if (!await _roleManager.Roles.AnyAsync(r => r.Name == ConstRoles.DefaultRole))
                await _roleManager.CreateAsync(new IdentityRole(ConstRoles.DefaultRole));
        }
    }
}
