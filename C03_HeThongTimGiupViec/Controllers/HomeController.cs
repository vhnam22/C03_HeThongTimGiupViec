using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repositories;
using C03_HeThongTimGiupViec.Repositories.Interface;
using C03_HeThongTimGiupViec.Repository.Interface;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace C03_HeThongTimGiupViec.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IAccountRepository _accountRepository;
        public HomeController(IPostRepository postRepository,IAccountRepository accountRepository)
        {   
             _postRepository = postRepository;
            _accountRepository = accountRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Post> posts = _postRepository.GetAllPosts();
            List<Account> accounts = await _accountRepository.GetHandymanAccountWithTopStar();

            ViewBag.posts = posts;
            ViewBag.accounts = accounts;

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