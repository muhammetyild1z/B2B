using System.ComponentModel.DataAnnotations;

namespace B2B.UI.DtosUI.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryID { get; set; }

        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

        public string Name { get; set; }
    }
}
