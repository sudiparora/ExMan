using ExMan.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ExMan.DataAccess.Core
{
    public interface IEntityParser
    {
        EntityBase PopulateEntity(SqlDataReader reader);
        void PopulateOrdinals(SqlDataReader reader);
        SqlParameter[] PopulateParameters(EntityBase entity);
    }
}
