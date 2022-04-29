using CAN_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CAN_Project.Logics;
using CAN_Project.ControllerModels;
using System.Text.Json;

namespace CAN_Project.Controllers
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
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public string Result(List<string> nodeValue)
        {
            var newAlgorithm = new Algorithms();
            string bus = newAlgorithm.BUSOutput(newAlgorithm.BUSResult(newAlgorithm.InputToNodes(nodeValue)));
            //string a = "pula pula pizda pizda";
            string jsonString = JsonSerializer.Serialize(bus);

            return jsonString;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
