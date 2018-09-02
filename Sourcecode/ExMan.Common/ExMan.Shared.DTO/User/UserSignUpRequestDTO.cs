using ExMan.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Shared.DTO
{
    public class UserSignUpRequestDTO : DTOBase
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PasswordHash { get; set; }
    }
}
