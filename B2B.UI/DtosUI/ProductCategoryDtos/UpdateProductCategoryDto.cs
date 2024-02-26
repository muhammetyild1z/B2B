
 

namespace B2B.UI.DtosUI.ProductCategoryDtos
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
