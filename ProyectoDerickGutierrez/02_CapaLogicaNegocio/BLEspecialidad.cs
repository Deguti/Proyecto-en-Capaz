using _03_CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace _02_CapaLogicaNegocio
{
    public class BLEspecialidad
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;

        //propiedades
        public string Mensaje { get => _mensaje; }

        //constructor
        public BLEspecialidad(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Llamado de metodo insertar
        public int Insertar(EntidadEspecialidades especialidad)
        {
            int id_especialidad = 0;
            DAEspecialidad accesoDatos = new DAEspecialidad(_cadenaConexion);
            try
            {
                id_especialidad = accesoDatos.Insertar(especialidad);
            }
            catch (Exception)
            {
                throw;
            }
            return id_especialidad;
        }
        #endregion

        #region Llamar a la lista de especialidades
        public DataSet ListarEspecialidades(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAEspecialidad accesoDatos = new DAEspecialidad(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarEspecialistas(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//fin de listar clientes
        #endregion

        #region Llamar Obtener Funcionario
        public EntidadEspecialidades ObtenerEspecialidad(int id)
        {
            EntidadEspecialidades especialidad;
            DAEspecialidad accessoDatos = new DAEspecialidad(_cadenaConexion);
            try
            {
                especialidad = accessoDatos.ObtenerEspecialidad(id);
            }
            catch (Exception)
            {
                throw;
            }
            return especialidad;
        }
        #endregion

        #region Llamado a borrado especialidades
        public int EliminarEspecialidad(EntidadEspecialidades especialidad)
        {
            int filasAfectadas = 0;
            DAEspecialidad accesoDatos = new DAEspecialidad(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.EliminarEspecialidad(especialidad);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
        #endregion

        #region Llamado a Actualizar Funcionarios
        public int ActualizarEspecialidad(EntidadEspecialidades especialidad)
        {
            int filasAfectadas = 0;
            DAEspecialidad accesoDatos = new DAEspecialidad(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.ActualizarEspecialidad(especialidad);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
        #endregion

        #region Alistar Especialidades
        public List<NombreDTO> ListarEspecialidades()
        {
            return new List<NombreDTO> 
            {
                new NombreDTO
                {
                    Id= 0,
                    Name = "Psicologo"
                },
                new NombreDTO
                {
                    Id= 1,
                    Name ="Psiquiatra"
                },
                new NombreDTO
                {
                    Id= 2,
                    Name= "Odontologo"
                },
                new NombreDTO
                {
                    Id= 3,
                    Name = "Neurologo"
                },
                new NombreDTO
                {
                    Id = 4,
                    Name = "Cardiologo"
                },
                new NombreDTO
                {
                    Id = 5,
                    Name = "Secretario"
                }
            };
        }
        #endregion
    }
}
