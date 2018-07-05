using System;
using System.Collections.Generic;
using System.Text;

namespace ExMan.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

    }
}
