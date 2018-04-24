using ExMan.Shared.DTO.Base;
using Newtonsoft.Json;

namespace ExMan.Shared.DTO
{
    public class ComponentTypeDTO: DTOBase
    {
        public int Id { get; set; }
        [JsonProperty("ComponentTypeCode")]
        public string ComponentTypeCode { get; set; }
        [JsonProperty("ComponentTypeName")]
        public string ComponentTypeName { get; set; }

    }
}
