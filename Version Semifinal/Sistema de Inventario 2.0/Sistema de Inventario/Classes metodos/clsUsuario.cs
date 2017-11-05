using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sistema_de_Inventario
{
    class clsUsuario
    {


        
        public static int AgregarUsuario(Usuario pUsuario)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Usuarios (Nombre, Apellido, Direccion, FechaNac, Telefono, Usuario, Password, Cargo) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                pUsuario.Nombre, pUsuario.Apellido, pUsuario.Direccion, pUsuario.Fecha_Nac, pUsuario.Telefono, pUsuario.Usuarios, pUsuario.Password, pUsuario.Cargo), BD_Comun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;


        }

        public static int EliminarUsuario(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("Delete From Usuarios where IdUsuario='{0}'", pId), conexion);


            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }

        public static int Actualizar(Usuario pUsuario)
        {
            int retorno = 0;
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update Usuarios set Nombre='{0}', Apellido='{1}', Direccion='{2}', FechaNac='{3}', Telefono='{4}', Usuario='{5}', Password='{6}', Cargo='{7}' where IdUsuario={8}",
                pUsuario.Nombre, pUsuario.Apellido, pUsuario.Direccion, pUsuario.Fecha_Nac, pUsuario.Telefono, pUsuario.Usuarios, pUsuario.Password, pUsuario.Cargo, pUsuario.Id), BD_Comun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;
            
        }

     


        public static Usuario ObtenerUsuario(int pId)
        {
            Usuario pUsuario = new Usuario();
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT  IdUsuario, Nombre, Apellido, Direccion, FechaNac, Telefono, Usuario, Password , Cargo  FROM Usuarios where IdUsuario={0}", pId), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                pUsuario.Id = reader.GetInt32(0);
                pUsuario.Nombre = reader.GetString(0);
                pUsuario.Apellido = reader.GetString(1);
                pUsuario.Direccion = reader.GetString(2);


                //pUsuario.Fecha_Nac = Convert.ToString(reader.GetDateTime(4));
                pUsuario.Telefono = Convert.ToInt32(reader.GetString(5));

                pUsuario.Usuarios = reader.GetString(6);
                pUsuario.Password = reader.GetString(7);

                conexion.Close();
            }


            return pUsuario;

        }


        public static List<Usuario> Buscar(string pNombre, string pApellido)
        {
            List<Usuario> lista = new List<Usuario>();

            MySqlCommand comando = new MySqlCommand(String.Format(
           "SELECT  IdUsuario ,Nombre, Apellido, Direccion, FechaNac, Telefono, Usuario, Password, Cargo FROM Usuarios  where Nombre ='{0}' or Apellido='{1}'", pNombre, pApellido), BD_Comun.ObtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Usuario pUsuario = new Usuario();
                pUsuario.Id = reader.GetInt32(0);
                pUsuario.Nombre = reader.GetString(1);
                pUsuario.Apellido = reader.GetString(2);
                pUsuario.Direccion = reader.GetString(3);
                pUsuario.Fecha_Nac = reader.GetString(4);
                pUsuario.Telefono = Convert.ToInt32(reader.GetString(5));
                pUsuario.Usuarios = reader.GetString(6);
                pUsuario.Password = reader.GetString(7);
                pUsuario.Cargo = reader.GetString(8);

                lista.Add(pUsuario);
            }

            return lista;

        }
        public static string consulta, Contraseña,Nombre,Apellido,ID;
    }  
    }


