using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace _03_CapaAccesoDatos
{
    public class DAEspecialidad
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;

        //propiedades
        public string Mensaje { get => _mensaje; }

        //constructor
        public DAEspecialidad(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Metodo Insertar
        public int Insertar(EntidadEspecialidades especialidad)
        {
            int id = 0;
            //establezer el objeto conexion
            SqlConnection cnx = new SqlConnection(_cadenaConexion);
            //Rstablecer los comandos Sql
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnx;
            string sentencia = "INSERT INTO ESPECIALIDADES(ID_ESPECIALIDAD,ID_FUNCIONARIO, NOMBRE, DESCRIPCION, BORRADO_ESPECIALIDAD)" +
                " VALUES(@ID_ESPECIALIDAD,@FUNCIONARIO, @NOMBRE, @DESCRIPCION,@BORRADO);SELECT CAST(scope_identity() AS int)";
            comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", especialidad.Id_Especialidad);
            comando.Parameters.AddWithValue("@FUNCIONARIO", especialidad.Id_Funcionario);
            comando.Parameters.AddWithValue("@NOMBRE", especialidad.Nombre);
            comando.Parameters.AddWithValue("@DESCRIPCION", especialidad.Descripcion);
            comando.Parameters.AddWithValue("@BORRADO", false);
            comando.CommandText = sentencia;
            try
            {
                cnx.Open();
                id = Convert.ToInt32(comando.ExecuteScalar());
                cnx.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnx.Dispose();
                comando.Dispose();
            }
            return id;
        }//fin del metodo insertar
        #endregion

        #region Acceder a lista de especialistas
        public DataSet ListarEspecialistas(string condicion = "", string orden = "")
        {
            DataSet Datos = new DataSet();
            SqlConnection conn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia;
            if (condicion != "")
            {
                sentencia = condicion;
            }
            else
            {
                sentencia = "SELECT ID_FUNCIONARIO, NOMBRE,DESCRIPCION, BORRADO_ESPECIALIDAD FROM ESPECIALIDADES WHERE BORRADO_ESPECIALIDAD = 0";

            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conn);
                adapter.Fill(Datos, "ESPECIALIDADES");
            }
            catch (Exception)
            {
                throw;
            }
            return Datos;
        }//fin listar clientes
        #endregion

        #region Obtener Funcionario
        public EntidadEspecialidades ObtenerEspecialidad(int id)
        {
            EntidadEspecialidades especialidad = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_FUNCIONARIO, NOMBRE,DESCRIPCION, BORRADO_ESPECIALIDAD FROM ESPECIALIDADES WHERE ID_FUNCIONARIO= {0}", id);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    especialidad = new EntidadEspecialidades();
                    dataReader.Read();
                    especialidad.Id_Funcionario = dataReader.GetInt32(0);
                    especialidad.Nombre = dataReader.GetString(1);
                    especialidad.Descripcion = dataReader.GetString(2);
                    especialidad.Borrado = dataReader.GetBoolean(3);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return especialidad;
        }
        #endregion

        #region Eliminar Especialidad (B/logico)
        public int EliminarEspecialidad(EntidadEspecialidades especialidad)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE ESPECIALIDADES SET BORRADO_ESPECIALIDAD =@BORRADO WHERE ID_FUNCIONARIO = @ID_FUNCIONARIO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_FUNCIONARIO", especialidad.Id_Funcionario);
            comando.Parameters.AddWithValue("@BORRADO", true);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return filasAfectadas;
        }
        #endregion

        #region Actualizar Especialidad
        public int ActualizarEspecialidad(EntidadEspecialidades especialidad)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE ESPECIALIDADES SET ID_FUNCIONARIO =@ID_FUNCIONARIO, NOMBRE =@NOMBRE, DESCRIPCION=@DESCRIPCION, BORRADO_ESPECIALIDAD=@BORRADO WHERE ID_Funcionario = @ID_FUNCIONARIO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_FUNCIONARIO", especialidad.Id_Funcionario);
            comando.Parameters.AddWithValue("@NOMBRE", especialidad.Nombre);
            comando.Parameters.AddWithValue("@DESCRIPCION", especialidad.Descripcion);
            comando.Parameters.AddWithValue("@BORRADO", especialidad.Borrado);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return filasAfectadas;
        }
        #endregion
    }
}
