using B2B.UI.DtosUI.ProductDtos;

namespace B2B.UI.DtosUI.HomeSliderDtos
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
