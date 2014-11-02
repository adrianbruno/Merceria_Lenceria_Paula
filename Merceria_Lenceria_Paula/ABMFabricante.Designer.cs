namespace Merceria_Lenceria_Paula
{
    partial class frmFabricante
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
            this.tablaFab = new System.Windows.Forms.DataGridView();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarFab = new System.Windows.Forms.Button();
            this.btnModificarFab = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnNuevoFab = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablaFab)).BeginInit();
            this.grpGeneral.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablaFab
            // 
            this.tablaFab.AllowUserToAddRows = false;
            this.tablaFab.AllowUserToDeleteRows = false;
            this.tablaFab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tablaFab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaFab.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descripcion});
            this.tablaFab.Location = new System.Drawing.Point(1, 2);
            this.tablaFab.MultiSelect = false;
            this.tablaFab.Name = "tablaFab";
            this.tablaFab.ReadOnly = true;
            this.tablaFab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaFab.Size = new System.Drawing.Size(331, 290);
            this.tablaFab.TabIndex = 1;
            this.tablaFab.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.groupBox2);
            this.grpGeneral.Controls.Add(this.label1);
            this.grpGeneral.Controls.Add(this.txtNombre);
            this.grpGeneral.Enabled = false;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(338, 82);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(427, 210);
            this.grpGeneral.TabIndex = 12;
            this.grpGeneral.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarFab);
            this.groupBox2.Controls.Add(this.btnModificarFab);
            this.groupBox2.Location = new System.Drawing.Point(48, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 92);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuenta";
            // 
            // btnEliminarFab
            // 
            this.btnEliminarFab.Location = new System.Drawing.Point(236, 19);
            this.btnEliminarFab.Name = "btnEliminarFab";
            this.btnEliminarFab.Size = new System.Drawing.Size(120, 61);
            this.btnEliminarFab.TabIndex = 2;
            this.btnEliminarFab.Text = "Eliminar";
            this.btnEliminarFab.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEliminarFab.UseVisualStyleBackColor = true;
            // 
            // btnModificarFab
            // 
            this.btnModificarFab.Location = new System.Drawing.Point(36, 19);
            this.btnModificarFab.Name = "btnModificarFab";
            this.btnModificarFab.Size = new System.Drawing.Size(120, 61);
            this.btnModificarFab.TabIndex = 1;
            this.btnModificarFab.Text = "Modificar";
            this.btnModificarFab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(40, 52);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(364, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // btnNuevoFab
            // 
            this.btnNuevoFab.Location = new System.Drawing.Point(517, 15);
            this.btnNuevoFab.Name = "btnNuevoFab";
            this.btnNuevoFab.Size = new System.Drawing.Size(120, 61);
            this.btnNuevoFab.TabIndex = 13;
            this.btnNuevoFab.Text = "Nuevo";
            this.btnNuevoFab.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Nombre";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 280;
            // 
            // frmFabricante
            // 
            this.AccessibleDescription = "AbmFab";
            this.AccessibleName = "AbmFab";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 304);
            this.Controls.Add(this.btnNuevoFab);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.tablaFab);
            this.Name = "frmFabricante";
            this.Text = "ABM FABRICANTES";
            ((System.ComponentModel.ISupportInitialize)(this.tablaFab)).EndInit();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaFab;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminarFab;
        private System.Windows.Forms.Button btnModificarFab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnNuevoFab;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}