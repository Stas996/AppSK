using AppSK.BLL.Core;
using AppSK.DAL.Entities;
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

        public ProjectsController(IProjectsService projectsService,
            IManagersService managersService)
        {
            _projectsService = projectsService;
            _managersService = managersService;
        }

        public ActionResult Index()
        {
            var projects = _projectsService.GetProjects().ToList();
            var viewProjects = Mapper.Map<List<ProjectViewModel>>(projects);
            return View(viewProjects);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectCreateModel projectModel)
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