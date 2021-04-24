using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using lab05_ControlTareas.Utils;
using System.Threading.Tasks;

namespace lab05_ControlTareas.Controllers
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
            if (Storage.Instance.hashTable.Count == 0)
            {
                Storage.Instance.hashTableInitialization.insertEmptyCells();
            }
            return View();
        }

        public IActionResult userHome()
        {
            return View("userHome");
        }



    }
}
