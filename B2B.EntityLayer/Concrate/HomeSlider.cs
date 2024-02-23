using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class HomeSlider : Base
    {
        public int SliderID { get; set; }
        [MaxLength(200)]
        public string SliderDescription { get; set; }
        [MaxLength(50)]
        public string SliderTitle { get; set; }


        public int ProductID { get; set; }
        public Product product { get; set; }
    }
}
