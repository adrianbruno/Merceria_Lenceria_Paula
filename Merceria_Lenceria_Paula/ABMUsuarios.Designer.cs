namespace Merceria_Lenceria_Paula
{
    partial class ABMUsuarios
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuenta_activa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCambiarPass = new System.Windows.Forms.Button();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.grpNivel = new System.Windows.Forms.GroupBox();
            this.radManager = new System.Windows.Forms.RadioButton();
            this.radSupervisor = new System.Windows.Forms.RadioButton();
            this.radVenta = new System.Windows.Forms.RadioButton();
            this.btnEditarGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpGeneral.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpNivel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.login,
            this.Nombre,
            this.Apellido,
            this.nivel,
            this.cuenta_activa});
            this.dataGridView1.Location = new System.Drawing.Point(11, 32);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(760, 226);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // login
            // 
            this.login.Frozen = true;
            this.login.HeaderText = "Login";
            this.login.Name = "login";
            this.login.ReadOnly = true;
            this.login.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 280;
            // 
            // Apellido
            // 
            this.Apellido.Frozen = true;
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 280;
            // 
            // nivel
            // 
            this.nivel.HeaderText = "nivel";
            this.nivel.Name = "nivel";
            this.nivel.ReadOnly = true;
            this.nivel.Visible = false;
            // 
            // cuenta_activa
            // 
            this.cuenta_activa.HeaderText = "cuenta_activa";
            this.cuenta_activa.Name = "cuenta_activa";
            this.cuenta_activa.ReadOnly = true;
            this.cuenta_activa.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(639, 495);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 61);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblLogin);
            this.grpGeneral.Controls.Add(this.txtLogin);
            this.grpGeneral.Controls.Add(this.groupBox2);
            this.grpGeneral.Controls.Add(this.label2);
            this.grpGeneral.Controls.Add(this.label1);
            this.grpGeneral.Controls.Add(this.txtApellido);
            this.grpGeneral.Controls.Add(this.txtNombre);
            this.grpGeneral.Controls.Add(this.grpNivel);
            this.grpGeneral.Enabled = false;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(6, 264);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(769, 223);
            this.grpGeneral.TabIndex = 11;
            this.grpGeneral.TabStop = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(77, 35);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(132, 19);
            this.lblLogin.TabIndex = 23;
            this.lblLogin.Text = "Login de acceso";
            // 
            // txtLogin
            // 
            this.txtLogin.Enabled = false;
            this.txtLogin.Location = new System.Drawing.Point(81, 57);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(241, 27);
            this.txtLogin.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCambiarPass);
            this.groupBox2.Controls.Add(this.chkHabilitado);
            this.groupBox2.Location = new System.Drawing.Point(399, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 100);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuenta";
            // 
            // btnCambiarPass
            // 
            this.btnCambiarPass.Location = new System.Drawing.Point(236, 26);
            this.btnCambiarPass.Name = "btnCambiarPass";
            this.btnCambiarPass.Size = new System.Drawing.Size(120, 61);
            this.btnCambiarPass.TabIndex = 1;
            this.btnCambiarPass.Text = "Cambiar Password";
            this.btnCambiarPass.UseVisualStyleBackColor = true;
            this.btnCambiarPass.Click += new System.EventHandler(this.btnCambiarPass_Click);
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(16, 29);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(110, 23);
            this.chkHabilitado.TabIndex = 0;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            this.chkHabilitado.CheckedChanged += new System.EventHandler(this.chkHabilitado_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nombre";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(397, 87);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(365, 27);
            this.txtApellido.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(397, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(364, 27);
            this.txtNombre.TabIndex = 1;
            // 
            // grpNivel
            // 
            this.grpNivel.Controls.Add(this.radManager);
            this.grpNivel.Controls.Add(this.radSupervisor);
            this.grpNivel.Controls.Add(this.radVenta);
            this.grpNivel.Location = new System.Drawing.Point(7, 117);
            this.grpNivel.Name = "grpNivel";
            this.grpNivel.Size = new System.Drawing.Size(379, 100);
            this.grpNivel.TabIndex = 16;
            this.grpNivel.TabStop = false;
            this.grpNivel.Text = "Nivel de usuario";
            // 
            // radManager
            // 
            this.radManager.AutoSize = true;
            this.radManager.Location = new System.Drawing.Point(276, 45);
            this.radManager.Name = "radManager";
            this.radManager.Size = new System.Drawing.Size(97, 23);
            this.radManager.TabIndex = 10;
            this.radManager.TabStop = true;
            this.radManager.Text = "Manager";
            this.radManager.UseVisualStyleBackColor = true;
            this.radManager.CheckedChanged += new System.EventHandler(this.radManager_CheckedChanged);
            // 
            // radSupervisor
            // 
            this.radSupervisor.AutoSize = true;
            this.radSupervisor.Location = new System.Drawing.Point(127, 45);
            this.radSupervisor.Name = "radSupervisor";
            this.radSupervisor.Size = new System.Drawing.Size(113, 23);
            this.radSupervisor.TabIndex = 9;
            this.radSupervisor.TabStop = true;
            this.radSupervisor.Text = "Supervisor";
            this.radSupervisor.UseVisualStyleBackColor = true;
            this.radSupervisor.CheckedChanged += new System.EventHandler(this.radSupervisor_CheckedChanged);
            // 
            // radVenta
            // 
            this.radVenta.AutoSize = true;
            this.radVenta.Location = new System.Drawing.Point(19, 45);
            this.radVenta.Name = "radVenta";
            this.radVenta.Size = new System.Drawing.Size(72, 23);
            this.radVenta.TabIndex = 8;
            this.radVenta.TabStop = true;
            this.radVenta.Text = "Venta";
            this.radVenta.UseVisualStyleBackColor = true;
            this.radVenta.CheckedChanged += new System.EventHandler(this.radVenta_CheckedChanged);
            // 
            // btnEditarGuardar
            // 
            this.btnEditarGuardar.Location = new System.Drawing.Point(138, 495);
            this.btnEditarGuardar.Name = "btnEditarGuardar";
            this.btnEditarGuardar.Size = new System.Drawing.Size(120, 61);
            this.btnEditarGuardar.TabIndex = 1;
            this.btnEditarGuardar.Tag = "E";
            this.btnEditarGuardar.Text = "&Editar";
            this.btnEditarGuardar.UseVisualStyleBackColor = true;
            this.btnEditarGuardar.Click += new System.EventHandler(this.btnEditarGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(271, 495);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 61);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Tag = "E";
            this.btnCancelar.Text = "C&ancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(7, 494);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 61);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Tag = "E";
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // ABMUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditarGuardar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ABMUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta, Baja o Modificacion de Usuarios";
            this.Load += new System.EventHandler(this.ABMUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpNivel.ResumeLayout(false);
            this.grpNivel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuenta_activa;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.GroupBox grpNivel;
        private System.Windows.Forms.RadioButton radManager;
        private System.Windows.Forms.RadioButton radSupervisor;
        private System.Windows.Forms.RadioButton radVenta;
        private System.Windows.Forms.Button btnEditarGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCambiarPass;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
    }
}