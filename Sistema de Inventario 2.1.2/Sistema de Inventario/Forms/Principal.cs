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
    public partial class Principal : Form
    {
        public Principal()

        {
            InitializeComponent();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Bienvenido " + Login.passingText;
            

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios us = new Usuarios();
            us.Show();
            this.Close();
        }

        private void Principal_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.U))
            {
                Usuarios us = new Usuarios();
                us.Show();
                this.Close();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.P))
            {
                Proveedores prov = new Proveedores();
                prov.Show();
                this.Close();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.C))
            {
                Compras comp = new Compras();
                comp.Show();
                this.Close();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.V))
            {
                Ventas ven = new Ventas();
                ven.Show();
                this.Close();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.I))
            {
                Inventario inv = new Inventario();
                inv.Show();
                this.Close();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.A))
            {
                Clientes cl = new Clientes();
                cl.Show();
                this.Close();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.R))
            {
                Reportes rep = new Reportes();
                rep.Show();
                this.Close();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.X))
            {
                Login log = new Login();
                log.Show();
                this.Close();
            }

        }

        private void btnUsuarios_KeyUp(object sender, KeyEventArgs e)
        {
           
        }
    }
}
