using Newtonsoft.Json;
using PerFin.Entities.Base;

namespace PerFin.Entities.Authentication
{
    public class SessionInfo: EntityBase
    {
        public SessionInfo(string sessionId, int errorCode)
            :base(errorCode)
        {
            SessionId = sessionId;
        }
        public string SessionId { get; set; }
    }
}
