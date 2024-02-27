using _02_CapaLogicaNegocio;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace _01_CapaPresentacion
{
    public partial class FrmCitas : Form
    {
        private readonly BLCita logica;
        public FrmCitas()
        {
            InitializeComponent();
            logica = new BLCita(Configuracion.getConnectionString);
        }

        #region btn Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
     
        #region CargarPaciente
        public int CargarPaciente(int id)
        {
            EntidadPacientes paciente = new EntidadPacientes();
            BLPaciente traerPaciente = new BLPaciente(Configuracion.getConnectionString);
            try
            {
                paciente = traerPaciente.ObtenerPaciente(id);
                if (paciente != null)
                {
                    txtId_Cliente.Text = paciente.Id_Paciente.ToString();
                    txtNombre.Text = paciente.Nombre_P;
                    txtApellido.Text = paciente.Apellido1_P;
                    txtCedula.Text = paciente.Cedula_P;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
        }
        #endregion

        #region boton buscar paciente
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId_Cliente.Text))
            {
                int id = Convert.ToInt32(txtId_Cliente.Text);
                CargarPaciente(id);
            }
            else
            {
                MessageBox.Show("Faltan datos. Favor ingrese el Id", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        #endregion

        #region Load Listar especialidades
        private void FrmCitas_Load(object sender, EventArgs e)
        {
            BLCita logica = new BLCita(Configuracion.getConnectionString);
            cmbEspecialidades.DisplayMember = nameof(NombreDTO.Name);
            cmbEspecialidades.DataSource= logica.ListarEspecialidades();
        }
        #endregion

        #region Crear entidad Horarios
        public EntidadCitas GenerarEntidadCitas()
        {
            EntidadCitas cita = new EntidadCitas();
            NombreDTO doctor = cmbDoctor.SelectedItem as NombreDTO;
            cita.Id_Paciente = Convert.ToInt32(txtId_Cliente.Text);
            cita.Id_Funcionario = doctor.Id;
            cita.Fecha = dtpFCita.Value;
            cita.Duracion = cmbhoras.SelectedItem.ToString();
;           cita.Borrado = false;
            return cita;
        }
        #endregion

        #region Evento para guardar el paciente en boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadCitas citas = new EntidadCitas();
            BLCita logica = new BLCita(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(txtId_Cliente.Text) | string.IsNullOrEmpty(txtNombre.Text) |
                    string.IsNullOrEmpty(txtApellido.Text) | string.IsNullOrEmpty(txtCedula.Text) |
                    string.IsNullOrEmpty(cmbEspecialidades.Text) | string.IsNullOrEmpty(cmbDoctor.Text) |
                    string.IsNullOrEmpty(cmbhoras.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    citas = GenerarEntidadCitas();
                    resultado = logica.Insertar(citas);
                    MessageBox.Show("Los datos fueron ingresados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ValueChanged en cmbEspecialidades
        private void cmbEspecialidades_SelectedValueChanged(object sender, EventArgs e)
        {
            NombreDTO especialidad = cmbEspecialidades.SelectedItem as NombreDTO;
            cmbDoctor.DataSource = logica.ListarDoctores(especialidad.Id);
            cmbDoctor.DisplayMember= nameof(NombreDTO.Name);
        }
        #endregion

        #region valueChanged en dtpFcita
        private void dtpFCita_ValueChanged(object sender, EventArgs e)
        {
            string nombreDia = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtpFCita.Value.ToString("dddd"));
            NombreDTO doctor  = cmbDoctor.SelectedItem as NombreDTO;
            var dsCitas = CargarListaDataSet(dtpFCita.Value, doctor.Id);
            cmbhoras.Items.Clear();
            cmbhoras.Items.AddRange(logica.listaHorarios(doctor.Id, nombreDia, dsCitas));
        }
        #endregion

        #region Cargar Lista en DataSet
        private DataSet CargarListaDataSet(DateTime dia, int doctor)
        {
            BLCita logica = new BLCita(Configuracion.getConnectionString);
            DataSet DSCitas = new DataSet();

            try
            {
                DSCitas = logica.ListarHorariosRegistrados(dia, doctor);
                grdLista.DataSource = DSCitas;
                grdLista.DataMember = DSCitas.Tables["Horarios"].TableName;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return DSCitas;
        }
        #endregion

        #region Crear entidad Citas para borrar
        public EntidadCitas GenerarEntidadCitasBorrado()
        {
            EntidadCitas cita = new EntidadCitas();
            cita.Id_Paciente = Convert.ToInt32(txtId_Cliente.Text);
            cita.Borrado = true;
            return cita;
        }
        #endregion

        #region Evento en boton Eliminar el paciente 
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            EntidadCitas cita = new EntidadCitas();
            BLCita logica = new BLCita(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(txtId_Cliente.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cita = GenerarEntidadCitasBorrado();
                    resultado = logica.EliminarCitas(cita);
                    MessageBox.Show("Los datos fueron borrados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
