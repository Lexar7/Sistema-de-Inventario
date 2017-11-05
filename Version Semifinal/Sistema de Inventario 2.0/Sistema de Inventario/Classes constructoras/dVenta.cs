using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario.Classes_constructoras
{
    class dVenta
    {
        public int IddVenta { get; set; }
        public int IdVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal pUnitario { get; set; }
        public int IdProducto { get; set; }
        public decimal Descuento { get; set; }

        public dVenta() { }

        public dVenta(int pIddVenta, int pIdVenta, int pIdUsuario, int pCantidad,decimal ppUnitario, int pIdProducto, decimal pDescuento)
        {
            this.IddVenta = pIddVenta;
            this.IdVenta = pIdVenta;
            this.Cantidad = pCantidad;
            this.pUnitario = ppUnitario;
            this.IdProducto = pIdProducto;
            this.Descuento = pDescuento;

        }
    }
}
