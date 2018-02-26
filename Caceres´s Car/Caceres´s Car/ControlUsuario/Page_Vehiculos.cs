using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caceres_s_Car
{
    public partial class Page_Vehiculos : UserControl
    {
        public Page_Vehiculos()
        {
            InitializeComponent();
        }

        private void tb_buscar_Enter(object sender, EventArgs e)
        {
            if (tb_buscar.Text=="Buscar Vehiculo")
            {
                tb_buscar.Text = "";

                tb_buscar.ForeColor = Color.Black;
            }
        }

        private void tb_buscar_Leave(object sender, EventArgs e)
        {
            if (tb_buscar.Text == "")
            {
                tb_buscar.Text = "Buscar Vehiculo";

                tb_buscar.ForeColor = Color.DarkGray;
            }
        }
    }
}
