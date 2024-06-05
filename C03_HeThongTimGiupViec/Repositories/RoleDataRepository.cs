using C03_HeThongTimGiupViec.Repository.Interface;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace C03_HeThongTimGiupViec.Repository
{
    public class RoleDataRepository : IDataRepository
    {
        public readonly IServiceProvider _app;
        public RoleDataRepository(IServiceProvider app)
        {
            _app = app;
        }
        public async Task AddData()
        {
            var scope = _app.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var listRole = UserRole.Roles;

            foreach (var role in listRole)
            {
                if (!roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }

}

