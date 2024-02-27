using System;
using System.Collections.Generic;
using System.Text;

namespace _01_CapaPresentacion
{
    internal class Configuracion
    {
        public static string getConnectionString
        {
            get
            {
                return Properties.Settings.Default.connectionString;
            }
        }
    }
}
