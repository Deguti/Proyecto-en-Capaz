namespace _01_CapaPresentacion
{
    partial class FrmCitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCitas));
            this.grBoXCitas = new System.Windows.Forms.GroupBox();
            this.cmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.cmbhoras = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdLista = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantPers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoHab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCitasRegistradas = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFCita = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCita = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtIdCita = new System.Windows.Forms.TextBox();
            this.idCita = new System.Windows.Forms.Label();
            this.grBoxPaciente = new System.Windows.Forms.GroupBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtId_Cliente = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCodCliente = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.grBoXCitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.grBoxPaciente.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBoXCitas
            // 
            this.grBoXCitas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grBoXCitas.Controls.Add(this.cmbEspecialidades);
            this.grBoXCitas.Controls.Add(this.cmbhoras);
            this.grBoXCitas.Controls.Add(this.label2);
            this.grBoXCitas.Controls.Add(this.grdLista);
            this.grBoXCitas.Controls.Add(this.lblCitasRegistradas);
            this.grBoXCitas.Controls.Add(this.cmbDoctor);
            this.grBoXCitas.Controls.Add(this.label1);
            this.grBoXCitas.Controls.Add(this.dtpFCita);
            this.grBoXCitas.Controls.Add(this.lblFechaCita);
            this.grBoXCitas.Controls.Add(this.lblEspecialidad);
            this.grBoXCitas.Controls.Add(this.txtIdCita);
            this.grBoXCitas.Controls.Add(this.idCita);
            this.grBoXCitas.Location = new System.Drawing.Point(12, 131);
            this.grBoXCitas.Name = "grBoXCitas";
            this.grBoXCitas.Size = new System.Drawing.Size(800, 193);
            this.grBoXCitas.TabIndex = 3;
            this.grBoXCitas.TabStop = false;
            this.grBoXCitas.Text = "Reservacion de Cita";
            // 
            // cmbEspecialidades
            // 
            this.cmbEspecialidades.FormattingEnabled = true;
            this.cmbEspecialidades.Location = new System.Drawing.Point(97, 106);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(121, 23);
            this.cmbEspecialidades.TabIndex = 16;
            this.cmbEspecialidades.SelectedValueChanged += new System.EventHandler(this.cmbEspecialidades_SelectedValueChanged);
            // 
            // cmbhoras
            // 
            this.cmbhoras.FormattingEnabled = true;
            this.cmbhoras.Location = new System.Drawing.Point(287, 116);
            this.cmbhoras.Name = "cmbhoras";
            this.cmbhoras.Size = new System.Drawing.Size(121, 23);
            this.cmbhoras.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Hora de la cita";
            // 
            // grdLista
            // 
            this.grdLista.AllowUserToAddRows = false;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.AllowUserToResizeColumns = false;
            this.grdLista.AllowUserToResizeRows = false;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.FechaIngreso,
            this.cantPers,
            this.TipoHab});
            this.grdLista.Location = new System.Drawing.Point(489, 48);
            this.grdLista.Name = "grdLista";
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.Size = new System.Drawing.Size(305, 137);
            this.grdLista.TabIndex = 0;
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "ID_CITA";
            this.codigo.HeaderText = "Id Cita";
            this.codigo.Name = "codigo";
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.DataPropertyName = "FECHA";
            this.FechaIngreso.HeaderText = "Fecha de Cita";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.Width = 110;
            // 
            // cantPers
            // 
            this.cantPers.DataPropertyName = "HORA_CITA";
            this.cantPers.HeaderText = "Hora Cita";
            this.cantPers.Name = "cantPers";
            this.cantPers.Width = 110;
            // 
            // TipoHab
            // 
            this.TipoHab.HeaderText = "borrado";
            this.TipoHab.Name = "TipoHab";
            this.TipoHab.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TipoHab.Visible = false;
            // 
            // lblCitasRegistradas
            // 
            this.lblCitasRegistradas.AutoSize = true;
            this.lblCitasRegistradas.Location = new System.Drawing.Point(590, 19);
            this.lblCitasRegistradas.Name = "lblCitasRegistradas";
            this.lblCitasRegistradas.Size = new System.Drawing.Size(96, 15);
            this.lblCitasRegistradas.TabIndex = 13;
            this.lblCitasRegistradas.Text = "Citas Registradas";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(96, 158);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(121, 23);
            this.cmbDoctor.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Doctor";
            // 
            // dtpFCita
            // 
            this.dtpFCita.Location = new System.Drawing.Point(250, 48);
            this.dtpFCita.Name = "dtpFCita";
            this.dtpFCita.Size = new System.Drawing.Size(233, 23);
            this.dtpFCita.TabIndex = 8;
            this.dtpFCita.ValueChanged += new System.EventHandler(this.dtpFCita_ValueChanged);
            // 
            // lblFechaCita
            // 
            this.lblFechaCita.AutoSize = true;
            this.lblFechaCita.Location = new System.Drawing.Point(306, 19);
            this.lblFechaCita.Name = "lblFechaCita";
            this.lblFechaCita.Size = new System.Drawing.Size(88, 15);
            this.lblFechaCita.TabIndex = 6;
            this.lblFechaCita.Text = "Fecha de la cita";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(9, 106);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(72, 15);
            this.lblEspecialidad.TabIndex = 4;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // txtIdCita
            // 
            this.txtIdCita.BackColor = System.Drawing.SystemColors.Info;
            this.txtIdCita.Location = new System.Drawing.Point(97, 48);
            this.txtIdCita.Name = "txtIdCita";
            this.txtIdCita.Size = new System.Drawing.Size(121, 23);
            this.txtIdCita.TabIndex = 1;
            // 
            // idCita
            // 
            this.idCita.AutoSize = true;
            this.idCita.Location = new System.Drawing.Point(10, 56);
            this.idCita.Name = "idCita";
            this.idCita.Size = new System.Drawing.Size(38, 15);
            this.idCita.TabIndex = 0;
            this.idCita.Text = "IdCita";
            // 
            // grBoxPaciente
            // 
            this.grBoxPaciente.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grBoxPaciente.Controls.Add(this.txtApellido);
            this.grBoxPaciente.Controls.Add(this.lblApellido);
            this.grBoxPaciente.Controls.Add(this.txtCedula);
            this.grBoxPaciente.Controls.Add(this.txtNombre);
            this.grBoxPaciente.Controls.Add(this.txtId_Cliente);
            this.grBoxPaciente.Controls.Add(this.lblCedula);
            this.grBoxPaciente.Controls.Add(this.lblNombre);
            this.grBoxPaciente.Controls.Add(this.lblCodCliente);
            this.grBoxPaciente.Controls.Add(this.btnBuscar);
            this.grBoxPaciente.Location = new System.Drawing.Point(12, 13);
            this.grBoxPaciente.Name = "grBoxPaciente";
            this.grBoxPaciente.Size = new System.Drawing.Size(800, 112);
            this.grBoxPaciente.TabIndex = 2;
            this.grBoxPaciente.TabStop = false;
            this.grBoxPaciente.Text = "Datos del Paciente";
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.SystemColors.Info;
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(494, 36);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 23);
            this.txtApellido.TabIndex = 20;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(437, 44);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 19;
            this.lblApellido.Text = "Apellido";
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.SystemColors.Info;
            this.txtCedula.Enabled = false;
            this.txtCedula.Location = new System.Drawing.Point(650, 36);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(105, 23);
            this.txtCedula.TabIndex = 17;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Info;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(331, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 23);
            this.txtNombre.TabIndex = 16;
            // 
            // txtId_Cliente
            // 
            this.txtId_Cliente.BackColor = System.Drawing.Color.White;
            this.txtId_Cliente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtId_Cliente.Location = new System.Drawing.Point(168, 36);
            this.txtId_Cliente.Name = "txtId_Cliente";
            this.txtId_Cliente.Size = new System.Drawing.Size(100, 23);
            this.txtId_Cliente.TabIndex = 15;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(600, 44);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(44, 15);
            this.lblCedula.TabIndex = 14;
            this.lblCedula.Text = "Cedula";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(274, 44);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Nombre";
            // 
            // lblCodCliente
            // 
            this.lblCodCliente.AutoSize = true;
            this.lblCodCliente.Location = new System.Drawing.Point(114, 44);
            this.lblCodCliente.Name = "lblCodCliente";
            this.lblCodCliente.Size = new System.Drawing.Size(46, 15);
            this.lblCodCliente.TabIndex = 11;
            this.lblCodCliente.Text = "Codigo";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(6, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 49);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(12, 330);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 61);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(680, 330);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(133, 61);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(158, 330);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(133, 61);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // FrmCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(825, 395);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.grBoXCitas);
            this.Controls.Add(this.grBoxPaciente);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCitas";
            this.ShowIcon = false;
            this.Text = "FrmCitas";
            this.Load += new System.EventHandler(this.FrmCitas_Load);
            this.grBoXCitas.ResumeLayout(false);
            this.grBoXCitas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.grBoxPaciente.ResumeLayout(false);
            this.grBoxPaciente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBoXCitas;
        private System.Windows.Forms.DateTimePicker dtpFCita;
        private System.Windows.Forms.Label lblFechaCita;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txtIdCita;
        private System.Windows.Forms.Label idCita;
        private System.Windows.Forms.GroupBox grBoxPaciente;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtId_Cliente;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCodCliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblCitasRegistradas;
        private System.Windows.Forms.ComboBox cmbhoras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEspecialidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantPers;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoHab;
    }
}