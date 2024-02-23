using System.ComponentModel.DataAnnotations;

namespace B2B.API.Dtos.ChildSubCategoryDtos
{
    public class ResultChildSubCategoryDto
    {
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int ChildSubCategoryID { get; set; }

        public string Name { get; set; }
    }
}
