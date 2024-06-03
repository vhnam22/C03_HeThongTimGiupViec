using C03_HeThongTimGiupViec.Models;
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
        private readonly C03_HeThongTimGiupViecContext _context;
        public HomeController(C03_HeThongTimGiupViecContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}