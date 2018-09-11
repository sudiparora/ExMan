using PerFin.Core.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace PerFin.DataAccess.Base
{
    public abstract class DACBase : ParameterBase
    {
        internal IAppSettings AppSettingsInstance { get; set; }
       
        protected string ConnectionString
        {
            get { return AppSettingsInstance.DbConnectionString; }
        }

        /// <summary>
        /// Returns SQL Command object
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <returns></returns>
        protected SqlCommand GetDbSQLCommand(string sqlQuery)
        {
            SqlCommand command = new SqlCommand
            {
                Connection = GetDbConnection(),
                CommandType = CommandType.Text,
                CommandText = sqlQuery
            };
            return command;
        }

        /// <summary>
        /// Returns databse connection
        /// </summary>
        /// <returns></returns>
        protected SqlConnection GetDbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Returns SQL command object for stored procedure calls. 
        /// </summary>
        /// <param name="sprocName">Name of stored procedure</param>
        /// <returns></returns>
        protected SqlCommand GetDbSprocCommand(string sprocName)
        {
            SqlCommand command = new SqlCommand(sprocName)
            {
                Connection = GetDbConnection(),
                CommandType = CommandType.StoredProcedure
            };
            return command;
        }


    }
}
