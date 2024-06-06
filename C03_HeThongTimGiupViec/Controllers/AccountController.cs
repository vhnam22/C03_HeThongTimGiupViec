using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repository.Interface;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace C03_HeThongTimGiupViec.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository _accRep;
        private UserManager<Account> _userManager;

        public AccountController(IAccountRepository accRep,UserManager<Account> userManager)
        {
            _accRep = accRep;
            _userManager = userManager;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string email, string username, string fullName, string address, string password, int role)
        {
            RegisterVM model = new RegisterVM()
            {
                Email = email,
                Username = username,
                FullName = fullName,
                Address = address,
                Password = password
            };
            string accRole = "";
            if(role == 2)
            {
                accRole = UserRole.Host;
            }else accRole = UserRole.Handyman;

            RegisterVM resultModel = await _accRep.Register(model, accRole);
            if (resultModel == null)
            {
                ViewBag.Message = "Fail";
            }else ViewBag.Message = "Successful, you can login.";
            return View();
        }


        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            string token = "Fail";
            LoginVM model = new LoginVM()
            {
                Email = email,
                Password = password
            };
            string rs = await _accRep.Login(model);
            if (rs != null)
            {
                token = rs;
            }
            ViewBag.token = token;


            HttpContext.Session.SetString("JwtToken", token);
            ViewBag.Token = token;
            //Account account = _accRep.ConvertTokenToAccount();
            return RedirectToAction("Index", "Home");
        }

        //[CustomAuthorize(UserRole.Admin,UserRole.Host)]
        ////[Authorize(Roles = UserRole.Admin)]
        //public IActionResult Index()
        //{
        //    List<Account> lst = _accRep.GetAllAccount();
        //    return View(lst);
        //}

        public IActionResult Profile(string id)
        {
            try
            {
                Account account = _accRep.GetAccountById(id);
                return View(account);
            }catch(Exception ex) {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Profile(Account account)
        {
            if(ModelState.IsValid)
            {
                bool result =  _accRep.UpdateAccount(account);
                if (result) {
                    ViewBag.Status = true;
                }
                else ViewBag.Status = false;
            }
            Account _account = _accRep.GetAccountById(account.Id);
            return View(_account);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string id,string oldPass, string newPass, string rePass)
        {
            Account account = _accRep.GetAccountById(id);
            if (newPass != rePass)
            {
                ViewBag.Fail = "Confirm password is mismatch.";
            }
            else
            {
                var result = await _userManager.CheckPasswordAsync(account, oldPass);
                if (result)
                {
                    var update =  await _userManager.ChangePasswordAsync(account, oldPass, newPass);
                    if (update.Succeeded){
                        ViewBag.Success = "Change password successful.";
                    }else ViewBag.Fail = "Change password fail.";
                }
                else
                ViewBag.Fail = "Old password is incorrect.";
            }
            ViewBag.oldPass = oldPass;
            ViewBag.newPass= newPass;
            ViewBag.RePass = rePass;
            
            return View("Profile",account);

        }
    }
}
