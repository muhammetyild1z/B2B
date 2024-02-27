using B2B.API.Dtos.ProductDtos;
using B2B.EntityLayer.Concrate;
using System.ComponentModel.DataAnnotations;

namespace B2B.API.Dtos.HomeSliderDtos
{
    public class ResultHomeSliderDto
    {
        public int SliderID { get; set; }
      
        public string SliderDescription { get; set; }
        
        public string SliderTitle { get; set; }
        public string SliderImg { get; set; }

        public int ProductID { get; set; }
        public ResultProductDto product { get; set; }
    }
}
