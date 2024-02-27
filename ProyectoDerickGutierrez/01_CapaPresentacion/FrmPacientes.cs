using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _02_CapaLogicaNegocio;
using _03_CapaAccesoDatos;
using CapaEntidades;

namespace _01_CapaPresentacion
{
    public partial class FrmPacientes : Form
    {
        public FrmPacientes()
        {
            InitializeComponent();
        }
        #region Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Crear entidad pacientes
        public EntidadPacientes GenerarEntidadPacientes()
        {
            EntidadPacientes paciente = new EntidadPacientes();
            paciente.Nombre_P = txtNombre.Text;
            paciente.Apellido1_P = txtPrimerApellido.Text;
            paciente.Apellido2_P = txtSegundoApellido.Text;
            paciente.Cedula_P = txtCedula.Text;
            paciente.Fecha_Na = dtpFechaNa.Value;
            paciente.Telefono = txtTelefono.Text;
            paciente.Nacionalidad = cmBoxNacionalidad.Text;
            paciente.Borrado_P = false;
            return paciente;
        }
        #endregion

        #region Crear entidad pacientes
        public EntidadPacientes GenerarEntidadPacientesActualizar()
        {
            EntidadPacientes paciente = new EntidadPacientes();
            paciente.Id_Paciente = Convert.ToInt32(txtIdCliente.Text);
            paciente.Nombre_P = txtNombre.Text;
            paciente.Apellido1_P = txtPrimerApellido.Text;
            paciente.Apellido2_P = txtSegundoApellido.Text;
            paciente.Cedula_P = txtCedula.Text;
            paciente.Fecha_Na = dtpFechaNa.Value;
            paciente.Telefono = txtTelefono.Text;
            paciente.Nacionalidad = cmBoxNacionalidad.Text;
            paciente.Borrado_P = false;
            return paciente;
        }
        #endregion

        #region Crear entidad pacientes para borrar
        public EntidadPacientes GenerarEntidadPacientesBorrado()
        {
            EntidadPacientes paciente = new EntidadPacientes();
            paciente.Id_Paciente = Convert.ToInt32(txtIdCliente.Text);
            paciente.Borrado_P = true;
            return paciente;
        }
        #endregion
     
        #region Evento para guardar el paciente en boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadPacientes paciente = new EntidadPacientes();
            BLPaciente logica = new BLPaciente(Configuracion.getConnectionString);
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
                    paciente = GenerarEntidadPacientes();
                    resultado = logica.Insertar(paciente);
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
            txtIdCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtPrimerApellido.Text = string.Empty;
            txtSegundoApellido.Text = string.Empty;
            dtpFechaNa.Value = DateTime.Now;
            txtTelefono.Text = string.Empty;
            txtNombre.Focus();
        }
        #endregion

        #region Cargar Lista en DataSet
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            BLPaciente logica = new BLPaciente(Configuracion.getConnectionString);
            DataSet DSPaciente;

            try
            {
                DSPaciente = logica.ListarPacientes(condicion, orden);
                grdLista.DataSource = DSPaciente;
                grdLista.DataMember = DSPaciente.Tables["Pacientes"].TableName;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Load de FrmPacientes para cargar el dataSet
        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaDataSet();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cargar Paciente
        public int CargarPaciente(int id)
        {
            EntidadPacientes paciente = new EntidadPacientes();
            BLPaciente traerPaciente = new BLPaciente(Configuracion.getConnectionString);
            try
            {
                paciente = traerPaciente.ObtenerPaciente(id);
                if (paciente != null)
                {
                    txtIdCliente.Text = paciente.Id_Paciente.ToString();
                    txtNombre.Text = paciente.Nombre_P;
                    txtPrimerApellido.Text = paciente.Apellido1_P;
                    txtSegundoApellido.Text = paciente.Apellido2_P;
                    txtCedula.Text = paciente.Cedula_P;
                    cmBoxNacionalidad.Text = paciente.Nacionalidad;
                    dtpFechaNa.Value = paciente.Fecha_Na;
                    txtTelefono.Text = paciente.Telefono;
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
                    int idPaciente = Convert.ToInt32(grdLista.Rows[e.RowIndex].Cells["codigo"].Value);

                    // Llamar al método CargarPaciente para obtener los datos del paciente
                    int id = CargarPaciente(idPaciente);

                    // Si el método CargarPaciente devuelve el ID del paciente cargado correctamente
                    // puedes realizar alguna acción adicional aquí si es necesario
                }
            }
            catch(Exception ex)
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
                    condicion = string.Format("SELECT ID_PACIENTE, NOMBRE_P, APELLIDO1_P, APELLIDO2_P, CEDULA, NACIONALEXTRANJERO, FECHANACIMIENTO, TELEFONO, BORRADO_PACIENTE FROM PACIENTES WHERE Nombre_p like '%{0}%'", txtNombre.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Debe escribir parte del nombre a buscar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Focus();
                }
                CargarListaDataSet(condicion);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Evento en boton Eliminar el paciente 
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            EntidadPacientes paciente = new EntidadPacientes();
            BLPaciente logica = new BLPaciente(Configuracion.getConnectionString);
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
                    paciente = GenerarEntidadPacientesBorrado();
                    resultado = logica.EliminarPaciente(paciente);
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
            EntidadPacientes paciente = new EntidadPacientes();
            BLPaciente logica = new BLPaciente(Configuracion.getConnectionString);
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
                    paciente = GenerarEntidadPacientesActualizar();
                    resultado = logica.ActualizarPaciente(paciente);
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
