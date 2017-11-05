using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema_de_Inventario
{
    class clsProveedor
    {
        public static int AgregarProveedor(Proveedor pProveedor)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Proveedor (Nombre, Numero_Documento, Direccion, Telefono,Email) values ('{0}','{1}','{2}','{3}','{4}')",
                pProveedor.Nombre, pProveedor.DUI, pProveedor.Direccion, pProveedor.Telefono, pProveedor.Email), BD_Comun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
        public static int EliminarProveedor(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("Delete From Proveedor where IdProveedor='{0}'", pId), conexion);


            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
        public static List<Proveedor> Obtener()
        {
            List<Proveedor> lista = new List<Proveedor>();
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT IdProveedor, Nombre FROM sistema.Proveedor;"), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {

                Proveedor pProveedor = new Proveedor();
                pProveedor.IdProveedor = reader.GetInt32(0);
                pProveedor.Nombre = reader.GetString(1);

                lista.Add(pProveedor);
            }


            return lista;
        }
        public static List<Proveedor> BuscarNombre(string pNombre)
        {
            List<Proveedor> lista = new List<Proveedor>();
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT IdProveedor,Nombre, Numero_Documento, Direccion, Telefono,Email FROM sistema.Proveedor WHERE Nombre='{0}';", pNombre), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Proveedor pProveedor = new Proveedor();
                pProveedor.IdProveedor = reader.GetInt32(0);
                pProveedor.Nombre = reader.GetString(1);
                pProveedor.DUI = reader.GetInt32(2);
                pProveedor.Direccion = reader.GetString(3);
                pProveedor.Telefono = reader.GetInt32(4);
                pProveedor.Email = reader.GetString(5);
                lista.Add(pProveedor);
            }
            return lista;
        }
        public static List<Proveedor> BuscarTelefono(string pTelefono)
        {
            List<Proveedor> lista = new List<Proveedor>();
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT IdProveedor,Nombre, Numero_Documento, Direccion, Telefono,Email FROM sistema.Proveedor WHERE Telefono='{0}';", pTelefono), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Proveedor pProveedor = new Proveedor();
                pProveedor.IdProveedor = reader.GetInt32(0);
                pProveedor.Nombre = reader.GetString(1);
                pProveedor.DUI = reader.GetInt32(2);
                pProveedor.Direccion = reader.GetString(3);
                pProveedor.Telefono = reader.GetInt32(4);
                pProveedor.Email = reader.GetString(5);
                lista.Add(pProveedor);
            }
            return lista;
        }
    }

}
