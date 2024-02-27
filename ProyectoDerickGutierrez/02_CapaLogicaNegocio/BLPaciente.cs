using System;
using System.Data;
using _03_CapaAccesoDatos;
using CapaEntidades;

namespace _02_CapaLogicaNegocio
{
    public class BLPaciente
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;
        //propiedades
        public string Mensaje { get => _mensaje; }
        //constructor
        public BLPaciente(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Llamado de metodo insertar
        public int Insertar(EntidadPacientes paciente)
        {
            int id_paciente = 0;
            DAPaciente accesoDatos = new DAPaciente(_cadenaConexion);
            try
            {
                id_paciente = accesoDatos.Insertar(paciente);
            }
            catch (Exception)
            {
                throw;
            }
            return id_paciente;
        }
        #endregion

        #region Llamar a la lista de clientes
        public DataSet ListarPacientes(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAPaciente accesoDatos = new DAPaciente(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarPacientes(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//fin de listar clientes
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

        #region Llamado a borrado pacientes
        public int EliminarPaciente(EntidadPacientes paciente)
        {
            int filasAfectadas = 0;
            DAPaciente accesoDatos = new DAPaciente(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.EliminarPaciente(paciente);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
        #endregion

        #region Llamado a Actualizar pacientes
        public int ActualizarPaciente(EntidadPacientes paciente)
        {
            int filasAfectadas = 0;
            DAPaciente accesoDatos = new DAPaciente(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.ActualizarPaciente(paciente);
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
