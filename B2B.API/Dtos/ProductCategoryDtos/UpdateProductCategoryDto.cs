using B2B.API.Dtos.CategoryDtos;
using B2B.API.Dtos.ChildSubCategoryDtos;
using B2B.API.Dtos.ParentSubCategoryDtos;
using B2B.API.Dtos.ProductDtos;

namespace B2B.API.Dtos.ProductCategoryDtos
{
    public class UpdateProductCategoryDto
    {
        public int ProductCategoryID { get; set; }

      
        public int CategoryID { get; set; }

       
        public int? ParentSubCategoryID { get; set; }

       
        public int? ChildSubCategoryID { get; set; }

        public int ProductID { get; set; }
    
    }
}
