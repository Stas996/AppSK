using System;
using System.ComponentModel.DataAnnotations;

namespace AppSK.Models.Base
{
    public class PersonModel
    {
        [Required(ErrorMessage = "Необходимо имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Необходима фамилия")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Необходима дата рождения")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Некорректный формат даты")]
        public DateTime DateOfBirth { get; set; }
    }
}