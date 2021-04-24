using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using lab05_ControlTareas.Utils;
using lab05_ControlTareas.Models;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace lab05_ControlTareas.Controllers
{
    public class RegistroController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public RegistroController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [TempData]
        public string mensajeRegistro { get; set; }

        // POST: SignUp/Create
        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                string username = collection["UserName"];
                string password = collection["Password"];
                string role = collection["Role"];
                usuario usuarioRegistrado = new usuario();
                if (usuarioRegistrado.registroUsuario(username, password, role) == null)
                {
                    mensajeRegistro = "Intenta de nuevo, este usuario ya existe";
                    return RedirectToAction("Index", "Registro");
                }
                else
                {
                    string fileName = string.Empty;
                    string path = string.Empty;
                    string folder = string.Empty;


                    Storage.Instance.usuariosRegistrados.Add(usuarioRegistrado);
                    mensajeRegistro = "";

                    fileName = Path.GetFileName(usuarioRegistrado.nombreUsuario);

                    if (usuarioRegistrado.rol == "Developer")
                    {
                        folder = Path.Combine(_hostingEnvironment.WebRootPath, "Developers");
                    }
                    else
                    {
                        folder = Path.Combine(_hostingEnvironment.WebRootPath, "ProductManagers");
                    }

                    path = Path.Combine(folder, fileName + ".csv");
                    ManejadorArchivos file = new ManejadorArchivos(fileName, path);
                    file.crearArchivoUsuario();

                    return RedirectToAction("Index", "Login");
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
