using B2B.API.Dtos.ProductDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Dtos.ProductColorDtos
{
    public class ResultProductColorDto
    {
        public int ProductColorID { get; set; }

        public int productID { get; set; }
        public ResultProductDto product { get; set; }

        public int ColorID { get; set; }
        public Color color { get; set; }
    }
}
