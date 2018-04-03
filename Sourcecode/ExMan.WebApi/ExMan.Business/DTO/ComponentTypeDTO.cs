using ExMan.Business.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Business.DTO
{
    public class ComponentTypeDTO: DTOBase
    {
        public int Id { get; set; }
        public string ComponentTypeCode { get; set; }
        public string ComponentTypeName { get; set; }

    }
}
