using PerFin.Core;
using PerFin.Core.Contracts;
using PerFin.DataAccess.Core;
using PerFin.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PerFin.DataAccess.Base
{
    public abstract class EntityDACBase : DACBase
    {

        protected EntityDACBase(IAppSettings appSettings)
        {
            AppSettingsInstance = appSettings;
        }

        /// <summary>
        /// http://geekswithblogs.net/BlackRabbitCoder/archive/2010/05/19/c-system.lazylttgt-and-the-singleton-design-pattern.aspx
        /// The .net provided lazy initialization and singleton design pattern usage
        /// </summary>
        private static readonly Lazy<EntityParserFactory> entityParserFactoryInstance
            = new Lazy<EntityParserFactory>(() => new EntityParserFactory());

        internal static EntityParserFactory EntityParserFactoryInstance
        {
            get
            {
                return entityParserFactoryInstance.Value;
            }
        }

        protected static T GetSingleEntity<T>(ref SqlCommand command) where T : EntityBase
        {
            T entity = null;
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    IEntityParser parser = EntityParserFactoryInstance.GetParser(typeof(T));
                    parser.PopulateOrdinals(reader);
                    entity = (T)parser.PopulateEntity(reader);
                    reader.Close();
                }
                else
                {
                    // Whenever there's no data, we return null.
                    entity = null;
                }
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            // return the entity object, it's either populated with data or null.
            return entity;
        }

        protected List<T> GetEntities<T>(ref SqlCommand command) where T : EntityBase
        {
            List<T> entities = new List<T>();
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IEntityParser parser = EntityParserFactoryInstance.GetParser(typeof(T));
                parser.PopulateOrdinals(reader);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        entities.Add((T)parser.PopulateEntity(reader));
                    }
                }
                reader.Close();
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return entities;
        }

        protected static DbOperationResult GetDbOperationResult(ref SqlCommand command, string columnName = null)
        {
            DbOperationResult sqlDbOperation = new DbOperationResult();
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                sqlDbOperation.StatusCode = (int)command.Parameters[DBConstants.STATUSCODE].Value;
                if (sqlDbOperation.StatusCode == 0 && !string.IsNullOrEmpty(columnName))
                {
                    sqlDbOperation.Result = command.Parameters[columnName].Value;
                }
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return sqlDbOperation;
        }
    }
}
