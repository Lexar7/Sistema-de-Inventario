using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Inventario
{
    public partial class Principal_Empleado : Form
    {
        public Principal_Empleado()
        {
            //lblMensaje.Text = "Bienvenido  " + nombre;
            InitializeComponent();
        }

        private void Principal_Empleado_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Bienvenido " + Login.passingText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Compras compras = new Compras();
            compras.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BD_Comun.ObtenerConexion().Close();

            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
