﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Custom_Auth.Domain.ViewModels
{
    public class LoginModel
    {
      
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
