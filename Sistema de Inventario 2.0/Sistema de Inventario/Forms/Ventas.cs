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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        clsVenta nv = new clsVenta();
    
        private void button5_Click(object sender, EventArgs e)
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

        private void Ventas_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            comboBox1.Text = "Seleccionar";
            textBox8.Text = clsUsuario.Nombre;
            textBox7.Text = clsUsuario.Apellido;
            textBox6.Text = clsUsuario.ID;
            comboBox2.DataSource = clsProducto.Obtener();
            comboBox1.DataSource = clsCliente.Obtener();
            ColorFilaDataGridView(dataGridView1);

            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdProd";

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            Borrar();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server=127.0.0.1; port= 3306; database=Sistema; Uid=root; pwd=toor;");
            string cadcon = "Select * From Cliente Where Nombre ='" + comboBox1.Text + "'";
            MySqlCommand cm = new MySqlCommand(cadcon, cnn);
            cnn.Open();

            MySqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                textBox1.Text = leer["Nombre"].ToString();
                textBox2.Text = leer["Apellido"].ToString();
                textBox3.Text = leer["IdCliente"].ToString();
                textBox4.Text = leer["Direccion"].ToString();
                textBox14.Text = leer["DUI"].ToString();
            }
            else
            {
                textBox1.Text = "";
                

            }
            cnn.Close();
        }
        //Limpia textbox de cliente y producto
        private void Borrar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server=127.0.0.1; port= 3306; database=Sistema; Uid=root; pwd=toor;");
            string cadcon = "Select * From Producto Where Nombre ='" + comboBox2.Text + "'";
            MySqlCommand cm = new MySqlCommand(cadcon, cnn);
            cnn.Open();

            MySqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                textBox5.Text = leer["IdProducto"].ToString();
                textBox9.Text = leer["Descripcion"].ToString();
                textBox10.Text = leer["PrecioUnitario"].ToString();
                textBox13.Text = leer["Stock"].ToString();
            }
            else
            {
                textBox1.Text = "";

            }
            cnn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        List<Venta> lista = new List<Venta>();
        public void Guardar()
        {
            Ultimo();
            if (radioButton2.Checked==true)
            {
                Venta pVenta = new Venta();
                int i= 0;
                pVenta.IdCliente = Int32.Parse(textBox3.Text);
                pVenta.IdUsuario = Int32.Parse(textBox6.Text);
                dVenta pdVenta = new dVenta();
                pdVenta.IddVenta = udVenta.IddVenta+1;
                lista.Add(pVenta);
                dataGridView1.Rows.Add(pdVenta.IddVenta.ToString(), textBox5.Text,textBox10.Text,textBox11.Text,textBox12.Text);
                i += 1;
            }
        }
        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (Int32.Parse(textBox11.Text)>Int32.Parse(textBox13.Text))
            {
                MessageBox.Show("La cantidad que quiere comprar excede el stock del producto");
            }
            else
            {
                double total = double.Parse(textBox10.Text) * Int32.Parse(textBox11.Text);
                textBox12.Text = total.ToString();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Venta pVenta = new Venta();
            pVenta.IdCliente = Int32.Parse(textBox3.Text);
            pVenta.IdUsuario = Int32.Parse(textBox6.Text);
           // pVenta.nDocumento = Convert.ToInt32(textBox14.Text);
            pVenta.nDocumento = 0;
            pVenta.tipoDocumento = "DUI";
            pVenta.Fecha = dateTimePicker1.Text;
            int resultado = clsVenta.AgregarVenta(pVenta);
            if (resultado > 0)
            {
                MessageBox.Show("Venta Registrada Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar la Venta", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Ultimo();
            for (int k = 0; k < dataGridView1.Rows.Count; k++)
            {
                dVenta pdVenta = new dVenta();
                pdVenta.IddVenta = udVenta.IddVenta + 1;
                pdVenta.IdVenta = uVenta.IdVenta;
                pdVenta.Cantidad = Int32.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString());
                pdVenta.pUnitario = Decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString());
                pdVenta.Descuento = 0;
                pdVenta.IdProducto = Int32.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString());
                int resultado2 = clsVenta.AgregarDVenta(pdVenta);
                MySqlConnection conexion = BD_Comun.ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(string.Format("Update Producto set Stock=Stock-'" + Int32.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) + "' Where IdProducto=" + Int32.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString())), BD_Comun.ObtenerConexion());

                comando.ExecuteNonQuery();

                MySqlCommand comando3 = new MySqlCommand("SELECT Stock FROM sistema.Producto Where IdProducto=" + Int32.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()), conexion);
                MySqlDataReader reader3 = comando3.ExecuteReader();
                reader3.Read();
                sProducto.Stock = reader3.GetInt32(0);
                textBox13.Text = sProducto.Stock.ToString();
                conexion.Close();
            }   
        }
        Venta uVenta = new Venta();
        dVenta udVenta = new dVenta();
        Producto sProducto = new Producto();
        public void Ultimo()
        {
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand("SELECT IdVenta FROM sistema.VENTA ORDER BY IdVenta DESC LIMIT 0,1;", conexion);
            MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                uVenta.IdVenta = reader.GetInt32(0);
            reader.Close();

            MySqlCommand comando2 = new MySqlCommand("SELECT IdDetalle_Venta FROM sistema.Detalle_Venta ORDER BY IdVenta DESC LIMIT 0,1;", conexion);
            MySqlDataReader reader2 = comando2.ExecuteReader();
            reader2.Read();
            udVenta.IddVenta = reader2.GetInt32(0);
            reader2.Close();

            conexion.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
           // lblFecha.Text = DateTime.Now.ToShortDateString();
            //FechaVenta = dateTimePicker1.Value();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Letras(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Letras(e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Numeros(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public void ColorFilaDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
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
        private void textBox4_Leave(object sender, EventArgs e)
        {
            /*if (validarEmail(textBox4.Text))
            {

            }
            else
            {
                MessageBox.Show("Correo no valido, el correo debe poseer un formato: nombre@dominio.com, "
                    + "por favor ingrese un correo valido.");
                textBox4.SelectAll();
                textBox4.Focus();
            }*/
        }
    }
    
}
