using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using lab05_ControlTareas.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace lab05_ControlTareas.Utils
{
    public class SubirTask : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public SubirTask(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            Random randomNumber = new Random();
            try
            {
                string taskTitle = collection["TaskTitle"];
                string proyectName = collection["ProyectName"];
                string taskDescripction = collection["TaskDescription"];
                string priority = collection["Priority"];
                string dateString = collection["Date"];
                int randomNumberForPriority = 0;

                switch (priority)
                {
                    case "Level1_50":
                        {
                            randomNumberForPriority = randomNumber.Next(1, 50);
                        }
                        break;
                    case "Level51_100":
                        {
                            randomNumberForPriority = randomNumber.Next(51, 100);
                        }
                        break;
                }

                Task taskRegistered = new Models.Task()
                {
                    tituloTask = taskTitle.Replace(',', ' '),
                    nombreProyecto = proyectName.Replace(',', ' '),
                    descripcionTask = taskDescripction.Replace(',', ' '),
                    prioridad = randomNumberForPriority,
                    fecha = dateString,
                };


                CeldaHash taskContainer = new CeldaHash();

                int numberOfTasks = Storage.Instance.usuarioActual.tareasAgendadas.tareasAgendadas();

                if (numberOfTasks <= 10)
                {
                    

                    if (taskContainer.insert(taskTitle, taskRegistered))
                    {
                        
                        string fileName = string.Empty;
                        string path = string.Empty;
                        string folder = string.Empty;


                        fileName = Path.GetFileName(Storage.Instance.usuarioActual.nombreUsuario);

                        if (Storage.Instance.usuarioActual.rol == "Developer")
                        {
                            folder = Path.Combine(_hostingEnvironment.WebRootPath, "Developers");
                        }
                        else
                        {
                            folder = Path.Combine(_hostingEnvironment.WebRootPath, "ProductManagers");
                        }

                        path = Path.Combine(folder, fileName + ".csv");

                        ManejadorArchivos file = new ManejadorArchivos(fileName, path);

                        file.escribirArchivo(taskRegistered);
                        Storage.Instance.usuarioActual.tareasAgendadas.Encolar(taskRegistered);

                        return RedirectToAction("Index", "Agenda");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }
       
    }
}
