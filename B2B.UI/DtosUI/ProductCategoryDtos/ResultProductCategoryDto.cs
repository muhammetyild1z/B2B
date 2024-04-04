
using B2B.UI.DtosUI.CategoryDtos;
using B2B.UI.DtosUI.ChildSubCategoryDtos;
using B2B.UI.DtosUI.ParentSubCategoryDtos;
using B2B.UI.DtosUI.ProductDtos;
using B2B.UI.DtosUI.ProductPriceDtos;


namespace B2B.UI.DtosUI.ProductCategoryDtos
{
    public class ResultProductCategoryDto
    {
        public int ProductCategoryID { get; set; }

        public ResultCategoryDto? category { get; set; }
        public int CategoryID { get; set; }

        public ResultParentSubCategoryDto? parentSubCategory { get; set; }
        public int? ParentSubCategoryID { get; set; }

        public ResultChildSubCategoryDto? ChildSubCategory { get; set; }
        public int? ChildSubCategoryID { get; set; }

        public int ProductID { get; set; }
        public  ResultProductDto product { get; set; }

        public int? ProductPriceID { get; set; }
        public ResultProductPriceDto? productPrice { get; set; }
    }
}
