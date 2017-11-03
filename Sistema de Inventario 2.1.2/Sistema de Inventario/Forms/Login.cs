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
using MySql.Data.MySqlClient;

namespace Sistema_de_Inventario
{
    public partial class Login : Form
    {
        public static string passingText;
        public Login()
        {
            InitializeComponent();
        }
                  
        public void logear(String usuario, String password)
        {
            try
            {
                //Hacer consulta a la BD
                MySqlCommand bd = new MySqlCommand("SELECT Nombre, Cargo, Apellido,IdUsuario FROM Usuarios WHERE Usuario = @Usuario AND Password= @Password", BD_Comun.ObtenerConexion());
                bd.Parameters.AddWithValue("Usuario", usuario);
                bd.Parameters.AddWithValue("Password", password);
                MySqlDataAdapter sda = new MySqlDataAdapter(bd);
                DataTable dt = new DataTable();
                //Actualiza filas
                sda.Fill(dt);

                String user = dt.Rows[0][0].ToString();
                clsUsuario.consulta = dt.Rows[0][1].ToString();
                clsUsuario.Contraseña = password;
                clsUsuario.Apellido = dt.Rows[0][2].ToString();
                clsUsuario.Nombre= dt.Rows[0][0].ToString();
                clsUsuario.ID= dt.Rows[0][3].ToString();
                if (dt.Rows.Count == 1)
            {

                   if (dt.Rows[0][1].ToString() == "Administrador") 
                   {
                       Principal f1 = new Principal();
                        f1.Show();
                        this.Hide();
                   }
                   else if (dt.Rows[0][1].ToString() == "Empleado")
                   {
                       Principal_Empleado f2 = new Principal_Empleado();
                        f2.Show();
                        this.Hide();
                   }

               }
              

            }

            catch (Exception ex)
            {
                MessageBox.Show("Usuario y/o Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Login l1 = new Login();
                l1.Show();
                //MessageBox.Show(ex.Message);
            }
            finally
            {

                BD_Comun.ObtenerConexion().Close();
            }


        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            passingText = txtUsuario.Text;
             //Principal principal = new Principal();
            logear(this.txtUsuario.Text, this.txtContraseña.Text);
            //this.Hide();
            //principal.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==Convert.ToChar(Keys.Enter))
            {
                passingText = txtUsuario.Text;
                //Principal principal = new Principal();
                logear(this.txtUsuario.Text, this.txtContraseña.Text);
                //this.Hide();
                //principal.Show();
            }
        }
    }
}
