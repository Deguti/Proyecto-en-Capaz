using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades;

namespace _03_CapaAccesoDatos
{
    public class DAHorario
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;

        //propiedades
        public string Mensaje { get => _mensaje; }

        //constructor
        public DAHorario(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Metodo Insertar
        public int Insertar(EntidadHorarios horario)
        {
            int id = 0;
            SqlConnection cnx = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnx;
            string sentencia = "INSERT INTO HORARIOS(ID_FUNCIONARIO, DIA_INICIO, HORA_INICIO, HORA_FIN ,BORRADO_HORARIO)" +
                " VALUES(@ID_FUNCIONARIO, @DIA_INICIO, @HORA_INICIO,@HORA_FIN,@BORRADO) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@ID_FUNCIONARIO", horario.Id_Funcionario);
            comando.Parameters.AddWithValue("@DIA_INICIO", horario.Dia_Inicio);
            comando.Parameters.AddWithValue("@HORA_INICIO", horario.Hora_Inicio);
            comando.Parameters.AddWithValue("@HORA_FIN", horario.Hora_Final);
            comando.Parameters.AddWithValue("@BORRADO", horario.Borrado);
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

        #region Acceder a lista de Horarios
        public DataSet ListarHoarios(string condicion = "", string orden = "")
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
                sentencia = "SELECT ID_FUNCIONARIO, ID_HORARIO, DIA_INICIO, HORA_INICIO,HORA_FIN FROM HORARIOS WHERE BORRADO_HORARIO = 0";
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conn);
                adapter.Fill(Datos, "Horarios");
            }
            catch (Exception)
            {
                throw;
            }
            return Datos;
        }//fin listar clientes
        #endregion

        #region Obtener Horario
        public EntidadHorarios ObtenerHorario(int id)
        {
            EntidadHorarios horario = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_FUNCIONARIO, ID_HORARIO, DIA_INICIO, HORA_INICIO,HORA_FIN FROM HORARIOS WHERE ID_HORARIO = {0}", id);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    horario = new EntidadHorarios();
                    dataReader.Read();
                    horario.Id_Funcionario = dataReader.GetInt32(0);
                    horario.Id_Horario = dataReader.GetInt32(1);
                    horario.Dia_Inicio = dataReader.GetString(2);
                    horario.Hora_Inicio = dataReader.GetTimeSpan(3);
                    horario.Hora_Final = dataReader.GetTimeSpan(4);
                   
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return horario;
        }
        #endregion

        #region Eliminar Horario (B/logico)
        public int EliminarHorario(EntidadHorarios horario)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE HORARIOS SET BORRADO_HORARIO =@BORRADO WHERE ID_HORARIO = @ID_HORARIO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_HORARIO", horario.Id_Horario);
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

        #region Actualizar Horario
        public int ActualizarHorario(EntidadHorarios horario)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE HORARIOS SET DIA_INICIO=@DIA_INICIO, HORA_INICIO=@HORA_INICIO, HORA_FIN=@HORA_FIN, BORRADO_HORARIO=@BORRADO WHERE ID_HORARIO = @ID_HORARIO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_HORARIO",horario.Id_Horario);
            comando.Parameters.AddWithValue("@DIA_INICIO", horario.Dia_Inicio);
            comando.Parameters.AddWithValue("@HORA_INICIO", horario.Hora_Inicio);
            comando.Parameters.AddWithValue("@HORA_FIN", horario.Hora_Final);
            comando.Parameters.AddWithValue("@BORRADO", horario.Borrado);
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
