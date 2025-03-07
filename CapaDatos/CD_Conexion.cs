using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    
    public class CD_Conexion
    {
        

        public SqlConnection db_conexion = new SqlConnection("Data Source=DESKTOP-58DVMFN;Initial Catalog=db_AgenciaCarros;Integrated Security=True;Encrypt=False");

        public SqlConnection MtdAbrirConexion()
        {
            if(db_conexion.State == ConnectionState.Closed)
                db_conexion.Close();
            return db_conexion;
        }

        public SqlConnection MtdCerrarConexion()
        {
            if (db_conexion.State == ConnectionState.Closed)
                db_conexion.Close();
            return db_conexion;
        }
    }
}
