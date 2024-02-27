using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;
using System.Linq;
using System.Reflection;

namespace _03_CapaAccesoDatos
{
    public class DACita
    {
        #region Cadena Conexion
        private string _cadenaConexion;
        private string _mensaje;

        //propiedades
        public string Mensaje { get => _mensaje; }

        //constructor
        public DACita(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        #endregion

        #region Insertar Cita
        public int InsertarCita(EntidadCitas cita)
        {
            int id = 0;
            SqlConnection cnx = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnx;
            string sentencia = "INSERT INTO CITAS (ID_PACIENTE,ID_FUNCIONARIO,FECHA, HORA_CITA,BORRADO_CITA)" +
                " VALUES(@PACIENTE,@FUNCIONARIO, @FECHA, @HORA, @BORRADO) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@FUNCIONARIO", cita.Id_Funcionario);
            comando.Parameters.AddWithValue("@PACIENTE", cita.Id_Paciente);
            comando.Parameters.AddWithValue("@FECHA", cita.Fecha);
            comando.Parameters.AddWithValue("@HORA", cita.Duracion);
            comando.Parameters.AddWithValue("@BORRADO", cita.Borrado);
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

        #region Obtener Paciente
        public EntidadPacientes ObtenerPaciente(int id)
        {
            EntidadPacientes paciente = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_PACIENTE, NOMBRE_P, APELLIDO1_P, CEDULA FROM PACIENTES WHERE ID_PACIENTE = {0}", id);
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
                    paciente.Apellido1_P = dataReader.GetString(2);
                    paciente.Cedula_P = dataReader.GetString(4);
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

        #region Acceder a lista de Citas
        public DataSet ListarHorariosRegistrados(DateTime dia, int doctor)
        {
            DataSet Datos = new DataSet();
            SqlConnection conn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia;
            sentencia = $"SELECT ID_CITA, FECHA, HORA_CITA  FROM CITAS WHERE ID_FUNCIONARIO = '{doctor}' AND Convert(date, FECHA) = '{dia.Date.ToString("yyyy-MM-dd")}' AND BORRADO_CITAS = 0";
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

        #region Lista de Especialidades
        public DataSet ListarEspecialistas()
        {
            DataSet Datos = new DataSet();
            SqlConnection conn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT DISTINCT ID_ESPECIALIDAD, NOMBRE FROM ESPECIALIDADES WHERE BORRADO_ESPECIALIDAD = 0";
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

        #region Lista de Doctores
        public DataSet ListarDoctores(int idEspecialidad)
        {
            DataSet Datos = new DataSet();
            SqlConnection conn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = $"SELECT DISTINCT E.ID_Funcionario, F.NOMBRE FROM FUNCIONARIOS F INNER JOIN ESPECIALIDADES E ON E.ID_FUNCIONARIO = F.ID_FUNCIONARIO  WHERE E.ID_ESPECIALIDAD = {idEspecialidad} AND PUESTO_TRABAJO = 'DOCTOR' AND BORRADO_ESPECIALIDAD =0 AND BORRADO_FUNCIONARIO =0";
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
        }
        #endregion

        #region Lista de funcionarios
        public DataSet ListarFuncionarios(string nombreEspecialidad)
        {
            DataSet Datos = new DataSet();
            SqlConnection conn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = $"SELECT DISTINCT F.ID_FUNCIONARIO FROM FUNCIONARIOS F INNER JOIN ESPECIALIDADES E ON E.ID_FUNCIONARIO = F.ID_FUNCIONARIO  WHERE E.NOMBRE = '{nombreEspecialidad}' AND PUESTO_TRABAJO = 'DOCTOR' AND BORRADO_ESPECIALIDAD =0 AND BORRADO_FUNCIONARIO =0";
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
        }
        #endregion

        #region Lista de Horarios
        public DataSet ListarHorarios(string dia, int idDoctor)
        {
            DataSet Datos = new DataSet();
            SqlConnection conn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = $"select HORA_INICIO, HORA_FIN FROM Horarios WHERE DIA_INICIO = '{dia}' AND BORRADO_HORARIO =0 AND ID_FUNCIONARIO = '{idDoctor}'";
            ;
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
        }
        #endregion

        #region Insertar Cita
        public int Insertar(EntidadCitas cita)
        {
            int id = 0;
            SqlConnection cnx = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnx;
            string sentencia = "INSERT INTO Citas( ID_PACIENTE,ID_FUNCIONARIO, FECHA, HORA_CITA,BORRADO_CITAS)" +
                " VALUES(@ID_PACIENTE,@ID_FUNCIONARIO, @FECHA, @HORA_CITA,@BORRADO) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@ID_PACIENTE", cita.Id_Paciente);
            comando.Parameters.AddWithValue("@ID_FUNCIONARIO", cita.Id_Funcionario);
            comando.Parameters.AddWithValue("@FECHA", cita.Fecha);
            comando.Parameters.AddWithValue("@HORA_CITA", cita.Duracion);
            comando.Parameters.AddWithValue("@BORRADO", cita.Borrado);
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

        #region Eliminar Cita (B/logico)
        public int EliminarCitas(EntidadCitas cita)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE CITAS SET BORRADO_CITAS =@BORRADO_P WHERE ID_CITA = @ID_CITA";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_CITA", cita.Id_Cita);
            comando.Parameters.AddWithValue("@BORRADO_P", true);
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
