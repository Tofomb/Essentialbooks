﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Essentialbooks.Models
{
    public class RealUser
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}