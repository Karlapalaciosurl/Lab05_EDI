using System;
using System.Collections.Generic;
using System.Linq;
using lab05_ControlTareas.Models;
using System.Threading.Tasks;
using lab05_ControlTareas.Utils;

namespace lab05_ControlTareas.Models
{
    public class usuario
    {
        public string nombreUsuario { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
        public ColaPrioridad<Task> tareasAgendadas = new ColaPrioridad<Task>();

        public usuario registroUsuario(string nombre, string pass, string usuarioRol)
        {
            if (Storage.Instance.usuariosRegistrados.Exists(user => user.nombreUsuario.Equals(nombre)))
            {
                return null;
            }
            else
            {
                this.nombreUsuario = nombre;
                this.password = pass;
                this.rol = usuarioRol;

                return this;
            }
        }

        public usuario inicioSesionUsuario(string nombre, string pass)
        {
            if (!Storage.Instance.usuariosRegistrados.Exists(user => user.nombreUsuario.Equals(nombre)))
            {
                return null;
            }
            else
            {
                return Storage.Instance.usuariosRegistrados.Find(user => user.nombreUsuario.Equals(nombre));
            }
        }


    }
}
