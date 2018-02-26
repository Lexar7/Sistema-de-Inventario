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

namespace Caceres_s_Car.Forms
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'caceresCarDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.caceresCarDataSet.Usuarios);

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (tb_buscar.Text == "Buscar Usuario")
            {
                tb_buscar.Text = "";

                tb_buscar.ForeColor = Color.Black;
            }
        }

        private void tb_buscar_Leave(object sender, EventArgs e)
        {
            if (tb_buscar.Text == "")
            {
                tb_buscar.Text = "Buscar Usuario";

                tb_buscar.ForeColor = Color.DarkGray;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            string valorBuscando = tb_buscar.Text.ToString(); //Convertir valor del txt a cadena de texto
            BuscarUser(valorBuscando); //Llamar al metodo y pasarle el parametro
           
        }

        public void BuscarUser(string nombre)
        {
                SqlConnection cn = new SqlConnection("Data Source=EDUAR7;Initial Catalog=CaceresCar;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select Nombre, Apellido, Direccion, Telefono, Usuario, Contraseña, Cargo from Usuarios where Nombre like '%"+nombre+"%'", DataBase.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TablaUsuarios.DataSource = dt;      
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized; // Minimiza la ventana
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_usuarios_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void lb_nueva_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void bt_usuarios_Click(object sender, EventArgs e)
        {
            CrearUsuario cu = new CrearUsuario();
            cu.Show();
        }
    }
}
