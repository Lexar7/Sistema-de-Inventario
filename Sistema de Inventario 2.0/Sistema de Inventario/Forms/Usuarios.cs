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
using Microsoft.VisualBasic;
using Sistema_de_Inventario.Classes_metodos;
using Sistema_de_Inventario.Classes_constructoras;

namespace Sistema_de_Inventario
{
    public partial class Usuarios : Form
    {
        BD_Comun c = new BD_Comun();
        
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            BorrarError();
            if (ValidarCampos())

            {
                Usuario pUsuario = new Usuario();
                pUsuario.Nombre = txtNombre.Text.Trim();
                pUsuario.Apellido = txtApellido.Text.Trim();
                pUsuario.Direccion = txtDireccion.Text.Trim();
                pUsuario.Fecha_Nac = txtFecha.Text.Trim();
                pUsuario.Telefono = Convert.ToInt32(txtTelefono.Text.Trim().ToString());
                pUsuario.Usuarios = txtUsuario.Text.Trim();
                pUsuario.Password = txtPassword.Text.Trim();
                pUsuario.Cargo = "Empleado";


                int resultado = clsUsuario.AgregarUsuario(pUsuario);

                if (resultado > 0)
                {
                    MessageBox.Show("Usuario Registrado Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el Usuario", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Limpiar();
                c.cargarUsuario(dataGridView1);
            }
            else
            {
                
            }
        }



        private void Usuarios_Load(object sender, EventArgs e)
        {
            BD_Comun c = new BD_Comun();
            Deshabilitar();
            txtBApellido.Enabled = false;
            txtBNombre.Enabled = false;
            btnBuscar.Enabled = false;
            c.cargarUsuario(dataGridView1);
         
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                clsUsuario.EliminarUsuario(id);

                if (id > 0)
                {
                    
                    MessageBox.Show("Usuario eliminado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar una fila para eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

              }
            c.cargarUsuario(dataGridView1);
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

         private void button1_Click(object sender, EventArgs e)
        {
               txtId.Enabled = false;
               Modificar();
               c.cargarUsuario(dataGridView1);
              

        }

        //Metodo Modificar Usuarios
         public void Modificar()
         {
            string texto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la contraseña de usuario de nivel Administrador", "Comprobacion", "");
            if (texto == clsUsuario.Contraseña)
            {
                MySqlConnection conexion = BD_Comun.ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(string.Format("Update Usuarios set Nombre='" + this.txtNombre.Text + "',Apellido='" + this.txtApellido.Text + "',Direccion='" + this.txtDireccion.Text + "',FechaNac='" + this.txtFecha.Text + "',Telefono='" + this.txtTelefono.Text + "',Usuario='" + this.txtUsuario.Text + "',Password='" + this.txtPassword.Text + "',Cargo='" + this.rbEmpleado.Text + "' WHERE IdUsuario= " + txtId.Text), BD_Comun.ObtenerConexion());

                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Modificado Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
         }


         private void btnBuscar_Click(object sender, EventArgs e)
         {
            BorrarError();
             if (ValidarCampos2())
             {

                dataGridView1.DataSource = clsUsuario.Buscar(txtBNombre.Text, txtBApellido.Text);
             }
             else
             {

             
             }
         }



         public void Limpiar()
         {
             txtId.Clear();
             txtNombre.Clear();
             txtApellido.Clear();
             txtDireccion.Clear();
             txtFecha.Clear();
             txtTelefono.Clear();
             txtUsuario.Clear();
             txtPassword.Clear();
                 
         }
         void Deshabilitar()
         {
             txtId.Enabled = false;
             txtNombre.Enabled = false;
             txtApellido.Enabled = false;
             txtDireccion.Enabled = false;
             txtFecha.Enabled = false;
             txtTelefono.Enabled = false;
             txtUsuario.Enabled = false;
             txtPassword.Enabled = false;
             btnEliminar.Enabled = false;
             btnRegistrar.Enabled = false;
             btnModificar.Enabled = false;
             //rbEmpleado.Enabled = false;
         }


         void Habilitar()
         {
             txtNombre.Enabled = true;
             txtApellido.Enabled = true;
             txtDireccion.Enabled = true;
             txtFecha.Enabled = true;
             txtTelefono.Enabled = true;
             txtUsuario.Enabled = true;
             txtPassword.Enabled = true;
             btnRegistrar.Enabled = true;
         }

         private void btnNuevo_Click(object sender, EventArgs e)
         {
             c.cargarUsuario(dataGridView1);
             btnRegistrar.Enabled = true;
             Habilitar();
             Limpiar();
         }

         private void btnBuscar1_Click(object sender, EventArgs e)
         {
             btnBuscar.Enabled = true;
             txtBNombre.Enabled = true;
             txtBApellido.Enabled = true;
             Deshabilitar();
             Limpiar();
         }

         private void btnSalir_Click(object sender, EventArgs e)
         {
             Principal principal = new Principal();
             principal.Show();
            this.Close();
        }

         private void pictureBox1_Click(object sender, EventArgs e)
         {

         }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;

            txtId.Text = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            txtNombre.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            txtApellido.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            txtDireccion.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            txtFecha.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            txtTelefono.Text = Convert.ToString((Int32)dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            txtUsuario.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            txtPassword.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[7].Value;

            Habilitar();

        }


        public bool ValidarCampos()
        {
            bool ok = true;
            if(txtNombre.Text=="")
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

            if (txtFecha.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtFecha, "Ingresar fecha");

            }

            if (txtTelefono.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtTelefono, "Ingresar telefono");

            }

            if (txtUsuario.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtUsuario, "Ingresar usuario");

            }

            if (txtPassword.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtPassword, "Ingresar contraseña");

            }
            return ok;
        }
        public bool ValidarCampos2()
        {
            bool ok = true;
            if (txtBNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtBNombre, "Ingresar nombre");

            }

            if (txtBApellido.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtBApellido, "Ingresar apellido");

            }
            return ok;
         }
        public void BorrarError()
        {
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtDireccion, "");
            errorProvider1.SetError(txtFecha, "");
            errorProvider1.SetError(txtTelefono, "");
            errorProvider1.SetError(txtUsuario, "");
            errorProvider1.SetError(txtPassword, "");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {

            errorProvider1.SetError(txtNombre, "");
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Letras(e);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

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

        private void txtApellido_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtApellido, "");
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtDireccion, "");
        }

        private void txtFecha_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtFecha, "");
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtTelefono, "");
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtUsuario, "");
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtPassword, "");
        }

        private void txtBNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Letras(e);
        }

        private void txtBApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Letras(e);
        }

        private void txtBNombre_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtBNombre, "");
        }

        private void txtBApellido_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtBApellido, "");
        }
    }

   

}

       

