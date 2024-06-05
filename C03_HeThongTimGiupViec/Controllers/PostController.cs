using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repositories.Interface;
using C03_HeThongTimGiupViec.Repository.Interface;
using C03_HeThongTimGiupViec.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace C03_HeThongTimGiupViec.Controllers
{
    public class PostController:Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult ListPost()
        {
            List<Post> posts = _postRepository.GetAllPosts();
            ViewBag.posts = posts;
            return View();
        }

        public IActionResult DetailPost(int id)
        {
            Post post = _postRepository.GetPostById(id);
            return View(post);
        }
    }
}
