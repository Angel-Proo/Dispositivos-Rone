using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace Rone_2._0.Datos
{
    public class Actualizar_Usuarios
    {
        public string Procedure { get; set; }
        public string Conexion { get; set; }
        public Actualizar_Usuarios(string procedure)
        {
            Procedure = procedure;
            Conexion = Datos.Conexion.conn();
        }
        public DataTable Buscar()
        {
            DataTable dt = new DataTable();
            FbDataAdapter da = new FbDataAdapter(Procedure, Conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
            return dt;
        }
    }
}

