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
    public class ServiceController: Controller
    {
        private readonly IServicesRepository _serviceRepository;
        public ServiceController(IServicesRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public IActionResult ListService()
        {
            List<Service> services = _serviceRepository.GetServices();
            return View(services);
        }

        public IActionResult DetailService(int id)
        {
            Service service = _serviceRepository.GetServiceById(id);
            return View(service);
        }
    }
}
