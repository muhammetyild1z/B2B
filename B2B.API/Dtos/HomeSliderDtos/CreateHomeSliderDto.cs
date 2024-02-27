using B2B.API.Dtos.ProductDtos;

namespace B2B.API.Dtos.HomeSliderDtos
{
    public class CreateHomeSliderDto
    {

        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string SliderDescription { get; set; }

        public string SliderTitle { get; set; }
        public string SliderImg { get; set; }

        public int ProductID { get; set; }
      
    }
}
