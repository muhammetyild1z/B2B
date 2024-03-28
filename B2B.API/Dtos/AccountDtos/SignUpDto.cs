using System.ComponentModel.DataAnnotations;

namespace B2B.API.Dtos.AccountDtos
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakılamaz.")]
        public string PasswordR { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")]
        public string UserName { get; set; }  
        [Required(ErrorMessage = "Isim alanı boş bırakılamaz.")]
        public string NameSurname { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
