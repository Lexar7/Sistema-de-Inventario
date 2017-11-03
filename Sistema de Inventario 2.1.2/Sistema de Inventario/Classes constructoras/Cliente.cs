using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario
{
    class Cliente
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DUI { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string NIT { get; set; }
        public string Correo { get; set; }


         public Cliente() { }


         public Cliente(int pId, string pNombre, string pApellido, string pDUI, string pDireccion, int pTelefono, string pNIT, string pCorreo)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.DUI= pDUI;
            this.Direccion = pDireccion;
            this.NIT = pNIT;
            this.Correo = pCorreo;
           
        }

    }


    
}
