using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Test2.Models;
using MVC_Test2.Services;
using MVC_Test2.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Test2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INullMailService _mailService;

        public HomeController(ILogger<HomeController> logger, INullMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Big Testing Banner";
            return View(ViewBag);
        }

        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage(model.Email, model.Subject, model.Message);
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
          
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
