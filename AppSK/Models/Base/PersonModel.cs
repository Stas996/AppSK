using System;
using System.ComponentModel.DataAnnotations;

namespace AppSK.Models.Base
{
    public class PersonModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
    }
}