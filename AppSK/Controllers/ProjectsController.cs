using AppSK.BLL.Core;
using AppSK.DAL.Entities;
using AppSK.Models.Marks;
using AppSK.Models.Projects;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AppSK.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IProjectsService _projectsService;
        private readonly IManagersService _managersService;
        private readonly IMarksService _marksService;

        public ProjectsController(
            IProjectsService projectsService,
            IMarksService marksService,
            IManagersService managersService)
        {
            _marksService = marksService;
            _projectsService = projectsService;
            _managersService = managersService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var projects = _projectsService.GetProjects().ToList();
            var viewProjects = Mapper.Map<List<ProjectModel>>(projects);
            return View(viewProjects);
        }

        [HttpGet]
        public ActionResult Details(int projectId)
        {
            var project = _projectsService.GetProject(projectId);
            var viewProject = Mapper.Map<ProjectModel>(project);
            viewProject.Mark = Mapper.Map<MarkModel>(_marksService.GetMarkByProject(projectId));
            return View(viewProject);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int projectId)
        {
            var project = _projectsService.GetProject(projectId);
            var viewProject = Mapper.Map<ProjectModel>(project);
            return View(viewProject);
        }

        [HttpGet]
        public ActionResult Delete(int projectId)
        {
            _projectsService.Delete(projectId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(ProjectModel projectModel)
        {
            var project = Mapper.Map<Project>(projectModel);
            var projects = _projectsService.Save(project);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(ProjectModel projectModel)
        {
            var manager = GetCurrentManager();
            projectModel.ManagerId = manager.Id;

            var project = Mapper.Map<Project>(projectModel);
            var projects = _projectsService.Save(project);
            return RedirectToAction("Index");
        }

        private Manager GetCurrentManager()
        {
            var userId = User.Identity.GetUserId<string>();
            if (userId == null)
            {
                return null;
            }
            var manager = _managersService.GetManagerByUserId(userId);
            return manager;
        }
    }
}