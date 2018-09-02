using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.DataAccess.Base
{
    public abstract class DACBase : ParameterBase
    {

        private const string DATABASECONNECTIONSTRING = "SqlDataConString";

        protected static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[DATABASECONNECTIONSTRING].ConnectionString; }
        }

        /// <summary>
        /// Returns SQL Command object
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <returns></returns>
        protected static SqlCommand GetDbSQLCommand(string sqlQuery)
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
        protected static SqlConnection GetDbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Returns SQL command object for stored procedure calls. 
        /// </summary>
        /// <param name="sprocName">Name of stored procedure</param>
        /// <returns></returns>
        protected static SqlCommand GetDbSprocCommand(string sprocName)
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
