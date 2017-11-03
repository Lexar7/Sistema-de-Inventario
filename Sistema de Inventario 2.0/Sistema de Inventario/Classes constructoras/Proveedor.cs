using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario
{
    class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public int DUI { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }

        public int IdProv { get; set; }
        public string NombreProveedor { get; set; }


        public Proveedor() { }


        public Proveedor(int pIdProveedor, string pNombre, int pDUI, string pDireccion, int pTelefono, string pEmail, int pIdProv, string pNombreProv)
        {
            this.IdProveedor = pIdProveedor;
            this.Nombre = pNombre;
            this.DUI = pDUI;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.Email = pEmail;
            this.IdProv = pIdProv;
            this.NombreProveedor = pNombreProv;

        }
    }
}
