using ExMan.DTO.Base;

namespace ExMan.DTO
{
    public class ComponentTypeDTO: DTOBase
    {
        public int Id { get; set; }
        public string ComponentTypeCode { get; set; }
        public string ComponentTypeName { get; set; }

    }
}
