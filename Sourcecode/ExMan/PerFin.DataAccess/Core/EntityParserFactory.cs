using System;

namespace PerFin.DataAccess.Core
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
                case EntityConstants.TRANSACTION:
                    parser = new TransactionParser();
                    break;
                    
            }
            return parser;
        }
    }
}
