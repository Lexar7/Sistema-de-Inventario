using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Sistema_de_Inventario.Classes_metodos;
using Sistema_de_Inventario.Classes_constructoras;

namespace Sistema_de_Inventario
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }
        BD_Comun c = new BD_Comun();
        private void button4_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            ColorFilaDataGridView(dataGridView1);
            //Deshabilitar();
            radioButton1.Checked = false;
            c.cargarProveedor(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                Modificar();
                c.cargarProveedor(dataGridView1);
                Limpiar();
            }
            else
            {
                BorrarError();
                if (ValidarCampos())
                {

                    Proveedor pProveedor = new Proveedor();
                    pProveedor.Nombre = textBox1.Text.Trim();
                    pProveedor.DUI = Convert.ToInt32(textBox2.Text.Trim());
                    pProveedor.Direccion = textBox7.Text.Trim();
                    pProveedor.Telefono = Convert.ToInt32(textBox6.Text.Trim());
                    pProveedor.Email = textBox4.Text.Trim();




                    int resultado = clsProveedor.AgregarProveedor(pProveedor);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Proveedor Registrado Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el Proveedor", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Limpiar();
                    c.cargarProveedor(dataGridView1);
                }
                else
                {
                    
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


                 clsProveedor.EliminarProveedor(id);

                if (id > 0)
                {

                    MessageBox.Show("Proveedor eliminado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar una fila para eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            c.cargarProveedor(dataGridView1);
        }
        public void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox4.Clear();
            checkBox1.Checked = false;

        }


        public void Deshabilitar()
        {
            textBox7.Enabled = false;
            textBox1.Enabled = false;
            textBox6.Enabled = false;
            textBox3.Enabled = false;
            checkBox1.Checked = false;

        }

        public void Habilitar()
        {
            textBox1.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;

        }
        public void Modificar()
        {
            string texto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la contraseña de usuario de nivel Administrador", "Comprobacion", "");
            if (texto == clsUsuario.Contraseña)
            {
                MySqlConnection conexion = BD_Comun.ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(string.Format("Update Proveedor set Nombre='" + this.textBox1.Text + "',Numero_Documento='" + this.textBox2.Text + "',Direccion='" + this.textBox7.Text + "',Telefono='" + this.textBox6.Text + "',Email='" + this.textBox4.Text + "' WHERE IdProveedor= " + textBox3.Text), BD_Comun.ObtenerConexion());

                comando.ExecuteNonQuery();
                MessageBox.Show("Proveedor modificado Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar();
        }

        public void ColorFilaDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor= Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
    
            button2.Enabled = true;

            textBox3.Text = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            textBox1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            textBox2.Text = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            textBox7.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            textBox6.Text = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            textBox4.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            Habilitar();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public bool ValidarCampos()
        {
            bool ok = true;
            if (textBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox1, "Ingresar nombre");

            }

            if (textBox6.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox6, "Ingresar telefono");

            }

            if (textBox7.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox7, "Ingresar dirección");

            }

            if (textBox4.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox4, "Ingresar DUI");

            }

            if (textBox2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox2, "Ingresar correo");

            }        
            return ok;
        }
        public void BorrarError()
        {
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(textBox6, "");
            errorProvider1.SetError(textBox7, "");
            errorProvider1.SetError(textBox4, "");
            errorProvider1.SetError(textBox2, "");
            
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Letras(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Numeros(e);
        }
    }
}
