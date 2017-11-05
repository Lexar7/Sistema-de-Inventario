using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario.Classes_constructoras
{
    class dCompra
    {
        public int IddCompra { get; set; }
        public int IdProducto { get; set; }
        public int IdCompra { get; set; }

        public dCompra() { }

        public dCompra(int pIddCompra, int pIdProducto, int pIdCompra)
        {
            this.IddCompra = pIddCompra;
            this.IdProducto = pIdProducto;
            this.IdCompra = pIdCompra;
        }
    }
}
