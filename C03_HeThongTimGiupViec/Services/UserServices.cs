using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace C03_HeThongTimGiupViec.Services
{
    public class UserServices: IUserServices
    {
        private UserManager<Account> _userManager;
        public readonly SignInManager<Account> _signInManager;
        public readonly AdminAccount _adminAccount;
        public readonly JwtSetting _jwtSetting;
        public readonly C03_HeThongTimGiupViecContext _context;

        public UserServices(UserManager<Account> userManager,
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
            var userIdentity = await _userManager.FindByEmailAsync(user.Email);
            if (userIdentity == null || !await _userManager.CheckPasswordAsync(userIdentity, user.Password))
            {
                if (user.Email == _adminAccount.Email && user.Password == _adminAccount.Password)
                {
                    var admin = new Account()
                    {
                        AccountId = Guid.NewGuid(),
                        Email = user.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = user.Email.Split("@")[0],
                        FullName = "",
                        Address = "",
                        PhoneNumber = "",
                        City = "",
                        ZipCode = "",
                        ProfilePicture = "",
                        Status = "1"
                    }; 
                    var r = await _userManager.CreateAsync(admin, _adminAccount.Password);
                    await _userManager.AddToRoleAsync(admin, "Admin");
                }
                else
                {
                    return null;
                }
            }
            return userIdentity;
        }

        public async Task<RegisterVM> Register(RegisterVM model)
        {
            
            var userExistMail = await _userManager.FindByEmailAsync(model.Email);
            var userExistName = await _userManager.FindByNameAsync(model.Username);
            if (userExistMail != null || userExistName != null)
            {
                return null;
            }
            var user = new Account()
            {
                AccountId = Guid.NewGuid(),
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email.Split("@")[0],
                FullName = model.FullName,
                Address = "",
                PhoneNumber = "",
                City = "",
                ZipCode = "",
                ProfilePicture = "",
                Status = "1"
            };
            var resultCreateUser = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, "Host");

            if (!resultCreateUser.Succeeded)
            {
                return null;
            }
            return model;
        }
    }
}
