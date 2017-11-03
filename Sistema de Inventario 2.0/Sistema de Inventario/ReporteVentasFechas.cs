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
    public partial class ReporteVentasFechas : Form
    {
        public ReporteVentasFechas()
        {
            InitializeComponent();
        }

        private void ReporteVentasFechas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet4.DataTable1' Puede moverla o quitarla según sea necesario.
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string FechaInicio = this.textBox1.Text;
           // string FechaFinal = this.textBox2.Text;


            this.DataTable1TableAdapter.Fill(this.DataSet4.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
