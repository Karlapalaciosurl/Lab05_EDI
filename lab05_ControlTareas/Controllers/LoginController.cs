using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using lab05_ControlTareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lab05_ControlTareas.Utils;

namespace lab05_ControlTareas.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [TempData]
        public string mensajeInicioSesion { get; set; }


        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                string username = collection["UserName"];
                string password = collection["Password"];
                usuario usuarioActual = new usuario();

                if (usuarioActual.inicioSesionUsuario(username, password) == null)
                {
                    mensajeInicioSesion = "Este usuario no existe";
                    return RedirectToAction("Index");

                }
                else
                {
                    if (usuarioActual.inicioSesionUsuario(username, password).password != password)
                    {
                        mensajeInicioSesion = "Contraseña incorrecta, intente de nuevo";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        mensajeInicioSesion = "";
                        Storage.Instance.usuarioActual = usuarioActual.inicioSesionUsuario(username, password);
                        return RedirectToAction("userHome", "Home");
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            usuario usuarioDefault = new usuario();
            usuarioDefault.tareasAgendadas.colaPrioridad.Clear();
            Storage.Instance.usuarioActual = usuarioDefault;
            return View("Index");
        }


    }
}
