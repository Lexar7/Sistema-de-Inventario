using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario
{
    class Producto
    {
        public int IdProd { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Categoria { get; set; }

        public int Prov { get; set; }

        public int Stock { get; set; }
        public decimal Precio { get; set; }

 
        public Producto() { }


        public Producto(int pIdProd, string pNombre, string pDescripcion,int pCategoria, int pStock,decimal pPrecio, int pProv)
        {
            this.IdProd = pIdProd;
            this.Nombre = pNombre;
            this.Descripcion = pDescripcion;
            this.Categoria = pCategoria;
            this.Stock = pStock;
            this.Precio = pPrecio;
            this.Prov = pProv;

        }
    }

}
