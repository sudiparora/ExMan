﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Shared.DTO
{
    public class BearerTokenDTO
    {

        public string AccessToken { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
