using RangersOfShadowDeep.Models;

namespace RangersOfShadowDeepAssistant.Models.Dto
{
    public class RangerCreateViewModel
    {
        public RangerCreateViewModel()
        {
            Ranger = new Ranger();
            Skills = new Skills();
        }
        public Ranger Ranger { get; set; }
        public Skills Skills { get; set; }
    }
}
