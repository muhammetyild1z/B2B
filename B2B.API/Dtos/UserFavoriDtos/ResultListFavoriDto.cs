using B2B.EntityLayer.Concrate;

namespace B2B.API.Dtos.UserFavoriDtos
{
	public class ResultListFavoriDto
	{
		public int FavoriID { get; set; }

		public ProductPrice price { get; set; }
		public int priceID { get; set; }
		public AppUser appUser { get; set; }
		public string userID { get; set; }
		public DateTime createDate { get; set; }
	}
}
