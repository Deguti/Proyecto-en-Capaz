using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadEspecialidades
    {
        #region Atributos
        private int id_Especialidad;
        private int id_Funcionario;
        private string nombre;
        private string descripcion;
        private bool borrado;
        #endregion

        #region Propiedades
        public int Id_Funcionario { get => id_Funcionario; set => id_Funcionario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Borrado { get => borrado; set => borrado = value; }
        public int Id_Especialidad { get => id_Especialidad; set => id_Especialidad = value; }
        #endregion

        #region Constructores
        public EntidadEspecialidades() 
        {
            this.id_Especialidad = 0;
            this.id_Funcionario=0;
            this.nombre = string.Empty;
            this.descripcion= string.Empty;
            this.borrado = false;    
        }
        public EntidadEspecialidades(int id_Especialidad,int id_Funcionario, string nombre, string descripcion, bool borrado)
        {
            Id_Especialidad = id_Especialidad;
            Id_Funcionario = id_Funcionario;
            Nombre = nombre;
            Descripcion = descripcion;
            Borrado = borrado;
        }
        #endregion
        public override string ToString()
        {
            return string.Format("{0} - {1}", id_Funcionario, nombre);
        }
    }
}
