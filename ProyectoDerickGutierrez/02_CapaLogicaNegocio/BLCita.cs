using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using _03_CapaAccesoDatos;
using CapaEntidades;

namespace _02_CapaLogicaNegocio
{
    public class BLCita
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;

        //propiedades
        public string Mensaje { get => _mensaje; }

        //constructor
        public BLCita(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Llamado de metodo insertar Cita
        public int InsertarCita(EntidadCitas cita)
        {
            int id_Cita = 0;
            DACita accesoDatos = new DACita(_cadenaConexion);
            try
            {
                id_Cita = accesoDatos.InsertarCita(cita);
            }
            catch (Exception)
            {
                throw;
            }
            return id_Cita;
        }
        #endregion

        #region Llamar ObtenerPaciente
        public EntidadPacientes ObtenerPaciente(int id)
        {
            EntidadPacientes paciente;
            DAPaciente accessoDatos = new DAPaciente(_cadenaConexion);
            try
            {
                paciente = accessoDatos.ObtenerPaciente(id);
            }
            catch (Exception)
            {
                throw;
            }
            return paciente;
        }
        #endregion

        #region Llamar a la lista de especialidades
        public List<NombreDTO> ListarEspecialidades()
        {
            List<NombreDTO> lista;
            DACita accesoDatos = new DACita(_cadenaConexion);

            try
            {
                lista = ConvertDataSetToListNameDTO(accesoDatos.ListarEspecialistas());
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }//fin de listar clientes
        #endregion

        #region Llamar a la lista de Doctores
        public List<NombreDTO> ListarDoctores(int idEspecialidad)
        {
            List<NombreDTO> lista;
            DACita accesoDatos = new DACita(_cadenaConexion);

            try
            {
                lista = ConvertDataSetToListNameDTO(accesoDatos.ListarDoctores(idEspecialidad));
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
        #endregion

        #region Llamar a la lista de funcionarios
        public DataSet ListarFuncionarios(string nombreEspecialidad)
        {
            DataSet DS;
            DACita accesoDatos = new DACita(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarFuncionarios(nombreEspecialidad);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }
        #endregion

        #region Llamar a la lista horarios
        public string[] listaHorarios(int idDoctor, string dia, DataSet DSCitas)
        {
            string[] DS;
            DACita accesoDatos = new DACita(_cadenaConexion);

            try
            {
                var horasRegistradas = ConvertDataSetToStringArray(DSCitas, 2);
                DS = CalcularHorasDisponibles(accesoDatos.ListarHorarios(dia, idDoctor),horasRegistradas);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//fin de listar clientes
        #endregion

        #region convertir data set a string[]
        public List<NombreDTO> ConvertDataSetToListNameDTO(DataSet dataSet)
        {
            // Objeto StringBuilder para construir el arreglo de cadenas
            List<NombreDTO> lista = new List<NombreDTO>();

            // Recorrer las tablas y filas del DataSet
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    lista.Add(new NombreDTO
                    {
                        Id = Convert.ToInt32(row[0]),
                        Name = row[1].ToString()
                    });
                }
            }
            return lista;
        }
        #endregion

        #region Calcular Horas disponibles
        public string[] CalcularHorasDisponibles(DataSet dataSet, string[] horasRegistradas)
        {
            // Creamos una lista para almacenar los intervalos de media hora
            StringBuilder intervalos = new StringBuilder();

            //var horasregistradas = ConvertDataSetToStringArray(new DataSet); //aqui debo llamar el metodo para poner los horarios disponibles o un clon de lista doctores pero se devuelve un dataset
            // Recorrer las tablas y filas del DataSet

            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    TimeSpan startTime = TimeSpan.Parse(row[0].ToString());
                    TimeSpan endTime = TimeSpan.Parse(row[1].ToString());

                    // Establecemos el intervalo de tiempo en 30 minutos
                    TimeSpan intervalo = TimeSpan.FromMinutes(30);
                    TimeSpan tiempoActual = startTime;
                    while (tiempoActual <= endTime)
                    {
                        if (!horasRegistradas.Contains(tiempoActual.ToString(@"hh\:mm")))
                        {
                        intervalos.Append(tiempoActual.ToString(@"hh\:mm"));
                        intervalos.Append(",");
                        }
                        tiempoActual = tiempoActual.Add(intervalo);
                    }
                }
            }
            string result = intervalos.ToString();
            string[] stringArray = result.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return stringArray;
        }
        #endregion

        #region Llamado de metodo insertar
        public int Insertar(EntidadCitas citas)
        {
            int id_cita = 0;
            DACita accesoDatos = new DACita(_cadenaConexion);
            try
            {
                id_cita = accesoDatos.Insertar(citas);
            }
            catch (Exception)
            {
                throw;
            }
            return id_cita;
        }
        #endregion

        #region Llamar a la lista de Citas Registradas
        public DataSet ListarHorariosRegistrados(DateTime dia, int doctor)
        {
            DataSet DS;
            DACita accesoDatos = new DACita(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarHorariosRegistrados(dia, doctor);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }
        #endregion

        #region Metodo string array
        public string[] ConvertDataSetToStringArray(DataSet dataSet, int columNumber)
        {
            // Creamos una lista para almacenar los intervalos de media hora
            StringBuilder columnas = new StringBuilder();

            //var horasregistradas = ConvertDataSetToStringArray(new DataSet); //aqui debo llamar el metodo para poner los horarios disponibles o un clon de lista doctores pero se devuelve un dataset
            // Recorrer las tablas y filas del DataSet

            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    columnas.Append(row[columNumber]);
                    columnas.Append(",");
                }
            }
            string result = columnas.ToString();
            string[] stringArray = result.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return stringArray;
        }
        #endregion

        #region Llamado a borrado Citas
        public int EliminarCitas(EntidadCitas cita)
        {
            int filasAfectadas = 0;
            DACita accesoDatos = new DACita(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.EliminarCitas(cita);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
        #endregion
    }
}
