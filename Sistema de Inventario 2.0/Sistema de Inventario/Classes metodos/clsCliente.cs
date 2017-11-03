using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Sistema_de_Inventario
{
    class clsCliente
    {
         public static int AgregarCliente(Cliente pCliente)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Cliente (Nombre, Apellido, DUI, Direccion, Telefono, NIT, Correo) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                pCliente.Nombre, pCliente.Apellido, pCliente.DUI, pCliente.Direccion, pCliente.Telefono, pCliente.NIT, pCliente.Correo), BD_Comun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;


        }

        public static int EliminarCliente(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("Delete From Cliente where IdCliente='{0}'", pId), conexion);


            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }


        public static List<Cliente> Buscar(string pNombre, string pApellido)
        {
            List<Cliente> lista = new List<Cliente>();

            MySqlCommand comando = new MySqlCommand(String.Format(
           "SELECT  IdCliente ,Nombre, Apellido, DUI, Direccion, Telefono, NIT, Correo FROM Cliente  where Nombre ='{0}' or Apellido='{1}'", pNombre, pApellido), BD_Comun.ObtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Cliente pCliente = new Cliente();
                pCliente.Id = reader.GetInt32(0);
                pCliente.Nombre = reader.GetString(1);
                pCliente.Apellido = reader.GetString(2);
                pCliente.DUI = reader.GetString(3);
                pCliente.Direccion = reader.GetString(4);
                pCliente.Telefono = Convert.ToInt32(reader.GetString(5));
                pCliente.NIT = reader.GetString(6);
                pCliente.Correo = reader.GetString(7);
               
                lista.Add(pCliente);
            }

            return lista;

        }
        public static List<Cliente> Obtener()
        {
            List<Cliente> lista = new List<Cliente>();
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT IdCliente, Nombre FROM sistema.Cliente;"), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {

                Cliente pCliente = new Cliente();
                pCliente.Id = reader.GetInt32(0);
                pCliente.Nombre = reader.GetString(1);


                lista.Add(pCliente);
            }


            return lista;
        }
    }
}
