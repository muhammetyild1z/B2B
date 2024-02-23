using B2B.API.Dtos.ProductDtos;
using B2B.EntityLayer.Concrate;
using System.ComponentModel.DataAnnotations;

namespace B2B.API.Dtos.ProductColorDtos
{
    public class ResultProductColorDto
    {
        public int ProductColorID { get; set; }
  
        public string ColorCode { get; set; }

        public ResultProductDto product { get; set; }
        public int ProductID { get; set; }
    }
}
