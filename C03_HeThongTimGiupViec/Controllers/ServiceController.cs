using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Services;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace C03_HeThongTimGiupViec.Controllers
{
    public class ServiceController: Controller
    {
        public IActionResult ListService()
        {
            return View();
        }

        public IActionResult DetailService()
        {
            return View();
        }
    }
}
