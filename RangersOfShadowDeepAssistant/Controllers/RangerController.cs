using Microsoft.AspNetCore.Mvc;
using RangersOfShadowDeep.Models;
using RangersOfShadowDeep.Repository;
using RangersOfShadowDeepAssistant.Extensions;
using RangersOfShadowDeepAssistant.Models.Dto;

namespace RangersOfShadowDeepAssistant.Controllers
{
    public class RangerController : Controller
    {
        private readonly IRangersRepository rangersRepository;
        private readonly ISkillsRepository skillsRepository;

        public RangerController(IRangersRepository rangers, ISkillsRepository skills)
        {
            rangersRepository = rangers;
            skillsRepository = skills;
        }

        public ActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] RangerCreateViewModel rangerCreateViewModel)
        {
            var createdRanger = rangersRepository.Create(rangerCreateViewModel.Ranger);

            Skills newSkills = rangerCreateViewModel.Skills;
            newSkills.RangerId = createdRanger.Id;
            skillsRepository.Create(newSkills);

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
            var foundRanger = rangersRepository.Read(id);
            return View(foundRanger);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            rangersRepository.Delete(rangersRepository.Read(id));

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
            var ranger = rangersRepository.Read(id);
            var skills = skillsRepository.Read(ranger.Id);

            RangerDetailViewModel rangerDetailViewModel = new RangerDetailViewModel((Ranger)ranger, (Skills)skills);
            rangerDetailViewModel.ShareUrl = Url.Content($"{HttpContext.Request.BaseUrl()}Ranger/Details/{id}");

            return View(rangerDetailViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var rangertoEdit = rangersRepository.Read(id);
            return View(rangertoEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, [FromForm] Ranger updatedRanger)
        {
            rangersRepository.Update(id, updatedRanger);

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
            var rangers = rangersRepository.ReadAll();
            return View(rangers);
        }
    }
}