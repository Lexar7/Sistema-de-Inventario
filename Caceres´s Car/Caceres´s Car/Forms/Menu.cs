using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caceres_s_Car
{
    public partial class Menu : Form
    {
        public Menu(String nombre) //Espera que recibe parametro nombre del Form Menu
        {
            InitializeComponent();
            page_Inicio1.BringToFront(); //Traer al frente el control de usuario
            lbUsuario.Text = nombre; //Mostrar nombre del usuario ingresado
        }

        Bunifu.Framework.UI.Drag MoveForm = new Bunifu.Framework.UI.Drag();

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            page_Estadisticas1.BringToFront(); //Traer al frente el control de usuario
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm.Grab(this); //Al tener presionado el click en el panel3 puede mover la ventana
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            MoveForm.Release(); //Al soltar el click del panel3 vuelve a su estado sin movimiento
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm.MoveObject(); //Al momento de mover el mouse tambien se movera la ventana si se click en el panel3
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); //Cierra todo el programa
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized; // Minimiza la ventana
        }

        //Al presionar el boton de Menu
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        { 
            //La slidemenu se hara más pequeña cambiando el tamaño del logo
            if (sidemenu.Width>=214){
                logo.Location = new Point(20, 78);
                logo.Size = new Size(40, 40);
                sidemenu.Width = 65;
                
            }
            //Al volver a presionar el boton Menu el slidemenu vuelve a su forma original y el logo tambien
            else {
                logo.Location = new Point(31, 6);
                logo.Size = new Size(168, 146);
                sidemenu.Width = 214;
            }
        }

        private void dsfsdfsd_Load(object sender, EventArgs e)
        {

        }

        private void bt_inicio_Click(object sender, EventArgs e)
        {
            page_Inicio1.BringToFront(); //Traer al frente el control de usuario
        }

        private void bt_cars_Click(object sender, EventArgs e)
        {
            page_Vehiculos1.BringToFront(); //Traer al frente el control de usuario
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            page_Clientes1.BringToFront(); //Traer al frente el control de usuario
        }

        private void bt_inventario_Click(object sender, EventArgs e)
        {
            page_Invetario1.BringToFront(); //Traer al frente el control de usuario
        }

        private void bt_ayuda_Click(object sender, EventArgs e)
        {
            page_Ayuda1.BringToFront(); //Traer al frente el control de usuario
        }
    }
}
