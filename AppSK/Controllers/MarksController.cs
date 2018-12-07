using AppSK.BLL.Core;
using AppSK.DAL.Entities;
using AppSK.Models.Marks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace AppSK.Controllers
{
    [Authorize]
    public class MarksController : Controller
    {
        private readonly IMarksService _marksService;
        private readonly IExpertsService _expertsService;

        public MarksController(
            IExpertsService expertsService,
            IMarksService marksService)
        {
            _expertsService = expertsService;
            _marksService = marksService;
        }

        [HttpGet]
        public ActionResult ProjectDetails(int projectId)
        {
            var mark = _marksService.GetMarkByProject(projectId);
            var viewMark = Mapper.Map<MarkModel>(mark);
            return View(viewMark);
        }

        [HttpGet]
        public ActionResult StockDetails(int stockId)
        {
            var mark = _marksService.GetMarkByStock(stockId);
            var viewMark = Mapper.Map<MarkModel>(mark);
            return View(viewMark);
        }

        [HttpPost]
        public ActionResult Save(MarkModel markModel)
        {
            var mark = Mapper.Map<Mark>(markModel);
            var controllerRedirectName = markModel.ProjectId.HasValue ? "Projects" : "Stocks";
            if (mark.IsNew)
            {
                var expert = GetCurrentExpert();
                markModel.ExpertId = expert.Id;
            }

            var projects = _marksService.Save(mark);
            return RedirectToAction("Index", controllerRedirectName);
        }

        private Expert GetCurrentExpert()
        {
            var userId = User.Identity.GetUserId<string>();
            if (userId == null)
            {
                return null;
            }
            var expert = _expertsService.GetExpertByUserId(userId);
            return expert;
        }
    }
}