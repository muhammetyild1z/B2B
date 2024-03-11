

using B2B.API.Dtos.ProductDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Dtos.DimensionsDto
{
    public class ResultDimensionsDto
    {
        public int ProductdimensionsID { get; set; }
         public ResultProductDto product { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductID { get; set; }
        public Dimensions dimensions { get; set; }
        public int DimensionsID { get; set; }
    }
}
