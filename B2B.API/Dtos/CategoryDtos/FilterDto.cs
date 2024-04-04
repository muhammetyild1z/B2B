namespace B2B.API.Dtos.CategoryDtos
{
    public class FilterDto
    {
        public  List<int>? ParentCategoryId { get; set; }
        public List<int>? SizesId { get; set; }
    }
}
