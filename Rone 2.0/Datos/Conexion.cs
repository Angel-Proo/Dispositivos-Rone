using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace Rone_2._0.Datos
{
    public class Conexion
    {
        public static string conn()
        {
            string cadenaConexion = "User=SYSDBA;" + "Password=P4ssw0rd;" + "Database=C:\\rone\\rone.FDB;" + "DataSource=192.168.1.108;" + "Port=3050;";
            return cadenaConexion;
        }
    }
}
