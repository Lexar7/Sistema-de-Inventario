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
using System.Text.RegularExpressions;

namespace Sistema_de_Inventario
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        BD_Comun c = new BD_Comun();

        private void button4_Click(object sender, EventArgs e)
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

        private void Clientes_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            ColorFilaDataGridView(dataGridView1);

            Deshabilitar();
            radioButton1.Checked = false;

         


            c.cargarCliente(dataGridView1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BorrarError();
            if (ValidarCampos())
            {
                Cliente pCliente = new Cliente();
                pCliente.Nombre = txtNombre.Text.Trim();
                pCliente.Apellido = txtApellido.Text.Trim();
                pCliente.DUI = txtDUI.Text.Trim();
                pCliente.Direccion = txtDireccion.Text.Trim();
                pCliente.Telefono = Convert.ToInt32(txtTelefono.Text.Trim());
                pCliente.NIT = txtNIT.Text.Trim();
                pCliente.Correo = txtCorreo.Text.Trim();



                int resultado = clsCliente.AgregarCliente(pCliente);
                if (resultado > 0)
                {
                    MessageBox.Show("Cliente Registrado Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el Cliente", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Limpiar();
                c.cargarCliente(dataGridView1);
            }
            else
            {
                
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


                clsCliente.EliminarCliente(id);

                if (id > 0)
                {

                    MessageBox.Show("Cliente eliminado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar una fila para eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            c.cargarCliente(dataGridView1);


        }


        public void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtNIT.Clear();
            txtDUI.Clear();
            txtCorreo.Clear();

        }


       public void Deshabilitar()
        {
            txtId.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtNIT.Enabled = false;
            txtDUI.Enabled = false;
            txtCorreo.Enabled = false;

        }

        public void Habilitar()
       {
           txtNombre.Enabled = true;
           txtApellido.Enabled = true;
           txtDireccion.Enabled = true;
           txtTelefono.Enabled = true;
           txtNIT.Enabled = true;
           txtDUI.Enabled = true;
           txtCorreo.Enabled = true;
           btnGuardar.Enabled = true;

       }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBuscarCliente bclientes = new frmBuscarCliente();
            bclientes.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            

            if (clsUsuario.consulta == "Administrador")
            {
                Principal pr = new Principal();
                this.Hide();
                pr.Show();
            }
            else if (clsUsuario.consulta == "Empleado")
            {
                Principal_Empleado pr2 = new Principal_Empleado();
                this.Hide();
                pr2.Show();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar();
        }


        public void Modificar()
        {
            MySqlConnection conexion = BD_Comun.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Update Cliente set Nombre='" + this.txtNombre.Text + "',Apellido='" + this.txtApellido.Text + "',DUI='" + this.txtDUI.Text + "',Direccion='" + this.txtDireccion.Text + "',Telefono='" + this.txtTelefono.Text + "',NIT='" + this.txtNIT.Text + "',Correo='" + this.txtCorreo.Text + "' WHERE IdCliente= " + txtId.Text), BD_Comun.ObtenerConexion());

            comando.ExecuteNonQuery();
            MessageBox.Show("Cliente Modificado Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conexion.Close();
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
            c.cargarCliente(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;

            txtId.Text = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            txtNombre.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            txtApellido.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            txtDUI.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            txtDireccion.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            txtTelefono.Text = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            txtNIT.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            txtCorreo.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[7].Value;
            Habilitar();


        }

        public void ColorFilaDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        public bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Ingresar nombre");

            }

            if (txtApellido.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtApellido, "Ingresar apellido");

            }

            if (txtDireccion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtDireccion, "Ingresar dirección");

            }

            if (txtDUI.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtDUI, "Ingresar DUI");

            }

            if (txtNIT.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNIT, "Ingresar NIT");

            }

            if (txtCorreo.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCorreo, "Ingresar correo");

            }

            if (txtTelefono.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtTelefono, "Ingresar telefono");

            }
            return ok;
        }
        public void BorrarError()
        {
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtDireccion, "");
            errorProvider1.SetError(txtTelefono, "");
            errorProvider1.SetError(txtDUI, "");
            errorProvider1.SetError(txtNIT, "");
            errorProvider1.SetError(txtCorreo, "");
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Letras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Letras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Numeros(e);
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
        }

        private void txtApellido_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtApellido, "");
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtTelefono, "");
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtDireccion, "");
        }

        private void txtDUI_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtDUI, "");
        }

        private void txtNIT_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtNIT, "");
        }

        private void txtCorreo_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtCorreo, "");
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }


        public static bool validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
         }
        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (validarEmail(txtCorreo.Text))
            {

            }
            else
            {
                MessageBox.Show("Correo no valido, el correo debe poseer un formato: nombre@dominio.com, "
                    + "por favor ingrese un correo valido.");
                txtCorreo.SelectAll();
                txtCorreo.Focus();
            }
        }
    }





}
