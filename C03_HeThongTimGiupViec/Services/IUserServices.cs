using C03_HeThongTimGiupViec.ViewModels;

namespace C03_HeThongTimGiupViec.Services
{
    public interface IUserServices
    {
        Task<string> Login(LoginVM model);
        Task<RegisterVM> Register(RegisterVM model);
    }
}
