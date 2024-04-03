namespace B2B.API.Dtos.ProfileDtos
{
    public class UserUpdateModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
