using Newtonsoft.Json;
using PerFin.Entities.Base;

namespace PerFin.Entities.Authentication
{
    public class SessionInfo: EntityBase
    {
        public SessionInfo() { }
        public string SessionId { get; set; }
    }
}
