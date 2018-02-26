namespace Caceres_s_Car.Forms
{
    partial class CrearUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearUsuario));
            this.label1 = new System.Windows.Forms.Label();
            this.cb_cargo = new System.Windows.Forms.ComboBox();
            this.cb_dia = new System.Windows.Forms.ComboBox();
            this.cb_mes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_año = new System.Windows.Forms.ComboBox();
            this.bt_ingresar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNombre = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtApellido = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtDireccion = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtTelefono = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtUser = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.tb_contraseña = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(91, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo Usuario";
            // 
            // cb_cargo
            // 
            this.cb_cargo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_cargo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cargo.FormattingEnabled = true;
            this.cb_cargo.Items.AddRange(new object[] {
            "Administrador\t",
            "Empleado"});
            this.cb_cargo.Location = new System.Drawing.Point(15, 327);
            this.cb_cargo.Name = "cb_cargo";
            this.cb_cargo.Size = new System.Drawing.Size(165, 29);
            this.cb_cargo.TabIndex = 17;
            this.cb_cargo.Text = "Cargo";
            // 
            // cb_dia
            // 
            this.cb_dia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_dia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_dia.FormattingEnabled = true;
            this.cb_dia.Items.AddRange(new object[] {
            "1\t",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cb_dia.Location = new System.Drawing.Point(15, 405);
            this.cb_dia.Name = "cb_dia";
            this.cb_dia.Size = new System.Drawing.Size(53, 29);
            this.cb_dia.TabIndex = 18;
            this.cb_dia.Text = "Día";
            // 
            // cb_mes
            // 
            this.cb_mes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_mes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_mes.FormattingEnabled = true;
            this.cb_mes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cb_mes.Location = new System.Drawing.Point(74, 405);
            this.cb_mes.Name = "cb_mes";
            this.cb_mes.Size = new System.Drawing.Size(125, 29);
            this.cb_mes.TabIndex = 19;
            this.cb_mes.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(12, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fecha de nacimiento";
            // 
            // cb_año
            // 
            this.cb_año.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_año.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_año.FormattingEnabled = true;
            this.cb_año.Location = new System.Drawing.Point(209, 405);
            this.cb_año.Name = "cb_año";
            this.cb_año.Size = new System.Drawing.Size(73, 29);
            this.cb_año.TabIndex = 21;
            this.cb_año.Text = "Año";
            // 
            // bt_ingresar
            // 
            this.bt_ingresar.BackColor = System.Drawing.Color.LimeGreen;
            this.bt_ingresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ingresar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ingresar.ForeColor = System.Drawing.Color.White;
            this.bt_ingresar.Location = new System.Drawing.Point(27, 451);
            this.bt_ingresar.Name = "bt_ingresar";
            this.bt_ingresar.Size = new System.Drawing.Size(159, 44);
            this.bt_ingresar.TabIndex = 22;
            this.bt_ingresar.Text = "Crear Usuario";
            this.bt_ingresar.UseVisualStyleBackColor = false;
            this.bt_ingresar.Click += new System.EventHandler(this.bt_ingresar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(220, 451);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 44);
            this.button1.TabIndex = 23;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.HintForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.HintText = "Nombre";
            this.txtNombre.isPassword = false;
            this.txtNombre.LineFocusedColor = System.Drawing.Color.OrangeRed;
            this.txtNombre.LineIdleColor = System.Drawing.Color.Gray;
            this.txtNombre.LineMouseHoverColor = System.Drawing.Color.OrangeRed;
            this.txtNombre.LineThickness = 3;
            this.txtNombre.Location = new System.Drawing.Point(16, 55);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(183, 33);
            this.txtNombre.TabIndex = 24;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtApellido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtApellido.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtApellido.ForeColor = System.Drawing.Color.Black;
            this.txtApellido.HintForeColor = System.Drawing.Color.DimGray;
            this.txtApellido.HintText = "Apellido";
            this.txtApellido.isPassword = false;
            this.txtApellido.LineFocusedColor = System.Drawing.Color.OrangeRed;
            this.txtApellido.LineIdleColor = System.Drawing.Color.Gray;
            this.txtApellido.LineMouseHoverColor = System.Drawing.Color.OrangeRed;
            this.txtApellido.LineThickness = 3;
            this.txtApellido.Location = new System.Drawing.Point(209, 55);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(183, 33);
            this.txtApellido.TabIndex = 25;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDireccion.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtDireccion.ForeColor = System.Drawing.Color.Black;
            this.txtDireccion.HintForeColor = System.Drawing.Color.DimGray;
            this.txtDireccion.HintText = "Dirección";
            this.txtDireccion.isPassword = false;
            this.txtDireccion.LineFocusedColor = System.Drawing.Color.OrangeRed;
            this.txtDireccion.LineIdleColor = System.Drawing.Color.Gray;
            this.txtDireccion.LineMouseHoverColor = System.Drawing.Color.OrangeRed;
            this.txtDireccion.LineThickness = 3;
            this.txtDireccion.Location = new System.Drawing.Point(16, 116);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(243, 33);
            this.txtDireccion.TabIndex = 26;
            this.txtDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTelefono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTelefono.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTelefono.ForeColor = System.Drawing.Color.Black;
            this.txtTelefono.HintForeColor = System.Drawing.Color.DimGray;
            this.txtTelefono.HintText = "Teléfono";
            this.txtTelefono.isPassword = false;
            this.txtTelefono.LineFocusedColor = System.Drawing.Color.OrangeRed;
            this.txtTelefono.LineIdleColor = System.Drawing.Color.Gray;
            this.txtTelefono.LineMouseHoverColor = System.Drawing.Color.OrangeRed;
            this.txtTelefono.LineThickness = 3;
            this.txtTelefono.Location = new System.Drawing.Point(15, 171);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(186, 33);
            this.txtTelefono.TabIndex = 27;
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTelefono.OnValueChanged += new System.EventHandler(this.bunifuMaterialTextbox4_OnValueChanged);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.HintForeColor = System.Drawing.Color.DimGray;
            this.txtUser.HintText = "Usuario";
            this.txtUser.isPassword = false;
            this.txtUser.LineFocusedColor = System.Drawing.Color.OrangeRed;
            this.txtUser.LineIdleColor = System.Drawing.Color.Gray;
            this.txtUser.LineMouseHoverColor = System.Drawing.Color.OrangeRed;
            this.txtUser.LineThickness = 3;
            this.txtUser.Location = new System.Drawing.Point(16, 222);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(183, 33);
            this.txtUser.TabIndex = 28;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tb_contraseña
            // 
            this.tb_contraseña.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tb_contraseña.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_contraseña.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tb_contraseña.ForeColor = System.Drawing.Color.DimGray;
            this.tb_contraseña.HintForeColor = System.Drawing.Color.DimGray;
            this.tb_contraseña.HintText = "";
            this.tb_contraseña.isPassword = false;
            this.tb_contraseña.LineFocusedColor = System.Drawing.Color.OrangeRed;
            this.tb_contraseña.LineIdleColor = System.Drawing.Color.Gray;
            this.tb_contraseña.LineMouseHoverColor = System.Drawing.Color.OrangeRed;
            this.tb_contraseña.LineThickness = 3;
            this.tb_contraseña.Location = new System.Drawing.Point(16, 273);
            this.tb_contraseña.Margin = new System.Windows.Forms.Padding(4);
            this.tb_contraseña.Name = "tb_contraseña";
            this.tb_contraseña.Size = new System.Drawing.Size(183, 33);
            this.tb_contraseña.TabIndex = 30;
            this.tb_contraseña.Text = "Contraseña";
            this.tb_contraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_contraseña.Enter += new System.EventHandler(this.tb_contraseña_Enter);
            this.tb_contraseña.Leave += new System.EventHandler(this.tb_contraseña_Leave);
            // 
            // CrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(402, 518);
            this.Controls.Add(this.tb_contraseña);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_ingresar);
            this.Controls.Add(this.cb_año);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_mes);
            this.Controls.Add(this.cb_dia);
            this.Controls.Add(this.cb_cargo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrearUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrearUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_cargo;
        private System.Windows.Forms.ComboBox cb_dia;
        private System.Windows.Forms.ComboBox cb_mes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_año;
        private System.Windows.Forms.Button bt_ingresar;
        private System.Windows.Forms.Button button1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtNombre;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtApellido;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtDireccion;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTelefono;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtUser;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tb_contraseña;
    }
}