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
    public partial class Inventario : Form
    {
        public Inventario()
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

        private void Inventario_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
           // Deshabilitar();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox4.Enabled = false;
            textBox2.Enabled = true;
            c.cargarProducto(dataGridView1);
            comboBox1.DataSource=clsProveedor.Obtener();
            comboBox2.DataSource = clsCategoria.Obtener();

            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdCategoria";

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdProveedor";
            ColorFilaDataGridView(dataGridView1);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            


        }
        public void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }
        public void Deshabilitar()
        {
            textBox7.Enabled = false;
            textBox1.Enabled = false;
            textBox6.Enabled = false;
            textBox3.Enabled = false;

        }
        public void Habilitar()
        {
            textBox1.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox2.Enabled = true;

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar();
        }
        public void Modificar()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox6.Text) || String.IsNullOrWhiteSpace(textBox7.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Hay uno o mas campos vacios, por favor ingrese los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (comboBox1.SelectedIndex.Equals(-1))
                MessageBox.Show("Seleccione un Proveedor de la lista");
            if (comboBox2.SelectedIndex.Equals(-1))
                MessageBox.Show("Seleccione una Categoria de la lista");

            else
            {


                string texto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la contraseña de usuario de nivel Administrador", "Comprobacion", "");
                if (texto == clsUsuario.Contraseña)
                {

                    MySqlConnection conexion = BD_Comun.ObtenerConexion();
                    MySqlCommand comando = new MySqlCommand(string.Format("Update Producto set Nombre='" + this.textBox1.Text + "',Descripcion='" + this.textBox7.Text + "',Stock='" + this.textBox2.Text + "',IdCategoria='" + Convert.ToString((Int32)comboBox2.SelectedValue) + "',IdProveedor='" + Convert.ToString((Int32)comboBox1.SelectedValue) + "',PrecioUnitario='" + this.textBox6.Text + "' WHERE IdProducto= " + textBox3.Text), BD_Comun.ObtenerConexion());

                    comando.ExecuteNonQuery();
                    MessageBox.Show("Producto Modificado Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conexion.Close();
                }

                else
                {
                    MessageBox.Show("No se pudo modificar el Producto", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (radioButton1.Checked==true)
            {
                BorrarError();
                if (ValidarCampos())
                {

                    Producto pProducto = new Producto();
                    pProducto.Nombre = textBox1.Text.Trim();
                    pProducto.Descripcion = textBox7.Text.Trim();
                    pProducto.Categoria = Convert.ToInt32(comboBox2.SelectedValue);
                    pProducto.Prov = Convert.ToInt32(comboBox1.SelectedValue);
                    pProducto.Stock = Convert.ToInt32(textBox2.Text.Trim());
                    pProducto.Precio = Convert.ToDecimal(textBox6.Text.Trim());


                    int resultado = clsProducto.AgregarProducto(pProducto);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Producto Registrado Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el Producto", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Limpiar();
                    c.cargarProducto(dataGridView1);
                }
                else
                {
                    
                }
            } 
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                if (String.IsNullOrWhiteSpace(textBox5.Text))
                {

                    MessageBox.Show("Ingrese un nombre para la categoria del producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {


                    Categoria pCategoria = new Categoria();
                    pCategoria.Nombre = textBox5.Text.Trim();


                    int resultado = clsCategoria.AgregarCategoria(pCategoria);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Categoria Registrado Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar la Categoria", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;


            textBox3.Text = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            textBox1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            textBox7.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            textBox2.Text = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            textBox6.Text =Convert.ToString((Decimal)dataGridView1.Rows[e.RowIndex].Cells[6].Value);

           comboBox2.SelectedValue = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[4].Value);
           comboBox1.SelectedValue = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[5].Value);
        
            Habilitar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modificar();
            c.cargarProducto(dataGridView1);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


                clsProducto.EliminarProducto(id);

                if (id > 0)
                {

                    MessageBox.Show("Producto eliminado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar una fila para eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
               
            }
            c.cargarProducto(dataGridView1);
            Limpiar();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnVerCategorias_Click(object sender, EventArgs e)
        {
            this.Hide();
           ListaCategorias bcategorias = new ListaCategorias();
           bcategorias.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            Deshabilitar();
            button5.Enabled = true;
            textBox5.Enabled = true;
            textBox4.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            btnVerCategorias.Enabled = true;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox2.Enabled = true;
            Habilitar();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = false;
            btnVerCategorias.Enabled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Numeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Letras(e);
        }

        public bool ValidarCampos()
        {
            bool ok = true;
            if (textBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox1, "Ingresar producto");

            }

            if (textBox6.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox6, "Ingresar precio");

            }

            if (textBox7.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox7, "Ingresar descripción");

            }

            if (textBox2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox2, "Ingresar cantidad");

            }

          
            return ok;
        }

        public void BorrarError()
        {
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(textBox7, "");
            errorProvider1.SetError(textBox6, "");
            errorProvider1.SetError(textBox2, "");
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textBox6, "");
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textBox7, "");
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textBox2, "");
        }

        public void ColorFilaDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
    }
}
