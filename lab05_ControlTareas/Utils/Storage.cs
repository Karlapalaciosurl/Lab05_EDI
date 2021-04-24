using System;
using System.Collections.Generic;
using System.Linq;
using lab05_ControlTareas.Models;
using System.Threading.Tasks;

namespace lab05_ControlTareas.Utils
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public usuario usuarioActual = new usuario();
        public List<usuario> usuariosRegistrados = new List<usuario>();
        public CeldaHash hashTableInitialization = new CeldaHash();
        public List<CeldaHash> hashTable = new List<CeldaHash>();
    }
}
