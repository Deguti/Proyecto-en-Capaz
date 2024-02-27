using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades;

namespace _03_CapaAccesoDatos
{
    public class DAFuncionario
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;

        //propiedades
        public string Mensaje { get => _mensaje; }

        //constructor
        public DAFuncionario(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Metodo Insertar
        public int Insertar(EntidadFuncionarios funcionario)
        {
            int id = 0;
            //establezer el objeto conexion
            SqlConnection cnx = new SqlConnection(_cadenaConexion);
            //Rstablecer los comandos Sql
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnx;
            string sentencia = "INSERT INTO FUNCIONARIOS(NOMBRE, APELLIDO1, APELLIDO2,CEDULA, PUESTO_TRABAJO, TELEFONO,BORRADO_FUNCIONARIO)" +
                " VALUES(@NOMBRE, @APELLIDO1, @APELLIDO2, @CEDULA,@PUESTO,@TELEFONO,@BORRADO) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@NOMBRE", funcionario.Nombre);
            comando.Parameters.AddWithValue("@APELLIDO1", funcionario.Apellido1);
            comando.Parameters.AddWithValue("@APELLIDO2", funcionario.Apellido2);
            comando.Parameters.AddWithValue("@CEDULA", funcionario.Cedula);
            comando.Parameters.AddWithValue("@PUESTO", funcionario.Puesto);
            comando.Parameters.AddWithValue("@TELEFONO", funcionario.Telefono);
            comando.Parameters.AddWithValue("@BORRADO", false);
            comando.CommandText = sentencia;
            try
            {
                cnx.Open();
                id = Convert.ToInt32(comando.ExecuteScalar());
                cnx.Close();
            }
            catch (Exception)
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

        #region Acceder a lista de Funcionarios
        public DataSet ListarFuncionarios(string condicion = "", string orden = "")
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
                sentencia = "SELECT ID_FUNCIONARIO, NOMBRE,APELLIDO1, APELLIDO2,CEDULA, PUESTO_TRABAJO, TELEFONO, BORRADO_FUNCIONARIO FROM FUNCIONARIOS WHERE BORRADO_FUNCIONARIO = 0";

            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conn);
                adapter.Fill(Datos, "Funcionarios");
            }
            catch (Exception)
            {
                throw;
            }
            return Datos;
        }//fin listar clientes
        #endregion

        #region Obtener Funcionario
        public EntidadFuncionarios ObtenerFuncionario(int id)
        {
            EntidadFuncionarios funcionario = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_FUNCIONARIO, NOMBRE, APELLIDO1, APELLIDO2, CEDULA, PUESTO_TRABAJO, TELEFONO, BORRADO_FUNCIONARIO FROM FUNCIONARIOS WHERE ID_FUNCIONARIO = {0}", id);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    funcionario = new EntidadFuncionarios();
                    dataReader.Read();
                    funcionario.Id_funcionario = dataReader.GetInt32(0);
                    funcionario.Nombre = dataReader.GetString(1);
                    funcionario.Apellido1 = dataReader.GetString(2);
                    funcionario.Apellido2 = dataReader.GetString(3);
                    funcionario.Cedula = dataReader.GetString(4);
                    funcionario.Puesto = dataReader.GetString(5);
                    funcionario.Telefono = dataReader.GetString(6);
                    funcionario.Borrado = dataReader.GetBoolean(7);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return funcionario;
        }
        #endregion

        #region Eliminar Funcionario (B/logico)
        public int EliminarFuncionario(EntidadFuncionarios funcionario)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE FUNCIONARIOS SET BORRADO_FUNCIONARIO =@BORRADO WHERE ID_FUNCIONARIO = @ID_FUNCIONARIO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_FUNCIONARIO", funcionario.Id_funcionario);
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

        #region Actualizar Funcionario
        public int ActualizarFuncionario(EntidadFuncionarios funcionario)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE FUNCIONARIOS SET NOMBRE =@NOMBRE, APELLIDO1 =@APELLIDO1, APELLIDO2=@APELLIDO2, CEDULA=@CEDULA, PUESTO_TRABAJO=@PUESTO, TELEFONO=@TELEFONO, BORRADO_FUNCIONARIO=@BORRADO WHERE ID_FUNCIONARIO = @ID_FUNCIONARIO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_FUNCIONARIO", funcionario.Id_funcionario);
            comando.Parameters.AddWithValue("@NOMBRE", funcionario.Nombre);
            comando.Parameters.AddWithValue("@APELLIDO1", funcionario.Apellido1);
            comando.Parameters.AddWithValue("@APELLIDO2", funcionario.Apellido2);
            comando.Parameters.AddWithValue("@CEDULA", funcionario.Cedula);
            comando.Parameters.AddWithValue("@PUESTO", funcionario.Puesto);
            comando.Parameters.AddWithValue("@TELEFONO", funcionario.Telefono);
            comando.Parameters.AddWithValue("@BORRADO", funcionario.Borrado);
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
