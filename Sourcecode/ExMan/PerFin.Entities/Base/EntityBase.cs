using System;

namespace PerFin.Entities.Base
{
    public abstract class EntityBase
    {
        public EntityBase(int errorCode = int.MinValue)
        {
            ErrorCode = errorCode;
        }
        public int ErrorCode { get; set; }

    }
}
