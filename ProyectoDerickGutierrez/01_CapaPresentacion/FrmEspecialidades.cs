using _02_CapaLogicaNegocio;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _01_CapaPresentacion
{
    public partial class FrmEspecialidades : Form
    {
        FrmBuscarFuncionario formularioBuscar;
        public FrmEspecialidades()
        {
            InitializeComponent();
        }

        #region Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Crear entidad especialidades
        public EntidadEspecialidades GenerarEntidadEspecialidades()
        {
            EntidadEspecialidades especialidad = new EntidadEspecialidades();
            NombreDTO nombre= cmbEspecialidad.SelectedItem as NombreDTO;
            especialidad.Id_Especialidad = nombre.Id;
            especialidad.Id_Funcionario = Convert.ToInt32(txtFuncionario.Text);
            especialidad.Nombre = cmbEspecialidad.Text;
            especialidad.Descripcion = txtDescripcion.Text;
            especialidad.Borrado = false;
            return especialidad;
        }
        #endregion

        #region Crear entidad especialidad para borrar
        public EntidadEspecialidades GenerarEntidadEspecialidadesBorrado()
        {
            EntidadEspecialidades especialidad = new EntidadEspecialidades();
            especialidad.Id_Funcionario = Convert.ToInt32(txtFuncionario.Text);
            especialidad.Borrado = true;
            return especialidad;
        }
        #endregion

        #region Crear entidad Funcionarios para especialidades
        public EntidadEspecialidades GenerarEntidadEspecialidadesActualizar()
        {
            EntidadEspecialidades especialidad = new EntidadEspecialidades();
            especialidad.Id_Funcionario = Convert.ToInt32(txtFuncionario.Text);
            especialidad.Nombre = cmbEspecialidad.Text;
            especialidad.Descripcion = txtFuncionario.Text;
            especialidad.Borrado = false;
            return especialidad;
        }
        #endregion

        #region Evento para guardar el Especialista en boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadEspecialidades especialidad = new EntidadEspecialidades();
            BLEspecialidad logica = new BLEspecialidad(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(cmbEspecialidad.Text) |
                    string.IsNullOrEmpty(txtFuncionario.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    especialidad = GenerarEntidadEspecialidades();
                    resultado = logica.Insertar(especialidad);
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
            txtFuncionario.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cmbEspecialidad.Text = string.Empty;
            cmbEspecialidad.Focus();
        }
        #endregion

        #region Cargar Lista en DataSet
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            BLEspecialidad logica = new BLEspecialidad(Configuracion.getConnectionString);
            DataSet DSEspecialidad;

            try
            {
                DSEspecialidad = logica.ListarEspecialidades(condicion, orden);
                grdLista.DataSource = DSEspecialidad;
                grdLista.DataMember = DSEspecialidad.Tables["ESPECIALIDADES"].TableName;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Load de FrmFuncionarios para cargar el dataSet
        private void FrmEspecialidades_Load(object sender, EventArgs e)
        {
            try
            {
                BLEspecialidad logica = new BLEspecialidad(Configuracion.getConnectionString);
                cmbEspecialidad.DisplayMember = nameof(NombreDTO.Name);
                cmbEspecialidad.DataSource = logica.ListarEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cargar Especialidades 
        public int CargarEspecialidades(int id)
        {
            EntidadEspecialidades especialidad = new EntidadEspecialidades();
            BLEspecialidad traerEspecialidad = new BLEspecialidad(Configuracion.getConnectionString);
            try
            {
                especialidad = traerEspecialidad.ObtenerEspecialidad(id);
                if (especialidad != null)
                {
                    cmbEspecialidad.Text = especialidad.Nombre.ToString();
                    txtFuncionario.Text = especialidad.Id_Funcionario.ToString();
                    txtDescripcion.Text = especialidad.Descripcion;
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
                    int id = CargarEspecialidades(idFuncionario);

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
            formularioBuscar = new FrmBuscarFuncionario();
            formularioBuscar.Aceptar += new EventHandler(Aceptar);
            formularioBuscar.ShowDialog();
        }
        #endregion

        #region Cargar el codigo
        public void CargarCodigo(int id)
        {
            EntidadFuncionarios funcionario = new EntidadFuncionarios();
            BLFuncionario logica = new BLFuncionario(Configuracion.getConnectionString);
            try
            {
                funcionario = logica.ObtenerFuncionario(id);
                if (funcionario != null)
                {
                    txtFuncionario.Text = funcionario.Id_funcionario.ToString();
                }
                else
                {
                    MessageBox.Show("El Funcionario no se encuentra en la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region eventHandler
        public void Aceptar(object id, EventArgs e)
        {
            try
            {
                int idFuncionario = (int)id;
                if(idFuncionario != -1)
                {
                    CargarCodigo(idFuncionario);
                }
                else
                {
                    Limpiar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Evento en el boton actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            EntidadEspecialidades especialidad = new EntidadEspecialidades();
            BLEspecialidad logica = new BLEspecialidad(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(cmbEspecialidad.Text) |
                    string.IsNullOrEmpty(txtFuncionario.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    especialidad = GenerarEntidadEspecialidadesActualizar();
                    resultado = logica.ActualizarEspecialidad(especialidad);
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

        #region btnBuscar
        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            formularioBuscar = new FrmBuscarFuncionario();
            formularioBuscar.Aceptar += new EventHandler(Aceptar);
            formularioBuscar.ShowDialog();
        }
        #endregion

        #region Evento en boton Eliminar el Especialidad 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadEspecialidades especialidad = new EntidadEspecialidades();
            BLEspecialidad logica = new BLEspecialidad(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(cmbEspecialidad.Text) |
                    string.IsNullOrEmpty(txtFuncionario.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    especialidad = GenerarEntidadEspecialidadesBorrado();
                    resultado = logica.EliminarEspecialidad(especialidad);
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
    }
}
