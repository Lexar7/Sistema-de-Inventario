using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Sistema_de_Inventario.Classes_constructoras;

namespace Sistema_de_Inventario.Classes_metodos
{
    class clsCompra
    {
        public static int AgregarCompra(Compra pCompra)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Compra (Precio_Compra, Precio_Venta, Fecha_Compra, Proveedor_IdProveedor) values ('{0}','{1}','{2}',{3})",
                pCompra.Precio_Compra, pCompra.Precio_Venta, pCompra.Fecha, pCompra.IdProv), BD_Comun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }

        public static int AgregarDCompra(dCompra pdCompra)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Detalle_Compra (IdProducto, IdCompra) values ('{0}','{1}')",
                pdCompra.IdProducto, pdCompra.IdCompra), BD_Comun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
    }
}
