using PerFin.Entities.Base;
using System.Data.SqlClient;

namespace PerFin.DataAccess.Core
{
    public interface IEntityParser
    {
        EntityBase PopulateEntity(SqlDataReader reader);
        void PopulateOrdinals(SqlDataReader reader);
        SqlParameter[] PopulateParameters(EntityBase entity);
    }
}
