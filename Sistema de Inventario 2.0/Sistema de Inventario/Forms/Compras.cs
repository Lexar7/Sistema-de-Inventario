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
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }

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

        private void Compras_Load(object sender, EventArgs e)
        {
            textBox1.Text = clsUsuario.Nombre;
            textBox2.Text = clsUsuario.Apellido;
            textBox3.Text = clsUsuario.ID;
            comboBox2.DataSource = clsProducto.Obtener();
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdProd";
            comboBox1.DataSource = clsProveedor.Obtener();
            comboBox1.DisplayMember = "IdProveedor";
            comboBox1.ValueMember = "IdProveedor";
            ColorFilaDataGridView(dataGridView1);

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
                textBox13.Text = leer["PrecioUnitario"].ToString();

            }
            else
            {
                

            }
            cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            string producto;
            double precio_uni;
            int cantidad;
            double total;

            id = Int32.Parse(textBox5.Text);
            producto = comboBox2.Text;
            precio_uni = double.Parse(textBox13.Text);
            cantidad = Int32.Parse(textBox11.Text);
            total = precio_uni * cantidad;
            dataGridView1.Rows.Add(id, producto, precio_uni, cantidad, total);


        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            decimal precio_uni;
            int cantidad;
            decimal total;
            precio_uni = Decimal.Parse(textBox13.Text);
            cantidad = Int32.Parse(textBox11.Text);
            total = precio_uni * cantidad;
            textBox12.Text = total.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server=127.0.0.1; port= 3306; database=Sistema; Uid=root; pwd=toor;");
            string cadcon = "Select * From Proveedor Where IdProveedor ='" + comboBox1.Text + "'";
            MySqlCommand cm = new MySqlCommand(cadcon, cnn);
            cnn.Open();

            MySqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                textBox8.Text = leer["Nombre"].ToString();
                

            }
            else
            {
                

            }
            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Compra pCompra = new Compra();
            pCompra.Precio_Compra = Decimal.Parse(textBox10.Text.Trim());
            pCompra.Precio_Venta = Decimal.Parse(textBox13.Text.Trim());
            pCompra.Fecha = dateTimePicker1.Text;
            pCompra.IdProv = Int32.Parse(comboBox1.Text);


            int resultado = clsCompra.AgregarCompra(pCompra);
            if (resultado > 0)
            {
                MessageBox.Show("Compra Realizada Con Exito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo realizar la compra", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            ActualizarInventario();
            DetalleCompra();
        }

        public void ActualizarInventario()
        {
            MySqlCommand comando = new MySqlCommand(string.Format("Update Producto set Stock=Stock+'" + Int32.Parse(textBox11.Text) + "' Where IdProducto=" + Int32.Parse(textBox5.Text)), BD_Comun.ObtenerConexion());

            
            comando.ExecuteNonQuery();
            
        }

        public void DetalleCompra()
        {
            Compra pCompra = new Compra();
            dCompra pdCompra = new dCompra();
            pdCompra.IdProducto = Int32.Parse(textBox5.Text);
            MySqlConnection conexion = BD_Comun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand("select IdCompra from sistema.compra order by IdCompra desc limit 1;", conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            pdCompra.IdCompra = reader.GetInt32(0);
            reader.Close();

            

            int resultado = clsCompra.AgregarDCompra(pdCompra);

        }

        public void ColorFilaDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validadcion v = new Validadcion();
            v.Numeros(e);
        }
    }
}
