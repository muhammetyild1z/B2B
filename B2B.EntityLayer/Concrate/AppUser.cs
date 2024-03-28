using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class AppUser: IdentityUser
    {
        public DateTime CreateDate { get; set; }
        [MaxLength(150)]
        public string NameSurname { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string? Address { get; set; }

    }
}
