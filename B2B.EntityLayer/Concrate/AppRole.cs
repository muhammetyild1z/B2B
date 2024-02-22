﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class AppRole: IdentityRole
    {
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
