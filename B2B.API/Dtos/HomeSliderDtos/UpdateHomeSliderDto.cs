using B2B.API.Dtos.ProductDtos;

namespace B2B.API.Dtos.HomeSliderDtos
{
    public class UpdateHomeSliderDto
    {
        public int SliderID { get; set; }

        public string SliderDescription { get; set; }

        public string SliderTitle { get; set; }


        public int ProductID { get; set; }
        public ProductResultDto product { get; set; }
    }
}
