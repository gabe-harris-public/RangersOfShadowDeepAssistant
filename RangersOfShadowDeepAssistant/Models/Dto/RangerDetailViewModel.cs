using RangersOfShadowDeep.Models;

namespace RangersOfShadowDeepAssistant.Models.Dto
{
    public class RangerDetailViewModel
    {
        public RangerDetailViewModel(Ranger ranger)
        {
            Ranger = ranger;
        }
        public Ranger Ranger { get; }
        public string? ShareUrl { get; set; }
    }
}
