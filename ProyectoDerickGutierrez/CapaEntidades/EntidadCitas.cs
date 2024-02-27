using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadCitas
    {
        #region Atributos
        private int id_Cita;
        private int id_Paciente;
        private int id_Funcionario;
        private DateTime fecha;
        private string duracion;
        private bool borrado;
        #endregion

        #region Propiedades
        public int Id_Cita { get => id_Cita; set => id_Cita = value; }
        public int Id_Paciente { get => id_Paciente; set => id_Paciente = value; }
        public int Id_Funcionario { get => id_Funcionario; set => id_Funcionario = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public bool Borrado { get => borrado; set => borrado = value; }
        #endregion

        #region Constructores
        public EntidadCitas()
        {
            this.id_Cita= 0;
            this.id_Paciente= 0;
            this.id_Funcionario = 0;
            this.fecha= DateTime.Now;
            this.duracion = string.Empty;
            this.borrado= false;
        }
        public EntidadCitas(int id_Cita, int id_Paciente, int id_Funcionario, DateTime fecha, string duracion, bool borrado)
        {
            Id_Cita = id_Cita;
            Id_Paciente = id_Paciente;
            Id_Funcionario = id_Funcionario;
            Fecha = fecha;
            Duracion = duracion;
            Borrado = borrado;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0} - {1}", id_Cita, id_Paciente);
        }
    }
}
