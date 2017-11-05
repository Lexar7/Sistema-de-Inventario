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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Progreso.Start();
        }
        
        private void Progreso_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            if (progressBar1.Value > 90)
            {
                Progreso.Interval = 250;
                progressBar1.Value += 1;
            }
            else
            {
                progressBar1.Value += rnd.Next(5, 10);
            }
            if (progressBar1.Value > 99)
            {
                Progreso.Stop();
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            label1.Text = "Cargando... " + progressBar1.Value + " %";
        }
    }
}
