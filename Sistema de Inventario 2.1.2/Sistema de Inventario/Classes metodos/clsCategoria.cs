using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema_de_Inventario
{
    class clsCategoria
    {
        public static int AgregarCategoria(Categoria pCategoria)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Categoria (Nombre) values ('{0}')",
                pCategoria.Nombre), BD_Comun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
        public static List<Categoria> Obtener()
        {
            List<Categoria> lista = new List<Categoria>();
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT IdCategoria, Nombre FROM sistema.Categoria;"), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {

                Categoria pCategoria = new Categoria();
                pCategoria.IdCategoria = reader.GetInt32(0);
                pCategoria.Nombre = reader.GetString(1);

                lista.Add(pCategoria);
            }


            return lista;
        }
    }
}
