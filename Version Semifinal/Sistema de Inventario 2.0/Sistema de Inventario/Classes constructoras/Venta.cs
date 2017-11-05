using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario.Classes_constructoras
{
    class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string tipoDocumento { get; set; }
        public int nDocumento { get; set; }
        public string Fecha { get; set; }

        public Venta() { }

        public Venta(int pIdVenta, int pIdCliente, int pIdUsuario, int pCantidad, string pTipo, int pnDocumento, string pFecha)
        {
            this.IdVenta = pIdVenta;
            this.IdCliente = pIdCliente;
            this.IdUsuario = pIdUsuario;
            this.tipoDocumento = pTipo;
            this.nDocumento = pnDocumento;
            this.Fecha = pFecha;

        }
    }
}
