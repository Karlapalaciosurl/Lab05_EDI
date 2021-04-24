using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab05_ControlTareas.Models;

namespace lab05_ControlTareas.Models
{
    public class ColaPrioridad<Task> where Task: IComparable<Task>
    {
        public List<Task> colaPrioridad = new List<Task>();
        public IEnumerable<Task> IenumColaPrioridad;

        public ColaPrioridad()
        {
            IenumColaPrioridad = (IEnumerable<Task>)colaPrioridad;
        }

        public void Encolar(Task tareaParaAgendar)
        {
            colaPrioridad.Add(tareaParaAgendar);

            int ci = colaPrioridad.Count - 1;
            while (ci > 0)
            {
                int pi = (ci - 1) / 2;

                if (colaPrioridad[ci].CompareTo(colaPrioridad[pi]) >= 0)
                {
                    break;
                }

                Task tmp = colaPrioridad[ci];
                colaPrioridad[ci] = colaPrioridad[pi];
                colaPrioridad[pi] = tmp;
                ci = pi;
            }
        }

        public Task DesEncolar()
        {

            int li = colaPrioridad.Count - 1;
            Task tareaDesAgendada = colaPrioridad[0];
            colaPrioridad[0] = colaPrioridad[li];
            Task dato = colaPrioridad[li];
            colaPrioridad.RemoveAt(li);

            --li;
            int pi = 0;
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li)
                {
                    break;
                }
                int rc = ci + 1;
                if (rc <= li && colaPrioridad[rc].CompareTo(colaPrioridad[ci]) < 0)
                {
                    ci = rc;
                }

                if (colaPrioridad[pi].CompareTo(colaPrioridad[ci]) <= 0)
                {
                    break;
                }
                Task tmp = colaPrioridad[pi];
                colaPrioridad[pi] = colaPrioridad[ci];
                colaPrioridad[ci] = tmp;
                pi = ci;
            }
            return tareaDesAgendada;
        }


        public int tareasAgendadas()
        {
            return colaPrioridad.Count;
        }

        public Task Peek()
        {
            Task tareaPrioritaria = colaPrioridad[0];
            return tareaPrioritaria;
        }
    }
}
