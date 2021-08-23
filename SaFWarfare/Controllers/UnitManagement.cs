using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaFWarfare.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SaFWarfare.Controllers
{
    public class UnitManagement : Controller
    {
        private readonly ILogger<UnitManagement> _logger;

        public UnitManagement(ILogger<UnitManagement> logger)
        {
            _logger = logger;
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
