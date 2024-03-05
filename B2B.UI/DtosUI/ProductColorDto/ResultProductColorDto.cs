using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.ProductDtos;

namespace B2B.UI.DtosUI.ProductColorDto
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
