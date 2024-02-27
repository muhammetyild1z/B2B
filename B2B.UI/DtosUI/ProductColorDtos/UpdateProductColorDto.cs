using B2B.UI.DtosUI.ProductDtos;
using B2B.EntityLayer.Concrate;
using System.ComponentModel.DataAnnotations;

namespace B2B.UI.DtosUI.ProductColorDtos
{
    public class UpdateProductColorDto
    {
        public int ProductColorID { get; set; }
 
        public string ColorCode { get; set; }

        public ResultProductDto product { get; set; }
        public int ProductID { get; set; }
    }
}
