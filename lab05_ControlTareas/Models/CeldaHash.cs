using System;
using System.Collections.Generic;
using System.Linq;
using lab05_ControlTareas.Utils;
using System.Threading.Tasks;

namespace lab05_ControlTareas.Models
{
    public class CeldaHash
    {
        public enum cellState
        {
            vacio, ocupado, borrado
        }
        public int hashTableLenght = 50;
        public string key { get; set; }
        public Task taskDetails { get; set; }

        internal cellState state;

        public CeldaHash()
        {
            state = cellState.vacio;
        }

        public int HashF(string cadena, int intento)
        {

            int suma = 0;
            int indice = 0;
            foreach (var posicion in cadena)
            {
                char posicionChar = posicion;
                suma = suma + posicionChar + intento;
            }

            indice = (suma + intento) % hashTableLenght;

            return indice;
        }

        public void insertEmptyCells()
        {
            for (int i = 0; i < hashTableLenght; i++)
            {
                CeldaHash hashtest = new CeldaHash();
                hashtest.taskDetails = null;
                hashtest.key = null;
                hashtest.state = cellState.vacio;
                Storage.Instance.hashTable.Add(hashtest);
            }
        }

        public bool insert(string key, Task task)
        {
            int i = 0;
            int indice = 0;
            bool ocupado = false;

            while (ocupado == false)
            {
                indice = HashF(key, i);

                if (Storage.Instance.hashTable[indice].state == cellState.vacio)
                {

                    Storage.Instance.hashTable[indice].key = key;
                    Storage.Instance.hashTable[indice].taskDetails = task;
                    Storage.Instance.hashTable[indice].state = cellState.ocupado;
                    ocupado = true;
                    return true;
                }
                else
                {
                    if (Storage.Instance.hashTable[indice].key == key)
                    {
                        break;
                    }
                    else
                    {
                        i++;
                    }

                }

            }
            return false;
        }


}
}
