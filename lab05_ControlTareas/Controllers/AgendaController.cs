using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using lab05_ControlTareas.Utils;
using lab05_ControlTareas.Models;


namespace lab05_ControlTareas.Controllers
{
    public class AgendaController : Controller
    {
     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult finalizarTask()
        {
            CeldaHash taskContainer = new CeldaHash();
            Models.Task taskToDelete = Storage.Instance.usuarioActual.tareasAgendadas.Peek();
            int i = 0;
            bool found = false;
            int index = 0;
            while (!found)
            {

                index = taskContainer.HashF(taskToDelete.tituloTask, i);

                if (Storage.Instance.hashTable[index].key.Equals(taskToDelete.tituloTask))
                {
                    found = true;
                    Storage.Instance.hashTable[index].key = null;
                    Storage.Instance.hashTable[index].taskDetails = null;
                    Storage.Instance.hashTable[index].state = CeldaHash.cellState.vacio;
                }
                else
                {
                    found = false;
                }
            }

            Storage.Instance.usuarioActual.tareasAgendadas.DesEncolar();

            return View("Index");
        }
    }
}
