using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Caceres_s_Car
{
    class DataBase
    {
        SqlConnection conexion = new SqlConnection("Data Source=EDUAR7;Initial Catalog=CaceresCar;Integrated Security=True");
        public SqlCommand cmd;
        public static SqlConnection Conexion()
        {
            //Hacemos conexion a la BD
            SqlConnection cn = new SqlConnection("Data Source=EDUAR7;Initial Catalog=CaceresCar;Integrated Security=True");
            cn.Open(); //Abrimos la conexion
            return cn;
        }

        //Metodo de Insertar
        public bool Insertar(string sql)
        {
            conexion.Open();
            cmd = new SqlCommand(sql, conexion); //le pasamos el parametro al SQLCommand 
            int i = cmd.ExecuteNonQuery();
            if (i > 0) //Si la sentencia Sql se ejecuta correctamente se agregan los datos 
            {
                return true;
                conexion.Close();
            }
            else //sino no se agregan
            {
                return false;
            }
            
        }

    }
}
