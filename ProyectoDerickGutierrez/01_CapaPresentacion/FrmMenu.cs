using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _01_CapaPresentacion
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void admPacientes_Click(object sender, EventArgs e)
        {
            FrmPacientes frmP = new FrmPacientes();
            frmP.ShowDialog();
        }

        private void admFuncionarios_Click(object sender, EventArgs e)
        {
            FrmFuncionarios frmF = new FrmFuncionarios();
            frmF.ShowDialog();    
        }

        private void admHorarios_Click(object sender, EventArgs e)
        {
            FrmHorarios frmH = new FrmHorarios();
            frmH.ShowDialog();
        }

        private void admEspecialidades_Click(object sender, EventArgs e)
        {
            FrmEspecialidades frmE = new FrmEspecialidades();
            frmE.ShowDialog();
        }

        private void admCitas_Click(object sender, EventArgs e)
        {
            FrmCitas frmC = new FrmCitas();
            frmC.ShowDialog();
        }
    }
}
