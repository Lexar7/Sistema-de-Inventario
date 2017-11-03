using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema_de_Inventario
{
    class clsProducto
    {
       public static int AgregarProducto(Producto pProducto)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Producto (Nombre, Descripcion, Stock, PrecioUnitario, IdCategoria, IdProveedor) values ('{0}','{1}','{2}',{3},{4},{5})",
                pProducto.Nombre, pProducto.Descripcion, pProducto.Stock, pProducto.Precio, pProducto.Categoria, pProducto.Prov), BD_Comun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
        
        public static int EliminarProducto(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("Delete From Producto where IdProducto='{0}'", pId), conexion);


            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
        public static List<Producto> Obtener()
        {
            List<Producto> lista = new List<Producto>();
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT IdProducto, Nombre FROM sistema.Producto;"), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {

                Producto pProducto = new Producto();
                pProducto.IdProd = reader.GetInt32(0);
                pProducto.Nombre = reader.GetString(1);
                lista.Add(pProducto);
            }

            conexion.Close();
            return lista;
        }

    }
}
