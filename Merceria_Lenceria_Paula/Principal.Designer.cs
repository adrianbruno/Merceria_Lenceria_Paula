namespace Merceria_Lenceria_Paula
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.btnLoginLogout = new System.Windows.Forms.Button();
            this.btnControl_Stock = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnMantenimiento = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tooUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tooNivelAcceso = new System.Windows.Forms.ToolStripStatusLabel();
            this.tooDetalle = new System.Windows.Forms.ToolStripStatusLabel();
            this.tooVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCambiarContraseña = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoginLogout
            // 
            this.btnLoginLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLoginLogout.Font = new System.Drawing.Font("News706 BT", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginLogout.Location = new System.Drawing.Point(539, 155);
            this.btnLoginLogout.Name = "btnLoginLogout";
            this.btnLoginLogout.Size = new System.Drawing.Size(362, 131);
            this.btnLoginLogout.TabIndex = 9;
            this.btnLoginLogout.Tag = "C";
            this.btnLoginLogout.Text = "&Conectarme";
            this.btnLoginLogout.UseVisualStyleBackColor = true;
            this.btnLoginLogout.Click += new System.EventHandler(this.btnLoginLogout_Click);
            // 
            // btnControl_Stock
            // 
            this.btnControl_Stock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnControl_Stock.Enabled = false;
            this.btnControl_Stock.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnControl_Stock.FlatAppearance.BorderSize = 3;
            this.btnControl_Stock.Font = new System.Drawing.Font("News706 BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControl_Stock.Image = ((System.Drawing.Image)(resources.GetObject("btnControl_Stock.Image")));
            this.btnControl_Stock.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnControl_Stock.Location = new System.Drawing.Point(261, 12);
            this.btnControl_Stock.Name = "btnControl_Stock";
            this.btnControl_Stock.Size = new System.Drawing.Size(219, 68);
            this.btnControl_Stock.TabIndex = 2;
            this.btnControl_Stock.Text = "C&ontrol Stock";
            this.btnControl_Stock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnControl_Stock.UseVisualStyleBackColor = true;
            this.btnControl_Stock.Click += new System.EventHandler(this.btnControl_Stock_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFacturar.Enabled = false;
            this.btnFacturar.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnFacturar.FlatAppearance.BorderSize = 3;
            this.btnFacturar.Font = new System.Drawing.Font("News706 BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturar.Image")));
            this.btnFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturar.Location = new System.Drawing.Point(17, 12);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(221, 68);
            this.btnFacturar.TabIndex = 1;
            this.btnFacturar.Text = "&Venta";
            this.btnFacturar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(544, 309);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUsuarios.Enabled = false;
            this.btnUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnUsuarios.FlatAppearance.BorderSize = 3;
            this.btnUsuarios.Font = new System.Drawing.Font("News706 BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsuarios.Location = new System.Drawing.Point(261, 102);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(219, 68);
            this.btnUsuarios.TabIndex = 4;
            this.btnUsuarios.Text = "&Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProveedores.Enabled = false;
            this.btnProveedores.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnProveedores.FlatAppearance.BorderSize = 3;
            this.btnProveedores.Font = new System.Drawing.Font("News706 BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedores.Image")));
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProveedores.Location = new System.Drawing.Point(17, 102);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(221, 68);
            this.btnProveedores.TabIndex = 3;
            this.btnProveedores.Text = "&Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnMantenimiento
            // 
            this.btnMantenimiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMantenimiento.Enabled = false;
            this.btnMantenimiento.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnMantenimiento.FlatAppearance.BorderSize = 3;
            this.btnMantenimiento.Font = new System.Drawing.Font("News706 BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimiento.Image = ((System.Drawing.Image)(resources.GetObject("btnMantenimiento.Image")));
            this.btnMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMantenimiento.Location = new System.Drawing.Point(261, 192);
            this.btnMantenimiento.Name = "btnMantenimiento";
            this.btnMantenimiento.Size = new System.Drawing.Size(219, 68);
            this.btnMantenimiento.TabIndex = 6;
            this.btnMantenimiento.Text = "&Mantenimiento";
            this.btnMantenimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenimiento.UseVisualStyleBackColor = true;
            this.btnMantenimiento.Click += new System.EventHandler(this.btnMantenimiento_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClientes.Enabled = false;
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnClientes.FlatAppearance.BorderSize = 3;
            this.btnClientes.Font = new System.Drawing.Font("News706 BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientes.Location = new System.Drawing.Point(17, 192);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(221, 68);
            this.btnClientes.TabIndex = 5;
            this.btnClientes.Text = "&Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(-4, 511);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(264, 24);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Chequeando Intregridad ...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("News706 BT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooUsuario,
            this.tooNivelAcceso,
            this.tooDetalle,
            this.tooVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(908, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tooUsuario
            // 
            this.tooUsuario.AutoSize = false;
            this.tooUsuario.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tooUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.tooUsuario.Name = "tooUsuario";
            this.tooUsuario.Size = new System.Drawing.Size(150, 17);
            this.tooUsuario.Text = "Usuario:";
            this.tooUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tooNivelAcceso
            // 
            this.tooNivelAcceso.AutoSize = false;
            this.tooNivelAcceso.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tooNivelAcceso.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.tooNivelAcceso.Name = "tooNivelAcceso";
            this.tooNivelAcceso.Size = new System.Drawing.Size(150, 17);
            this.tooNivelAcceso.Text = "Nivel:";
            this.tooNivelAcceso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tooDetalle
            // 
            this.tooDetalle.AutoSize = false;
            this.tooDetalle.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tooDetalle.Name = "tooDetalle";
            this.tooDetalle.Size = new System.Drawing.Size(400, 17);
            // 
            // tooVersion
            // 
            this.tooVersion.AutoSize = false;
            this.tooVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tooVersion.Name = "tooVersion";
            this.tooVersion.Size = new System.Drawing.Size(150, 17);
            this.tooVersion.Text = "Version";
            this.tooVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(539, 36);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(357, 31);
            this.txtUsuario.TabIndex = 7;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(539, 99);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(357, 31);
            this.txtContraseña.TabIndex = 8;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Contraseña";
            // 
            // btnCambiarContraseña
            // 
            this.btnCambiarContraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCambiarContraseña.Enabled = false;
            this.btnCambiarContraseña.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnCambiarContraseña.FlatAppearance.BorderSize = 3;
            this.btnCambiarContraseña.Font = new System.Drawing.Font("News706 BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarContraseña.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarContraseña.Location = new System.Drawing.Point(17, 433);
            this.btnCambiarContraseña.Name = "btnCambiarContraseña";
            this.btnCambiarContraseña.Size = new System.Drawing.Size(219, 68);
            this.btnCambiarContraseña.TabIndex = 15;
            this.btnCambiarContraseña.Text = "C&ambiar Contraseña";
            this.btnCambiarContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarContraseña.UseVisualStyleBackColor = true;
            this.btnCambiarContraseña.Click += new System.EventHandler(this.btnCambiarContraseña_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnLoginLogout;
            this.ClientSize = new System.Drawing.Size(908, 562);
            this.Controls.Add(this.btnCambiarContraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnMantenimiento);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnProveedores);
            this.Controls.Add(this.btnControl_Stock);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnLoginLogout);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("News706 BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frmPrincipal_Activated);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoginLogout;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnControl_Stock;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnMantenimiento;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tooUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tooVersion;
        private System.Windows.Forms.ToolStripStatusLabel tooNivelAcceso;
        private System.Windows.Forms.ToolStripStatusLabel tooDetalle;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCambiarContraseña;
    }
}

