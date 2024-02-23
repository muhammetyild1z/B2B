using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace B2B.API.Dtos.ParentSubCategoryDtos
{
    public class ResultParentSubCategoryDto
    {
       
        public int ParentSubCategoryID { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}
