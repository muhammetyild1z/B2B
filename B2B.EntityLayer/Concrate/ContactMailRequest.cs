using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class ContactMailRequest
    {
        public int ContactMailRequestID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }   
        [MaxLength(11)]
        public string Phone { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }

    }
}
