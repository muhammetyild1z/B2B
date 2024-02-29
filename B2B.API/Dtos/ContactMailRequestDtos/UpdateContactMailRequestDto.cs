namespace B2B.API.Dtos.ContactMailRequestDtos
{
    public class UpdateContactMailRequestDto
    {
        public int ContactMailRequestID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }
    }
}
