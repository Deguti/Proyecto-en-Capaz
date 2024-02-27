using _02_CapaLogicaNegocio;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _01_CapaPresentacion
{
    public partial class FrmBuscarFuncionario : Form
    {
        public event EventHandler Aceptar;
        
       
        public FrmBuscarFuncionario()
        {
            InitializeComponent();
        }

        #region Load de FrmFuncionarios para cargar el dataSet
        private void FrmBuscarFuncionarios_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaDataSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CargarDataSet
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            BLFuncionario logica = new BLFuncionario(Configuracion.getConnectionString);
            DataSet DSFuncionario;

            try
            {
                DSFuncionario = logica.ListarFuncionarios(condicion, orden);
                grdLista.DataSource = DSFuncionario;
                grdLista.DataMember = DSFuncionario.Tables["Funcionarios"].TableName;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cargar Especialidades 
        public EntidadFuncionarios CargarFuncionarios(int id)
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            BLFuncionario traerFuncionario = new BLFuncionario(Configuracion.getConnectionString);
            try
            {
                funcionario = traerFuncionario.ObtenerFuncionario(id);
                if (funcionario != null)
                {
                    txtNombre.Text = funcionario.Nombre.ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return funcionario;
        }

        #endregion

        #region Doble click en dgv
        private void grdLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtener el ID del paciente de la fila seleccionada
                    int idFuncionario = Convert.ToInt32(grdLista.Rows[e.RowIndex].Cells["codigo"].Value);
                    ObtenerFuncionario(idFuncionario);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Verificar que el evento se haya disparado por hacer clic en una celda 
        }
        #endregion

        #region Obtener Funcionario
        public void ObtenerFuncionario(int id)
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            BLFuncionario logica = new BLFuncionario(Configuracion.getConnectionString);

            try
            {
                funcionario = logica.ObtenerFuncionario(id);
                if (funcionario != null)
                {
                    txtNombre.Text = funcionario.Id_funcionario.ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region boton Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    condicion = string.Format("SELECT ID_FUNCIONARIO, NOMBRE, APELLIDO1, APELLIDO2, CEDULA, PUESTO_TRABAJO, TELEFONO, BORRADO_FUNCIONARIO FROM FUNCIONARIOS WHERE NOMBRE LIKE '%{0}%'", txtNombre.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Debe escribir parte del nombre a buscar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Focus();
                }
                CargarListaDataSet(condicion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnAceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Faltan datos. Sleccione un funcionario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int id = Convert.ToInt32(txtNombre.Text);
                    Aceptar(id, null);
                    Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }
        #endregion

        #region btnCancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
