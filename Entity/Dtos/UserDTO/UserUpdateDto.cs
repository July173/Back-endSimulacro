﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.Dtos.UserDTO
{
    public  class UserUpdateDto : BaseDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
