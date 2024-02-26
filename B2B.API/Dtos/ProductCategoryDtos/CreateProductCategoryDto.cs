namespace B2B.API.Dtos.ProductCategoryDtos
{
    public class CreateProductCategoryDto
    {
       


        public int CategoryID { get; set; }


        public int? ParentSubCategoryID { get; set; }


        public int? ChildSubCategoryID { get; set; }

        public int ProductID { get; set; }
    }
}
