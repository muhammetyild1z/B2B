namespace B2B.API.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }

        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

        public string Name { get; set; }
    }
}
