using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.DataAccess.Core
{
    internal struct EntityConstants
    {
        internal const string COMPONENTTYPE = "ComponentType";
    }

    internal struct DBColumnConstants
    {
        internal const string COMPONENTTYPEID = "ComponentTypeId";
        internal const string COMPONENTTYPECODE = "ComponentTypeCode";
        internal const string COMPONENTTYPENAME = "ComponentTypeName";
    }

    internal struct SPConstants
    {
        internal const string SP_FETCH_COMPONENTS_FOR_USER = "usp_FetchComponentsForUser";
    }

}
