using ExMan.Entities;
using ExMan.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ExMan.DataAccess.Core
{
    public class ComponentTypeParser : IEntityParser
    {
        private int ord_ComponentTypeId;
        private int ord_ComponentTypeCode;
        private int ord_ComponentTypeName;

        public EntityBase PopulateEntity(SqlDataReader reader)
        {
            ComponentType componentType = new ComponentType();
            if (!reader.IsDBNull(ord_ComponentTypeId)) componentType.Id = reader.GetGuid(ord_ComponentTypeId);
            if (!reader.IsDBNull(ord_ComponentTypeCode)) componentType.ComponentTypeCode = reader.GetString(ord_ComponentTypeCode);
            if (!reader.IsDBNull(ord_ComponentTypeName)) componentType.ComponentTypeName = reader.GetString(ord_ComponentTypeName);
            return componentType;
        }

        public void PopulateOrdinals(SqlDataReader reader)
        {
            ord_ComponentTypeId = reader.GetOrdinal(DBColumnConstants.COMPONENTTYPEID);
            ord_ComponentTypeCode = reader.GetOrdinal(DBColumnConstants.COMPONENTTYPECODE);
            ord_ComponentTypeName = reader.GetOrdinal(DBColumnConstants.COMPONENTTYPENAME);
        }

        public SqlParameter[] PopulateParameters(EntityBase entity)
        {
            throw new NotImplementedException();
        }

    }
}
