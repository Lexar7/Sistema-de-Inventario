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
    public partial class ReporteClientes : Form
    {
        public ReporteClientes()
        {
            InitializeComponent();
        }

        private void ReporteClientes_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet2.cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.DataSet2.cliente);

            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (clsUsuario.consulta == "Administrador")
            {
                Reportes pr = new Reportes();
                pr.Show();
                this.Close();
            }
            else if (clsUsuario.consulta == "Empleado")
            {
                Reportes pr2 = new Reportes();
                pr2.Show();
                this.Close();
            }
        }
    }
}
