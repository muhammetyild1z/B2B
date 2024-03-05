using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.ProductDtos;

namespace B2B.UI.DtosUI.DimensionsDtos
{
    public class ResultDimensionsDto
    {
        public int ProductdimensionsID { get; set; }
      //  public ResultProductDto product { get; set; }
        public int ProductID { get; set; }
        public Dimensions dimensions { get; set; }
        //public int DimensionsID { get; set; }
    }
}
