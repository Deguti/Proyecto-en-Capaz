using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadFuncionarios
    {
        #region Atributos
        private int id_funcionario;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private string cedula;
        private string telefono;
        private string puesto;
        private bool borrado;
        #endregion

        #region Propiedades
        public int Id_funcionario { get => id_funcionario; set => id_funcionario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Puesto { get => puesto; set => puesto = value; }
        public bool Borrado { get => borrado; set => borrado = value; }
        #endregion

        #region Constructores
        public EntidadFuncionarios()
        {
            this.Id_funcionario = 0;
            this.Nombre = string.Empty;
            this.apellido1= string.Empty;
            this.apellido2 = string.Empty;
            this.Cedula = string.Empty;
            this.Telefono = string.Empty;
            this.Puesto= string.Empty;
            this.Borrado = false;
        }

        public EntidadFuncionarios(int id_funcionario, string nombre, string apellido1,string apellido2, string cedula, string telefono, string puesto, bool borrado)
        {
            Id_funcionario = id_funcionario;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Cedula = cedula;
            Telefono = telefono;
            Puesto = puesto;
            Borrado = borrado;
           
        }

    
        #endregion

        public override string ToString()
        {
            return string.Format("{0} - {1}", Id_funcionario, Nombre);
        }
    }
}
