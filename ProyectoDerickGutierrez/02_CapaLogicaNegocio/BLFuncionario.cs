using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using _03_CapaAccesoDatos;
using CapaEntidades;

namespace _02_CapaLogicaNegocio
{
    public class BLFuncionario
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;

        //propiedades
        public string Mensaje { get => _mensaje; }

        //constructor
        public BLFuncionario(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Llamado de metodo insertar
        public int Insertar(EntidadFuncionarios funcionario)
        {
            int id_funcionario = 0;
            DAFuncionario accesoDatos = new DAFuncionario(_cadenaConexion);
            try
            {
                id_funcionario = accesoDatos.Insertar(funcionario);
            }
            catch (Exception)
            {
                throw;
            }
            return id_funcionario;
        }
        #endregion

        #region Llamar a la lista de funcionarios
        public DataSet ListarFuncionarios(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAFuncionario accesoDatos = new DAFuncionario(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarFuncionarios(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//fin de listar clientes
        #endregion

        #region Llamar Obtener Funcionario
        public EntidadFuncionarios ObtenerFuncionario(int id)
        {
            EntidadFuncionarios funcionario;
            DAFuncionario accessoDatos = new DAFuncionario(_cadenaConexion);
            try
            {
                funcionario = accessoDatos.ObtenerFuncionario(id);
            }
            catch (Exception)
            {
                throw;
            }
            return funcionario;
        }
        #endregion

        #region Llamado a borrado funcionarios
        public int EliminarFuncionario(EntidadFuncionarios funcionario)
        {
            int filasAfectadas = 0;
            DAFuncionario accesoDatos = new DAFuncionario(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.EliminarFuncionario(funcionario);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
        #endregion

        #region Llamado a Actualizar Funcionarios
        public int ActualizarFuncionario(EntidadFuncionarios funcionario)
        {
            int filasAfectadas = 0;
            DAFuncionario accesoDatos = new DAFuncionario(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.ActualizarFuncionario(funcionario);
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
