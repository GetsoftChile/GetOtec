using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using ENT;

namespace DAL
{
    

    public class PerfilAccess
    {
        Database db = DatabaseFactory.CreateDatabase();

        public DataSet GetBuscarPerfil(Perfil per)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarPerfil");
            //@idMandante int, @nomMandante varchar(30), @razonSocial varchar(100), @giro varchar(50), @rut varchar(12), @activo int
            db.AddInParameter(cmd, "@idPerfil", DbType.String, per.IdPerfil);
            
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el perfil, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el perfil, " + ex.Message, ex);
            }
        }

        


    }
}
