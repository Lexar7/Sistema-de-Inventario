using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Sistema_de_Inventario
{
    public partial class ReporteVentas : Form
    {
        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet3.DataTable1' Puede moverla o quitarla según sea necesario.
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = this.textBox1.Text;
            this.DataTable1TableAdapter.Fill(this.DataSet3.DataTable1, nom);

            this.reportViewer1.RefreshReport();

        }

        private void btnSalir_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        
    }
}
