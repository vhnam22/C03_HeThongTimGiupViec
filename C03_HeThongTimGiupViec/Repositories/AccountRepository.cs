using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repository.Interface;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace C03_HeThongTimGiupViec.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<Account> _userManager;
        public readonly SignInManager<Account> _signInManager;
        public readonly AdminAccount _adminAccount;
        public readonly JwtSetting _jwtSetting;
        private readonly C03_HeThongTimGiupViecContext _context;
        public AccountRepository(UserManager<Account> userManager,
            SignInManager<Account> signInManager,
            IOptionsMonitor<AdminAccount> adminAccount, IOptionsMonitor<JwtSetting> jwtSetting,
            C03_HeThongTimGiupViecContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _adminAccount = adminAccount.CurrentValue;
            _jwtSetting = jwtSetting.CurrentValue;
            _context = context;
        }

        //Get all account
        public List<Account> GetAllAccount()
        {
            List<Account> accLst = _context.Accounts.ToList();
            return accLst;
        }

        //Get account by account id
        public Account GetAccountById(string id)
        {
            try
            {
                if (id.IsNullOrEmpty()) return null;
                Account acc = _context.Accounts.FirstOrDefault(x => x.Id == id);
                return acc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update account info
        public bool UpdateAccount(Account account)
        {
            try
            {
                if (account != null)
                {
                    Account acc = GetAccountById(account.Id.ToString());
                    if (acc != null)
                    {
                        acc.Email = account.Email;
                        acc.UserName = account.UserName;
                        acc.PasswordHash = account.PasswordHash;
                        acc.UserName = account.UserName;
                        acc.FullName = account.FullName;
                        acc.PhoneNumber = account.PhoneNumber;
                        acc.City = account.City;
                        acc.Address = account.Address;
                        acc.ProfilePicture = account.ProfilePicture;
                        acc.Status = account.Status;
                        _context.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Login(LoginVM model)
        {
            var secretKeyBytes = Encoding.UTF8.GetBytes(_jwtSetting.Key);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var result = await ValidLogin(model);
            if (result == null)
            {
                return null;
            }
            var claims = await GetClaimsUsers(model);
            var tokenDecription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(3),
                Issuer = _jwtSetting.Issue,
                Audience = _jwtSetting.Issue,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDecription);
            string accessToken = jwtTokenHandler.WriteToken(token);
            return accessToken;
        }
        private async Task<List<Claim>> GetClaimsUsers(LoginVM model)
        {
            List<Claim> result;
            var user = await _userManager.FindByEmailAsync(model.Email);
            var roles = await _userManager.GetRolesAsync(user);
            string role = roles[0].ToString();
            result = new List<Claim>()
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new("UserId", user.Id),
                new("FullName", user.FullName),
                new("Address", user.Address),
                new(ClaimTypes.Role, role),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            return result;
        }
        private async Task<Account?> ValidLogin(LoginVM user)
        {
            string email = user.Email;
            var userIdentity = await _userManager.FindByEmailAsync(email);
            if (userIdentity == null || !await _userManager.CheckPasswordAsync(userIdentity, user.Password))
            {
                if (user.Email == _adminAccount.Email && user.Password == _adminAccount.Password)
                {
                    var admin = new Account()
                    {
                        Email = user.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = user.Email.Split("@")[0],
                        FullName = "",
                        Address = "",
                        PhoneNumber = "",
                        City = "",
                        ZipCode = "",
                        ProfilePicture = "",
                        Status = 1
                    };
                    await _userManager.CreateAsync(admin, _adminAccount.Password);
                    await _userManager.AddToRoleAsync(admin, "Admin");
                }
                else
                {
                    return null;
                }
            }
            return userIdentity;
        }

        public async Task<RegisterVM> Register(RegisterVM model, string role)
        {

            var userExistMail = await _userManager.FindByEmailAsync(model.Email);
            var userExistName = await _userManager.FindByNameAsync(model.Username);
            if (userExistMail != null || userExistName != null)
            {
                return null;
            }
            var user = new Account()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email.Split("@")[0],
                FullName = model.FullName,
                Address = "",
                PhoneNumber = "",
                City = "",
                ZipCode = "",
                ProfilePicture = "",
                Status = 1
            };
            var resultCreateUser = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, role);

            if (!resultCreateUser.Succeeded)
            {
                return null;
            }
            return model;
        }

        //Get Handyman account have top start 
        public async Task<List<Account>> GetHandymanAccountWithTopStar()
        {
            try
            {
                List<Account> lst = GetAllAccount();
                List<Account> result = new List<Account>();

                foreach (var account in lst)
                {
                    var roles = await _userManager.GetRolesAsync(account);
                    if (roles.Contains(UserRole.Host))
                    {
                        result.Add(account);
                    }
                }
                result = result.OrderByDescending(x => x.TotalStar).Take(4).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
