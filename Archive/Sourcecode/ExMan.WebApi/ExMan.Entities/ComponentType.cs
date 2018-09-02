using ExMan.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Entities
{
    public class ComponentType: EntityBase
    {
        public int Id { get; set; }
        public string ComponentTypeCode { get; set; }
        public string ComponentTypeName { get; set; }
    }
}
