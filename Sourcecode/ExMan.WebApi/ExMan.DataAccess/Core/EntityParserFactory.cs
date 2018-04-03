using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
