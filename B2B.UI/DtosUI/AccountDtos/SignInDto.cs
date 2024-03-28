﻿using System.ComponentModel.DataAnnotations;

namespace B2B.UI.DtosUI.AccountDtos
{
    public class SignInDto
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        public string Password { get; set; }
        public bool memberMe { get; set; }
    }
}
