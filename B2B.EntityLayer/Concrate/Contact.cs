using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class Contact
    {
        public int ContactID { get; set; }
        [MaxLength(300)]
        public  string? ContactDesc { get; set; }
        [MaxLength(300)]
        public  string ContactAdress { get; set; }
        [MaxLength(11)]
        public  string ContactPhone1 { get; set; }
        [MaxLength(11)]
        public  string? ContactPhone2 { get; set; }
        [MaxLength(100)]
        public  string ContactMail1 { get; set; }
        [MaxLength(100)]
        public  string? ContactMail2 { get; set; }

    }
}
