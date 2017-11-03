using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario
{
   public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Fecha_Nac { get; set; }
        public int Telefono { get; set; }
        public string Usuarios { get; set; }
        public string Password { get; set; }
        public string Cargo { get; set; }

         public Usuario() { }

        public Usuario(int pId, string pNombre, string pApellido, string pDireccion, string pFechaNac, int pTelefono, string pUsuario, string pPassword, string pCargo)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Direccion = pDireccion;
            this.Fecha_Nac = pFechaNac;
            this.Telefono = pTelefono;
            this.Usuarios = pUsuario;
            this.Password = pPassword;
            this.Cargo = pCargo;
        }

    }
}
