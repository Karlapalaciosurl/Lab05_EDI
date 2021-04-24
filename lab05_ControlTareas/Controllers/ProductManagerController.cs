using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab05_ControlTareas.Controllers
{
    public class ProductManagerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
