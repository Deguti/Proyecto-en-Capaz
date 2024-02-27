using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    internal class EntidadPagos
    {
        #region Atributos 
        private int id_Pago;
        private int id_Cita;
        private decimal monto;
        private string metodo_Pago;
        private bool borrado;
        #endregion

        #region Propiedades
        public int Id_Pago { get => id_Pago; set => id_Pago = value; }
        public int Id_Cita { get => id_Cita; set => id_Cita = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public string Metodo_Pago { get => metodo_Pago; set => metodo_Pago = value; }
        public bool Borrado { get => borrado; set => borrado = value; }
        #endregion

        #region Constructores
        public EntidadPagos()
        {
            this.id_Pago = 0;
            this.id_Cita = 0;
            this.monto = 0;
            this.metodo_Pago = string.Empty;
            this.borrado = false;
        }
        public EntidadPagos(int id_Pago, int id_Cita, decimal monto, string metodo_Pago, bool borrado)
        {
            Id_Pago = id_Pago;
            Id_Cita = id_Cita;
            Monto = monto;
            Metodo_Pago = metodo_Pago;
            Borrado = borrado;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0} - {1}", id_Pago,id_Cita);
        }
    }
}
