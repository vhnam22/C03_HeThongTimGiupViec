using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.ViewModels;

namespace C03_HeThongTimGiupViec.Repository.Interface
{
    public interface IAccountRepository
    {
        //Login 
        Task<string> Login(LoginVM model);

        //Register account
        Task<RegisterVM> Register(RegisterVM model, string role);

        //Get all account
        public List<Account> GetAllAccount();

        //Get account by account id
        public Account GetAccountById(string id);

        //Update account info
        public bool UpdateAccount(Account account);

        //Get Handyman account have top start 
        Task<List<Account>> GetHandymanAccountWithTopStar();
    }
}
