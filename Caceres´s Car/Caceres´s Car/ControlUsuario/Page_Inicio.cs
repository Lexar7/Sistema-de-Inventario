using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caceres_s_Car.Forms;

namespace Caceres_s_Car
{
    public partial class Page_Inicio : UserControl
    {
        public Page_Inicio()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString();
        }

        private void bunifuImageButton2_MouseEnter(object sender, EventArgs e)
        {
            lbEmpleados.ForeColor = Color.Orange;
        }

        private void bunifuImageButton2_MouseLeave(object sender, EventArgs e)
        {
            lbEmpleados.ForeColor = Color.Black;
        }

        private void bunifuImageButton1_MouseEnter(object sender, EventArgs e)
        {
            lbUsuarios.ForeColor = Color.Orange;
        }

        private void bunifuImageButton1_MouseLeave(object sender, EventArgs e)
        {
            lbUsuarios.ForeColor = Color.Black;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user.Show();
        }
    }
}
