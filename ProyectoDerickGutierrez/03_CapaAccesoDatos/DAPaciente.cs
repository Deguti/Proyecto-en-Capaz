using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;


namespace _03_CapaAccesoDatos
{
    public class DAPaciente
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;

        //propiedades
        public string Mensaje { get => _mensaje; }

        //constructor
        public DAPaciente(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Metodo Insertar
        public int Insertar(EntidadPacientes paciente)
        {
            int id = 0;
            //establezer el objeto conexion
            SqlConnection cnx = new SqlConnection(_cadenaConexion);
            //Rstablecer los comandos Sql
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnx;
            string sentencia = "INSERT INTO PACIENTES (NOMBRE_P, APELLIDO1_P, APELLIDO2_P,CEDULA, NACIONALEXTRANJERO,FECHANACIMIENTO,TELEFONO,BORRADO_PACIENTE)" +
                " VALUES(@NOMBRE, @APELLIDO1_P, @APELLIDO2_P, @CEDULA, @NACIONALEXTRANJERO, @FECHANACIMIENTO,@TELEFONO,@BORRADO_P) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@NOMBRE", paciente.Nombre_P);
            comando.Parameters.AddWithValue("@APELLIDO1_P", paciente.Apellido1_P);
            comando.Parameters.AddWithValue("@APELLIDO2_P", paciente.Apellido2_P);
            comando.Parameters.AddWithValue("@CEDULA", paciente.Cedula_P);
            comando.Parameters.AddWithValue("@NACIONALEXTRANJERO", paciente.Nacionalidad);
            comando.Parameters.AddWithValue("@FECHANACIMIENTO", paciente.Fecha_Na);
            comando.Parameters.AddWithValue("@TELEFONO", paciente.Telefono);
            comando.Parameters.AddWithValue("@BORRADO_P", paciente.Borrado_P);
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

        #region Acceder a lista de Pacientes
        public DataSet ListarPacientes(string condicion = "", string orden = "")
        {
            DataSet Datos = new DataSet(); // En datos se guardan los resultados del select
            SqlConnection conn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia;
            if(condicion != "")
            {
                sentencia = condicion;
            }
            else
            {
                sentencia = "SELECT ID_PACIENTE, NOMBRE_P,APELLIDO1_P, APELLIDO2_P,CEDULA, NACIONALEXTRANJERO, FECHANACIMIENTO, TELEFONO, BORRADO_PACIENTE FROM PACIENTES WHERE BORRADO_PACIENTE = 0";

            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conn);
                adapter.Fill(Datos, "Pacientes");
            }
            catch (Exception)
            {
                throw;
            }
            return Datos;
        }//fin listar clientes
        #endregion

        #region Obtener Paciente
        public EntidadPacientes ObtenerPaciente(int id)  
        {
            EntidadPacientes paciente = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_PACIENTE, NOMBRE_P, APELLIDO1_P, APELLIDO2_P, CEDULA, NACIONALEXTRANJERO, FECHANACIMIENTO, TELEFONO, BORRADO_PACIENTE FROM PACIENTES WHERE ID_PACIENTE = {0}", id);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    paciente = new EntidadPacientes();
                    dataReader.Read();
                    paciente.Id_Paciente = dataReader.GetInt32(0);
                    paciente.Nombre_P = dataReader.GetString(1);
                    paciente.Apellido1_P= dataReader.GetString(2);
                    paciente.Apellido2_P = dataReader.GetString(3);
                    paciente.Cedula_P= dataReader.GetString(4);
                    paciente.Nacionalidad = dataReader.GetString(5);
                    paciente.Fecha_Na = dataReader.GetDateTime(6);
                    paciente.Telefono = dataReader.GetString(7);
                    paciente.Borrado_P = dataReader.GetBoolean(8);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return paciente;
        }
        #endregion

        #region Eliminar paciente (B/logico)
        public int EliminarPaciente(EntidadPacientes paciente)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE PACIENTES SET BORRADO_PACIENTE =@BORRADO_P WHERE ID_PACIENTE = @ID_PACIENTE";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_PACIENTE", paciente.Id_Paciente);
            comando.Parameters.AddWithValue("@BORRADO_P",true);
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

        #region Actualizar Paciente
        public int ActualizarPaciente(EntidadPacientes paciente)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE PACIENTES SET NOMBRE_P =@NOMBRE_P, APELLIDO1_P =@APELLIDO1, APELLIDO2_P=@APELLIDO2, CEDULA=@CEDULA, NACIONALEXTRANJERO=@NACIONALIDAD, FECHANACIMIENTO=@FECHANA, TELEFONO=@TELEFONO, BORRADO_PACIENTE =@BORRADO_P WHERE ID_PACIENTE = @ID_PACIENTE";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_PACIENTE", paciente.Id_Paciente);
            comando.Parameters.AddWithValue("@NOMBRE_P", paciente.Nombre_P);
            comando.Parameters.AddWithValue("@APELLIDO1", paciente.Apellido1_P);
            comando.Parameters.AddWithValue("@APELLIDO2", paciente.Apellido2_P);
            comando.Parameters.AddWithValue("@CEDULA", paciente.Cedula_P);
            comando.Parameters.AddWithValue("@NACIONALIDAD", paciente.Nacionalidad);
            comando.Parameters.AddWithValue("@FECHANA", paciente.Fecha_Na);
            comando.Parameters.AddWithValue("@TELEFONO", paciente.Telefono);
            comando.Parameters.AddWithValue("@BORRADO_P",paciente.Borrado_P);
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
