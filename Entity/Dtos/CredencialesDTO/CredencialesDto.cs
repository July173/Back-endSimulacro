﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;


namespace Entity.Dtos.CredencialesDTO
{
    public class CredencialesDto : GenericDto
    {
        public  string Email { get; set; }
        public  string Password { get; set; }
    }
}
