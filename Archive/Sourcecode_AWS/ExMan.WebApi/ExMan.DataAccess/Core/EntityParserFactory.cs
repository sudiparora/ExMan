using System;
using System.Collections.Generic;
using System.Text;

namespace ExMan.DataAccess.Core
{
    internal sealed class EntityParserFactory
    {
        internal IEntityParser GetParser(Type entityType)
        {
            IEntityParser parser = null;
            switch (entityType.Name)
            {
                case EntityConstants.COMPONENTTYPE:
                    parser = new ComponentTypeParser();
                    break;
            }
            return parser;
        }
    }
}
