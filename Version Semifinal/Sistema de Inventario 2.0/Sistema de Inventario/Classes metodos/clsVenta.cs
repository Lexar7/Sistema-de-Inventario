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
        public static List<Venta> BuscarNombre(string pNombre) {
            List<Venta> lista = new List<Venta>();
            MySqlConnection conexion = BD_Comun.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT IdVenta,IdUsuario,sistema.venta.IdCliente,Numero_Documento,Tipo_Documento,Fecha_Venta,sistema.cliente.Nombre FROM sistema.Venta INNER JOIN sistema.Cliente ON sistema.cliente.IdCliente = sistema.venta.IdCliente WHERE sistema.cliente.Nombre='{0}';", pNombre), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Venta pVenta = new Venta();
                pVenta.IdVenta = reader.GetInt32(0);
                pVenta.IdCliente = reader.GetInt32(1);
                pVenta.IdUsuario = reader.GetInt32(2);
                pVenta.nDocumento = reader.GetInt32(3);
                pVenta.tipoDocumento = reader.GetString(4);
                pVenta.Fecha = reader.GetString(5);
                lista.Add(pVenta);
            }
            return lista;
        }
        public static List<Venta> BuscarRango(string pDesde, string pHasta)
        {
            List<Venta> lista = new List<Venta>();
            MySqlConnection conexion = BD_Comun.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT IdVenta,IdUsuario,IdCliente,Numero_Documento,Tipo_Documento,Fecha_Venta FROM sistema.Venta WHERE Fecha_Venta BETWEEN '{0}' AND '{1}';", pDesde,pHasta), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Venta pVenta = new Venta();
                pVenta.IdVenta = reader.GetInt32(0);
                pVenta.IdCliente = reader.GetInt32(1);
                pVenta.IdUsuario = reader.GetInt32(2);
                pVenta.nDocumento = reader.GetInt32(3);
                pVenta.tipoDocumento = reader.GetString(4);
                pVenta.Fecha = reader.GetString(5);
                lista.Add(pVenta);
            }
            return lista;
        }
    }
}
