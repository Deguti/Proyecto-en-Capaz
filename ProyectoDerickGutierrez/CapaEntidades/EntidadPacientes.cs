using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadPacientes
    {
        #region Atributos
        private int id_Paciente;
        private string nombre_P;
        private string apellido1_P;
        private string apellido2_P;
        private string cedula_P;
        private string nacionalidad;
        private DateTime fecha_Na;
        private string telefono;
        private bool borrado_P;
        #endregion

        #region Propiedades
        public int Id_Paciente { get => id_Paciente; set => id_Paciente = value; }
        public string Nombre_P { get => nombre_P; set => nombre_P = value; }
        public string Apellido1_P { get => apellido1_P; set => apellido1_P = value; }
        public string Apellido2_P { get => apellido2_P; set => apellido2_P = value; }
        public string Cedula_P { get => cedula_P; set => cedula_P = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public DateTime Fecha_Na { get => fecha_Na; set => fecha_Na = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public bool Borrado_P { get => borrado_P; set => borrado_P = value; }
        #endregion

        #region Constructor
        public EntidadPacientes()
        {
            this.id_Paciente = 0;
            this.nombre_P = string.Empty;
            this.apellido1_P= string.Empty;
            this.apellido2_P = string.Empty;
            this.cedula_P= string.Empty;
            this.nacionalidad= string.Empty;
            this.fecha_Na = DateTime.Now;
            this.telefono= string.Empty;
            this.borrado_P = false;
        }
        public EntidadPacientes(int id_Paciente, string nombre_P, string apellido1_P, string apellido2_P, string cedula_P, string nacionalidad, DateTime fecha_Na, string telefono, bool borrado_P)
        {
            Id_Paciente = id_Paciente;
            Nombre_P = nombre_P;
            Apellido1_P = apellido1_P;
            Apellido2_P = apellido2_P;
            Cedula_P = cedula_P;
            Nacionalidad = nacionalidad;
            Fecha_Na = fecha_Na;
            Telefono = telefono;
            Borrado_P = borrado_P;
        }
        #endregion
        public override string ToString()
        {
            return string.Format("{0} - {1}", id_Paciente, nombre_P);
        }
    }
}
