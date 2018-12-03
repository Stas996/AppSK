using AppSK.DAL.Entities;
using System.Linq;

namespace AppSK.BLL.Core
{
    public interface IProjectsService
    {
        IQueryable<Project> GetProjects();

        Project GetProject(int id);

        int Save(Project project);

        void Delete(int id);
    }
}
