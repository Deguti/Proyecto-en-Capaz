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
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }
        #region Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Crear entidad Funcionarios
        public EntidadFuncionarios GenerarEntidadFuncionario()
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            funcionario.Nombre = txtNombre.Text;
            funcionario.Apellido1 = txtPrimerApellido.Text;
            funcionario.Apellido2 = txtSegundoApellido.Text;
            funcionario.Cedula = txtCedula.Text;
            funcionario.Telefono = txtTelefono.Text;
            funcionario.Puesto = txtPuesto.Text;
            funcionario.Borrado = false;
            return funcionario;
        }
        #endregion

        #region Crear entidad Funcionarios para borrar
        public EntidadFuncionarios GenerarEntidadFuncionariosBorrado()
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            funcionario.Id_funcionario = Convert.ToInt32(txtIdFuncionario.Text);
            funcionario.Borrado = true;
            return funcionario;
        }
        #endregion

        #region Crear entidad Funcionarios para Actualizar
        public EntidadFuncionarios GenerarEntidadFuncionarioActualizar()
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            funcionario.Id_funcionario = Convert.ToInt32(txtIdFuncionario.Text);
            funcionario.Nombre = txtNombre.Text;
            funcionario.Apellido1 = txtPrimerApellido.Text;
            funcionario.Apellido2 = txtSegundoApellido.Text;
            funcionario.Cedula = txtCedula.Text;
            funcionario.Telefono = txtTelefono.Text;
            funcionario.Puesto = txtPuesto.Text;
            funcionario.Borrado = false;
            return funcionario;
        }
        #endregion

        #region Evento para guardar el Funcionario en boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            BLFuncionario logica = new BLFuncionario(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) | string.IsNullOrEmpty(txtPrimerApellido.Text) |
                    string.IsNullOrEmpty(txtSegundoApellido.Text) | string.IsNullOrEmpty(txtCedula.Text) |
                    string.IsNullOrEmpty(txtTelefono.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    funcionario = GenerarEntidadFuncionario();
                    resultado = logica.Insertar(funcionario);
                    Limpiar();
                    CargarListaDataSet();
                    MessageBox.Show("Los datos fueron ingresados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Limpiar el formulario
        private void Limpiar()
        {
            txtIdFuncionario.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtPrimerApellido.Text = string.Empty;
            txtSegundoApellido.Text = string.Empty;
            txtPuesto.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtNombre.Focus();
        }
        #endregion

        #region Cargar Lista en DataSet
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

        #region Load de FrmFuncionarios para cargar el dataSet
        private void FrmFuncionarios_Load(object sender, EventArgs e)
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

        #region Cargar Funcionarios 
        public int CargarFuncionario(int id)
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            BLFuncionario traerFuncionario = new BLFuncionario(Configuracion.getConnectionString);
            try
            {
                funcionario = traerFuncionario.ObtenerFuncionario(id);
                if (funcionario != null)
                {
                    txtIdFuncionario.Text = funcionario.Id_funcionario.ToString();
                    txtNombre.Text = funcionario.Nombre;
                    txtPrimerApellido.Text = funcionario.Apellido1;
                    txtSegundoApellido.Text = funcionario.Apellido2;
                    txtCedula.Text = funcionario.Cedula;
                    txtPuesto.Text = funcionario.Puesto;
                    txtTelefono.Text = funcionario.Telefono;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
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

                    // Llamar al método CargarPaciente para obtener los datos del paciente
                    int id = CargarFuncionario(idFuncionario);

                    // Si el método CargarPaciente devuelve el ID del paciente cargado correctamente
                    // puedes realizar alguna acción adicional aquí si es necesario
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Verificar que el evento se haya disparado por hacer clic en una celda específica

        }
        #endregion

        #region Boton Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargarListaDataSet();
        }
        #endregion

        #region Boton Buscar
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

        #region Evento en boton Eliminar el Funcionario 
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            BLFuncionario logica = new BLFuncionario(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) | string.IsNullOrEmpty(txtPrimerApellido.Text) |
                    string.IsNullOrEmpty(txtSegundoApellido.Text) | string.IsNullOrEmpty(txtCedula.Text) |
                    string.IsNullOrEmpty(txtTelefono.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    funcionario = GenerarEntidadFuncionariosBorrado();
                    resultado = logica.EliminarFuncionario(funcionario);
                    Limpiar();
                    CargarListaDataSet();
                    MessageBox.Show("Los datos fueron borrados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Evento en el boton actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            BLFuncionario logica = new BLFuncionario(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) | string.IsNullOrEmpty(txtPrimerApellido.Text) |
                    string.IsNullOrEmpty(txtSegundoApellido.Text) | string.IsNullOrEmpty(txtCedula.Text) |
                    string.IsNullOrEmpty(txtTelefono.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    funcionario = GenerarEntidadFuncionarioActualizar();
                    resultado = logica.ActualizarFuncionario(funcionario);
                    Limpiar();
                    CargarListaDataSet();
                    MessageBox.Show("Los datos fueron Actualizados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

