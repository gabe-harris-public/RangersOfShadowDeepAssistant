using RangersOfShadowDeep.Models;

namespace RangersOfShadowDeepAssistant.Models.Dto
{
    public class RangerDetailViewModel
    {
        public RangerDetailViewModel(Ranger ranger, Skills skills)
        {
            Ranger = ranger;
            Skills = skills;
        }
        public Ranger Ranger { get; }
        public Skills Skills { get; } 
        public string? ShareUrl { get; set; }
    }
}
