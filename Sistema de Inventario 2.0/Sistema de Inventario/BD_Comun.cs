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
    class BD_Comun
    {

        MySqlDataAdapter da;
        DataTable dt;
        //MySqlConnection cn;

        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=127.0.0.1; port= 3306; database=Sistema; Uid=root; pwd=toor;");

            conexion.Open();
            return conexion;
        }



        public void cargarUsuario(DataGridView dgv)
        {
         
            try
            {
                da = new MySqlDataAdapter("SELECT * FROM sistema.usuarios;", BD_Comun.ObtenerConexion());
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el Datagridview: " + ex.ToString());
            }

        }

        public void cargarCliente(DataGridView dgv)
        {

            try
            {
                da = new MySqlDataAdapter("SELECT * FROM sistema.cliente;", BD_Comun.ObtenerConexion());
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el Datagridview: " + ex.ToString());
            }



        }
        public void cargarProducto(DataGridView dgv)
        {

            try
            {
                da = new MySqlDataAdapter("SELECT * FROM sistema.Producto;", BD_Comun.ObtenerConexion());
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el Datagridview: " + ex.ToString());
            }

        }


        public void cargarCategoria(DataGridView dgv)
        {

            try
            {
                da = new MySqlDataAdapter("SELECT * FROM sistema.Categoria;", BD_Comun.ObtenerConexion());
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el Datagridview: " + ex.ToString());
            }

        }


        public void cargarProveedor(DataGridView dgv)
        {

            try
            {
                da = new MySqlDataAdapter("SELECT * FROM sistema.Proveedor;", BD_Comun.ObtenerConexion());
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el Datagridview: " + ex.ToString());
            }

        }
    }
}
