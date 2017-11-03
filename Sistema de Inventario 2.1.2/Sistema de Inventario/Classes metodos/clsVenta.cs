using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Sistema_de_Inventario.Classes_constructoras;

namespace Sistema_de_Inventario.Classes_metodos
{
    class clsVenta
    {
        public static int AgregarVenta(Venta pVenta)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Venta (IdCliente, IdUsuario, Numero_Documento, Tipo_Documento,Fecha_Venta) values ('{0}','{1}','{2}','{3}','{4}')",
                pVenta.IdCliente, pVenta.IdUsuario, pVenta.nDocumento, pVenta.tipoDocumento, pVenta.Fecha), BD_Comun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
        public static int AgregarDVenta(dVenta pdVenta)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Detalle_Venta (IdDetalle_Venta, IdVenta, Cantidad, Precio_Unitario,Descuento,IdProducto) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
               pdVenta.IddVenta , pdVenta.IdVenta, pdVenta.Cantidad, pdVenta.pUnitario,pdVenta.Descuento,pdVenta.IdProducto), BD_Comun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
    }
}
