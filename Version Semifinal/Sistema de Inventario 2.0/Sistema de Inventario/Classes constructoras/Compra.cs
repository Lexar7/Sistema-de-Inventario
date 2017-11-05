using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario.Classes_constructoras
{
    class Compra
    {
        public int IdCompra { get; set; }
        public string Nom_Producto { get; set; }
        public string Descripcion { get; set; }
        public int Categoria { get; set; }
        public int Cantidad { get; set; }

        public int IdProv { get; set; }
        public decimal Precio_Compra { get; set; }
        public decimal Precio_Venta { get; set; }
        public string Fecha { get; set; }


        public Compra() { }

        public Compra(int pIdCompra, string pNom_Producto, string pDescripcion, int pCategoria, int pCantidad, decimal pPrecio_Compra, decimal pPrecio_Venta, int pIdProv, string pFecha)
        {
            this.IdCompra = pIdCompra;
            this.Nom_Producto = pNom_Producto;
            this.Descripcion = pDescripcion;
            this.Categoria = pCategoria;
            this.Cantidad = pCantidad;
            this.Precio_Compra = pPrecio_Compra;
            this.Precio_Venta = pPrecio_Venta;
            this.IdProv = pIdProv;
            this.Fecha = pFecha;


        }
    }
}
