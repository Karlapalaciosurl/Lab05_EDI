using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab05_ControlTareas.Models
{
        public class Task : IComparable<Task>
        {
            public string tituloTask { get; set; }
            public string nombreProyecto { get; set; }
            public string descripcionTask { get; set; }
            public int prioridad { get; set; }
            public string fecha { get; set; }


            public int CompareTo(Task other)
            {
                if (this.prioridad < other.prioridad)
                {
                    return -1;
                }
                else if (this.prioridad > other.prioridad)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }


        }
}
