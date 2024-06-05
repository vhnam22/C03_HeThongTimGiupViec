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
        private readonly IServicesRepository _servicesRepository;
        public HomeController(IPostRepository postRepository, IAccountRepository accountRepository
        , IServicesRepository servicesRepository)
        {
            _postRepository = postRepository;
            _accountRepository = accountRepository;
            _servicesRepository = servicesRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Post> posts = _postRepository.GetAllPosts();
            List<Account> accounts = await _accountRepository.GetHandymanAccountWithTopStar();
            List<Service> services = _servicesRepository.GetServices();

            ViewBag.posts = posts;
            ViewBag.accounts = accounts;
            ViewBag.services = services;

            return View();
        }

    }
}