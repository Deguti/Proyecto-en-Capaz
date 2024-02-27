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
    public partial class FrmHorarios : Form
    {
        FrmBuscarFuncionario formularioBuscar;
        public FrmHorarios()
        {
            InitializeComponent();
        }

        #region Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Crear entidad Horarios
        public EntidadHorarios GenerarEntidadHorarios()
        {
            EntidadHorarios horario = new EntidadHorarios();
            
            horario.Id_Funcionario = Convert.ToInt32(txtcodFuncionario.Text);
            horario.Dia_Inicio = Convert.ToString(cmbDia.Text);
            horario.Hora_Inicio = TimeSpan.Parse(dtpHoraInicio.Text);
            horario.Hora_Final = TimeSpan.Parse(dtpHoraFin.Text);
            horario.Borrado = false;
            return horario;
        }
        #endregion

        #region Crear entidad Horarios para borrar
        public EntidadHorarios GenerarEntidadHorariosBorrado()
        {
            EntidadHorarios horarios = new EntidadHorarios();
            horarios.Id_Horario = Convert.ToInt32(txtcodHorario.Text);
            horarios.Borrado = true;
            return horarios;
        }
        #endregion

        #region Crear entidad Horarios para Actualizar
        public EntidadHorarios GenerarEntidadHorariosActualizar()
        {
            EntidadHorarios horario = new EntidadHorarios();
            horario.Id_Horario = Convert.ToInt32(txtcodHorario.Text);
            horario.Id_Funcionario = Convert.ToInt32(txtcodFuncionario.Text);   
            horario.Dia_Inicio =Convert.ToString(cmbDia.Text);
            horario.Hora_Inicio = TimeSpan.Parse(dtpHoraInicio.Text);
            horario.Hora_Final = TimeSpan.Parse(dtpHoraFin.Text);
            horario.Borrado = false;
            return horario;
        }
        #endregion

        #region Evento para guardar el Horario en boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadHorarios horario = new EntidadHorarios();
            BLHorario logica = new BLHorario(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(txtcodFuncionario.Text) | string.IsNullOrEmpty(cmbDia.Text) |
                    string.IsNullOrEmpty(dtpHoraInicio.Text) | 
                    string.IsNullOrEmpty(dtpHoraFin.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    horario = GenerarEntidadHorarios();
                    resultado = logica.Insertar(horario);
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
            txtcodHorario.Text = string.Empty;
            txtcodFuncionario.Text = string.Empty;
            cmbDia.Text =string.Empty;
            dtpHoraInicio.Text = DateTime.Now.ToString();
            dtpHoraFin.Text = DateTime.Now.ToString();
        }
        #endregion

        #region Cargar Lista en DataSet
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            BLHorario logica = new BLHorario(Configuracion.getConnectionString);
            DataSet DSHorario;

            try
            {
                DSHorario = logica.ListarHorarios(condicion, orden);
                grdLista.DataSource = DSHorario;
                grdLista.DataMember = DSHorario.Tables["Horarios"].TableName;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Load de FrmHorarios para cargar el dataSet
        private void FrmHorarios_Load(object sender, EventArgs e)
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

        #region Cargar Horarios 
        public int CargarHorario(int id)
        {
            EntidadHorarios horario = new EntidadHorarios();
            BLHorario traerhorario = new BLHorario(Configuracion.getConnectionString);
            try
            {
                horario = traerhorario.ObtenerHorario(id);
                if (horario != null)
                {
                    txtcodHorario.Text = horario.Id_Horario.ToString();
                    txtcodFuncionario.Text = horario.Id_Funcionario.ToString();
                    cmbDia.Text = horario.Dia_Inicio.ToString();
                    dtpHoraInicio.Text = horario.Hora_Inicio.ToString();
                    dtpHoraFin.Text= horario.Hora_Final.ToString();
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
                    int horario  = Convert.ToInt32(grdLista.Rows[e.RowIndex].Cells["codigo"].Value);

                    // Llamar al método CargarPaciente para obtener los datos del paciente
                    int id = CargarHorario(horario);

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
                if (!string.IsNullOrEmpty(txtcodFuncionario.Text))
                {
                    condicion = string.Format("SELECT ID_HORARIO,ID_FUNCIONARIO, DIA_INICIO, HORA_INICIO, HORA_FIN, BORRADO_HORARIO FROM HORARIOS WHERE ID_FUNCIONARIO LIKE '%{0}%'", txtcodFuncionario.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Debe escribir parte del nombre a buscar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtcodFuncionario.Focus();
                }
                CargarListaDataSet(condicion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Evento en boton Eliminar elHorario 
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            EntidadHorarios horarios = new EntidadHorarios();
            BLHorario logica = new BLHorario(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(txtcodFuncionario.Text) //|
                   // string.IsNullOrEmpty(txtDiaFinal.Text)
                   )
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    horarios = GenerarEntidadHorariosBorrado();
                    resultado = logica.EliminarHorario(horarios);
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
            EntidadHorarios horarios = new EntidadHorarios();
            BLHorario logica = new BLHorario(Configuracion.getConnectionString);
            int resultado;
            try
            {
                if (string.IsNullOrEmpty(txtcodFuncionario.Text))
                {
                    MessageBox.Show("Faltan datos. Favor completar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    horarios = GenerarEntidadHorariosActualizar();
                    resultado = logica.ActualizarHorario(horarios);
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
                    txtcodFuncionario.Text = funcionario.Id_funcionario.ToString();
                }
                else
                {
                    MessageBox.Show("El Funcionario no se encuentra en la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
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
                if (idFuncionario != -1)
                {
                    CargarCodigo(idFuncionario);
                }
                else
                {
                    Limpiar();
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
