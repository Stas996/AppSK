using AppSK.DAL.Entities.Enums;
using AppSK.Models.Managers;
using System;

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

        public ProjectTypes Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public int Investments { get; set; }

    }
}