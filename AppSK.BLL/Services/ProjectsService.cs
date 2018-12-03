using System.Linq;
using AppSK.BLL.Core;
using AppSK.DAL.Entities;
using AppSK.DAL.Repositories;

namespace AppSK.BLL.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IRepository<Project> _projectsRepository;

        public ProjectsService(IRepository<Project> projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public IQueryable<Project> GetProjects()
        {
            return _projectsRepository.GetAll();
        }

        public void Delete(int id)
        {
            _projectsRepository.Delete(id);
        }

        public Project GetProject(int id)
        {
            return _projectsRepository.GetById(id);
        }

        public int Save(Project project)
        {
            if (project.IsNew)
            {
                _projectsRepository.Create(project);
            }
            else
            {
                _projectsRepository.Update(project);
            }
            _projectsRepository.Save();
            return project.Id;
        }
    }
}
