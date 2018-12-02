using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsProfiler.Admin.Models;
using SportsProfiler.Models.Models;
using SportsProfiler.Services.UserService;

namespace SportsProfiler.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        
        public IActionResult Index()
        {
            _userService.SaveAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}