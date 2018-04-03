using ExMan.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.DataAccess.Core
{
    public interface IEntityParser
    {
        EntityBase PopulateEntity(SqlDataReader reader);
        void PopulateOrdinals(SqlDataReader reader);
        SqlParameter[] PopulateParameters(EntityBase entity);
    }
}
