namespace ExampleConfiguration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using ExampleConfiguration.Models;
    using ExampleConfiguration.Other;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<SettingOption> _options;

        public HomeController(ILogger<HomeController> logger, IOptions<SettingOption> options = null)
        {
            _logger = logger;
            _options = options;
        }

        public IActionResult Index()
        {

            return View();
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
