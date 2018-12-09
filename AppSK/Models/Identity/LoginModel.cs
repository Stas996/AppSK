using System.ComponentModel.DataAnnotations;

namespace AppSK.Models.Identity
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Необходим E-Mail")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходим пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}