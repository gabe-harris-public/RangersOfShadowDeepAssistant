using Microsoft.AspNetCore.Mvc;
using RangersOfShadowDeep.Models;
using RangersOfShadowDeep.Repository;
using RangersOfShadowDeepAssistant.Extensions;
using RangersOfShadowDeepAssistant.Models.Dto;

namespace RangersOfShadowDeepAssistant.Controllers
{
    public class RangerController : Controller
    {
        private readonly IRangersRepository repositoryRangers;

        public RangerController(IRangersRepository rangers)
        {
            repositoryRangers = rangers;
        }

        public ActionResult Create() => View();
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Ranger ranger)
        {
            repositoryRangers.Create(ranger);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            var foundRanger = repositoryRangers.Read(id);
            return View(foundRanger);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            repositoryRangers.Delete(repositoryRangers.Read(id));

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(Guid id)
        {
            var ranger = repositoryRangers.Read(id);
            RangerDetailViewModel rangerDetailViewModel = new RangerDetailViewModel((Ranger)ranger);
            rangerDetailViewModel.ShareUrl = Url.Content($"{HttpContext.Request.BaseUrl()}Ranger/Details/{id}");

            return View(rangerDetailViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var rangertoEdit = repositoryRangers.Read(id);
            return View(rangertoEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, [FromForm] Ranger updatedRanger)
        {
            repositoryRangers.Update(id, updatedRanger);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            var rangers = repositoryRangers.ReadAll();
            return View(rangers);
        }
    }
}