using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Caceres_s_Car
{
    public partial class InicioSesion : Form
    {
        
        public InicioSesion()
        {
            InitializeComponent();
           
        }
        //Hacer la conexion a BD CaceresCar
        // SqlConnection cn = new SqlConnection("Data Source=EDUAR7;Initial Catalog=CaceresCar;Integrated Security=True");
        SqlConnection cn = DataBase.Conexion();
        //Metodo que permitira iniciar sesion
        public void logear(String usuario, String contraseña)
        {
            try
            {                               
                //Comando para llamar la tabla Usuarios
                SqlCommand cmd = new SqlCommand("Select Nombre, Cargo, Apellido FROM Usuarios WHERE Usuario = @user AND Contraseña =@password", cn);
                cmd.Parameters.AddWithValue("user", usuario); //Igualamos user con el parametro usuario
                cmd.Parameters.AddWithValue("password", contraseña); //Igualamos password con el parametro contraseña
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count==1) //Si es igual a 1 es porque existen filas en la tabla
                {
                    this.Hide(); //Oculta este Form
                    if (dt.Rows[0][1].ToString()== "Administrador") //Tomamos la posicion de Cargo segun el comando ejecutado arriba(cmd) que seria[1]
                    {                                               //y si es Administrador que muestre el Menu
                        //Mandamos a llamar el form Menu y le pasamos 
                        //el parametro Nombre que segun la posicion del cmd es [0]
                        new Menu(dt.Rows[0][0].ToString()).Show();                        
                    }
                    else if(dt.Rows[0][1].ToString() == "Empleado")
                    {
                        //Mandamos a llamar el form MenuEmpleados y le pasamos 
                        //el parametro Nombre que segun la posicion del cmd es [0]

                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
            finally
            {
                DataBase.Conexion().Close(); //Cerramo conexion con la base de datos
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tb_contraseña_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void tb_contraseña_Enter(object sender, EventArgs e)
        {
            if (tb_contraseña.Text == "Contraseña")
            {
                tb_contraseña.Text = "";
                tb_contraseña.ForeColor = Color.Black;
                tb_contraseña.isPassword = true;
            }
        }

        private void tb_contraseña_Leave(object sender, EventArgs e)
        {
            if (tb_contraseña.Text == "")
            {
                tb_contraseña.Text = "Contraseña";
                tb_contraseña.ForeColor = Color.Gray;
                tb_contraseña.isPassword = false;
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Orange;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void bt_ingresar_Click(object sender, EventArgs e)
        {
            logear(tb_name.Text, tb_contraseña.Text); //Ponemos el metodo logear en el boton para iniciar sesion
        }

        private void tb_contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Si se presiona la tecla Enter en el tb_contraseña entonces pasar al Menu
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                logear(tb_name.Text, tb_contraseña.Text);
            }
        }
    }
}
