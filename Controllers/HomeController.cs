using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPasscodeGenerator.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscodeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("count") == null)
            {
                RandomPassword generatedPassword = new RandomPassword();
                HttpContext.Session.SetString("password", generatedPassword.password);
                HttpContext.Session.SetInt32("count", 1);
            }
            ViewBag.Password = HttpContext.Session.GetString("password");
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            return View();
        }

        [HttpGet("generate")]
        public IActionResult Generate()
        {
            RandomPassword generatedPassword = new RandomPassword();
            HttpContext.Session.SetString("password", generatedPassword.password);
            HttpContext.Session.SetInt32("count", (int)HttpContext.Session.GetInt32("count") + 1);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
