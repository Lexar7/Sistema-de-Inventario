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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (clsUsuario.consulta == "Administrador")
            {
                Principal pr = new Principal();
                pr.Show();
                this.Close();
            }
            else if (clsUsuario.consulta == "Empleado")
            {
                Principal_Empleado pr2 = new Principal_Empleado();
                pr2.Show();
                this.Close();
            }
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteProductos rp = new ReporteProductos();
            rp.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReporteClientes rc = new ReporteClientes();
            rc.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReporteVentas rc = new ReporteVentas();
            rc.Show();
            this.Close();
        }
    }
}
