using B2B.API.Dtos.CategoryDtos;
using B2B.API.Dtos.ChildSubCategoryDtos;
using B2B.API.Dtos.ParentSubCategoryDtos;
using B2B.API.Dtos.ProductDtos;


namespace B2B.API.Dtos.ProductCategoryDtos
{
    public class ResultProductCategoryDto
    {
        public int ProductCategoryID { get; set; }

        public ResultCategoryDto category { get; set; }
        public int CategoryID { get; set; }

        public ResultParentSubCategoryDto parentSubCategory { get; set; }
        public int? ParentSubCategoryID { get; set; }

        public ResultChildSubCategoryDto ChildSubCategory { get; set; }
        public int? ChildSubCategoryID { get; set; }

        public int ProductID { get; set; }
        public  ResultProductDto product { get; set; }
    }
}
