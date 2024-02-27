namespace _01_CapaPresentacion
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuAdmClin = new System.Windows.Forms.ToolStripMenuItem();
            this.admPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.admFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.admEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.admHorarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdmCitas = new System.Windows.Forms.ToolStripMenuItem();
            this.admCitas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria Math", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(2, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(519, 268);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clinica el buen Vivir";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAdmClin,
            this.MenuAdmCitas,
            this.menuSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuAdmClin
            // 
            this.MenuAdmClin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.admPacientes,
            this.admFuncionarios,
            this.admEspecialidades,
            this.admHorarios});
            this.MenuAdmClin.Name = "MenuAdmClin";
            this.MenuAdmClin.Size = new System.Drawing.Size(167, 20);
            this.MenuAdmClin.Text = "Administracion de la Clinica";
            // 
            // admPacientes
            // 
            this.admPacientes.Name = "admPacientes";
            this.admPacientes.Size = new System.Drawing.Size(250, 22);
            this.admPacientes.Text = "Administracion de Pacientes";
            this.admPacientes.Click += new System.EventHandler(this.admPacientes_Click);
            // 
            // admFuncionarios
            // 
            this.admFuncionarios.Name = "admFuncionarios";
            this.admFuncionarios.Size = new System.Drawing.Size(250, 22);
            this.admFuncionarios.Text = "Administracion de funcionarios";
            this.admFuncionarios.Click += new System.EventHandler(this.admFuncionarios_Click);
            // 
            // admEspecialidades
            // 
            this.admEspecialidades.Name = "admEspecialidades";
            this.admEspecialidades.Size = new System.Drawing.Size(250, 22);
            this.admEspecialidades.Text = "Administracion de Especialidades";
            this.admEspecialidades.Click += new System.EventHandler(this.admEspecialidades_Click);
            // 
            // admHorarios
            // 
            this.admHorarios.Name = "admHorarios";
            this.admHorarios.Size = new System.Drawing.Size(250, 22);
            this.admHorarios.Text = "Administracion de Horarios";
            this.admHorarios.Click += new System.EventHandler(this.admHorarios_Click);
            // 
            // MenuAdmCitas
            // 
            this.MenuAdmCitas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.admCitas});
            this.MenuAdmCitas.Name = "MenuAdmCitas";
            this.MenuAdmCitas.Size = new System.Drawing.Size(145, 20);
            this.MenuAdmCitas.Text = "Administracion de Citas";
            // 
            // admCitas
            // 
            this.admCitas.Name = "admCitas";
            this.admCitas.Size = new System.Drawing.Size(200, 22);
            this.admCitas.Text = "Administracion de Citas";
            this.admCitas.Click += new System.EventHandler(this.admCitas_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(41, 20);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.ShowIcon = false;
            this.Text = "Clinica el buen Vivir";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuAdmClin;
        private System.Windows.Forms.ToolStripMenuItem admPacientes;
        private System.Windows.Forms.ToolStripMenuItem admFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem admEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem admHorarios;
        private System.Windows.Forms.ToolStripMenuItem MenuAdmCitas;
        private System.Windows.Forms.ToolStripMenuItem admCitas;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
    }
}