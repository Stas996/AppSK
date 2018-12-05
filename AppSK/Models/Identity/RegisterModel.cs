using AppSK.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace AppSK.Models.Identity
{
    public class RegisterModel : PersonModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Роль")]
        public string RoleName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Минимальная длина - 6 символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не сопвадают.")]
        public string ConfirmPassword { get; set; }
    }
}