using _03_CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace _02_CapaLogicaNegocio
{
    public class BLHorario
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;

        //propiedades
        public string Mensaje { get => _mensaje; }

        //constructor
        public BLHorario(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Llamado de metodo insertar
        public int Insertar(EntidadHorarios horario)
        {
            int id_horario = 0;
            DAHorario accesoDatos = new DAHorario(_cadenaConexion);
            try
            {
                id_horario = accesoDatos.Insertar(horario);
            }
            catch (Exception)
            {
                throw;
            }
            return id_horario;
        }
        #endregion

        #region Llamar a la lista de Horarios
        public DataSet ListarHorarios(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAHorario accesoDatos = new DAHorario(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarHoarios(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//fin de listar clientes
        #endregion

        #region Llamar Obtener Horarios
        public EntidadHorarios ObtenerHorario(int id)
        {
            EntidadHorarios horario;
            DAHorario accessoDatos = new DAHorario(_cadenaConexion);
            try
            {
                horario = accessoDatos.ObtenerHorario(id);
            }
            catch (Exception)
            {
                throw;
            }
            return horario;
        }
        #endregion

        #region Llamado a borrado Horarios
        public int EliminarHorario(EntidadHorarios horario)
        {
            int filasAfectadas = 0;
            DAHorario accesoDatos = new DAHorario(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.EliminarHorario(horario);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
        #endregion

        #region Llamado a Actualizar Horarios
        public int ActualizarHorario(EntidadHorarios horario)
        {
            int filasAfectadas = 0;
            DAHorario accesoDatos = new DAHorario(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.ActualizarHorario(horario);
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
