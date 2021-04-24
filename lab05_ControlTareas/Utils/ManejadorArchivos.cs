using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using lab05_ControlTareas.Models;
using System.Threading.Tasks;

namespace lab05_ControlTareas.Utils
{
    public class ManejadorArchivos
    {
        public string folder { get; set; }
        public string fileName { get; set; }
        public string path { get; set; }

        public ManejadorArchivos(string filename, string path)
        {
            this.fileName = filename;
            this.path = path;
        }

        
        public void crearArchivoUsuario()
        {

            if (!File.Exists(this.path))
            {

                using (StreamWriter sw = File.CreateText(this.path))
                {
                }
            }
        }

        public void escribirArchivo(Models.Task tareaActual)
        {

            
            using (StreamWriter sw = File.AppendText(this.path))
            {
                sw.WriteLine("{0},{1},{2},{3},{4},", tareaActual.tituloTask, tareaActual.nombreProyecto, tareaActual.prioridad, tareaActual.descripcionTask, tareaActual.fecha);
            }

        }

    }
}
