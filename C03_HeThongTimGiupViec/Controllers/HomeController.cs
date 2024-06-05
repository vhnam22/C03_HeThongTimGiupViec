using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Services;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace C03_HeThongTimGiupViec.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly C03_HeThongTimGiupViecContext _context;
        public HomeController(IUserServices userService,C03_HeThongTimGiupViecContext context)
        {
            _userServices = userService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(string email, string userName, string fullName, string address, string password)
        {
            RegisterVM model = new RegisterVM()
            {
                Email = email,
                Username = userName,
                FullName = fullName,
                Address = address,
                Password = password
            };
            
            RegisterVM resultModel = await _userServices.Register(model);
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
            if(await _userServices.Login(model) != null)
            {
                token = await _userServices.Login(model);
            }
            ViewBag.token = token;


            // set token for session
            HttpContext.Session.SetString("Token", token);
            return View();
        }

        [Authorize(Roles = $"{UserRole.Admin},{UserRole.Host}")]
        //[Authorize(Roles = UserRole.Admin)]
        public async Task<List<Account>> AccountList()
        {
            List<Account> lst = _context.Accounts.ToList();
            return lst;
        }

        public async Task<IActionResult> Test()
        {
            return View();
        }

    }
}