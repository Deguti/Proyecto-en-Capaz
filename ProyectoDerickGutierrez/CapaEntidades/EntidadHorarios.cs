using System;

namespace CapaEntidades
{
    public class EntidadHorarios
    {
        #region Atributos
        private int id_Horario;
        private int id_Funcionario;
        private TimeSpan hora_Inicio;
        private TimeSpan hora_Final;
        private string dia_Inicio;
        private string dia_Fin;
        private bool borrado;
        #endregion

        #region Propiedades
        public int Id_Horario { get => id_Horario; set => id_Horario = value; }
        public int Id_Funcionario { get => id_Funcionario; set => id_Funcionario = value; }
        public TimeSpan Hora_Inicio { get => hora_Inicio; set => hora_Inicio = value; }
        public TimeSpan Hora_Final { get => hora_Final; set => hora_Final = value; }
        public string Dia_Inicio { get => dia_Inicio; set => dia_Inicio = value; }
        public string Dia_Fin { get => dia_Fin; set => dia_Fin = value; }
        public bool Borrado { get => borrado; set => borrado = value; }
        #endregion

        #region Constructor
        public EntidadHorarios()
        {
            this.Id_Horario = 0;
            this.Id_Funcionario = 0;
            this.Hora_Inicio = TimeSpan.Zero;
            this.Hora_Final = TimeSpan.Zero;
            this.Dia_Inicio = string.Empty; ;
            this.Dia_Fin = string.Empty;
            this.borrado = false;
        }
        public EntidadHorarios(int id_Horario,int id_Funcionario, TimeSpan hora_Inicio, TimeSpan hora_Final, string dia_Inicio, string dia_Fin, bool borrado)
        {
            Id_Horario = id_Horario;
            Id_Funcionario = id_Funcionario;
            Hora_Inicio = hora_Inicio;
            Hora_Final = hora_Final;
            Dia_Inicio = dia_Inicio;
            Dia_Fin = dia_Fin;
            Borrado= borrado;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0}", Id_Horario);
        }

    }
}
