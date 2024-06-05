using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repository.Interface;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace C03_HeThongTimGiupViec.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository _accRep;

        public AccountController(IAccountRepository accRep)
        {
            _accRep = accRep;
        }

        public async Task<IActionResult> Register(string email, string userName, string fullName, string address, string password, string role)
        {
            RegisterVM model = new RegisterVM()
            {
                Email = email,
                Username = userName,
                FullName = fullName,
                Address = address,
                Password = password
            };

            RegisterVM resultModel = await _accRep.Register(model, role);
            if (resultModel != null)
            {
                ViewBag.Message = "Fail";
            }
            ViewBag.Message = "Success";
            return View("Index");
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
            return View();
        }

        [CustomAuthorize(UserRole.Admin,UserRole.Host)]
        //[Authorize(Roles = UserRole.Admin)]
        public IActionResult Index()
        {
            List<Account> lst = _accRep.GetAllAccount();
            return View(lst);
        }
    }
}
