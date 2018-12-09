using AppSK.DAL.Entities.Enums;
using AppSK.Models.Managers;
using AppSK.Models.Marks;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppSK.Models.Projects
{
    public class ProjectModel
    {
        public ProjectModel()
        {
            StartDate = DateTime.Now;
            FinishDate = DateTime.Now.AddMonths(1);
        }

        public int Id { get; set; }

        public int ManagerId { get; set; }

        public ManagerItemModel Manager { get; set; }

        [Display(Name = "Тип проекта")]
        public ProjectTypes Type { get; set; }

        [Required(ErrorMessage = "Необходимо название проекта")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Описание проекта")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Необходима дата старта")]
        [Display(Name = "Дата старта")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Необходима дата окончания")]
        [Display(Name = "Дата окончания")]
        public DateTime FinishDate { get; set; }

        [Required]
        [Display(Name = "Инвестиции (грн)")]
        public decimal Investments { get; set; }

        public MarkModel Mark { get; set; }
    }
}