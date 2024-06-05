using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace C03_HeThongTimGiupViec.Controllers
{
    public class PostController:Controller
    {
        public IActionResult ListPost()
        {
            return View();
        }

        public IActionResult DetailPost()
        {
            return View();
        }
    }
}
