using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangersOfShadowDeep.Models
{
    public interface ISkills
    {
        Guid Id { get; set; }
        int Acrobatics { get; set; }
        int AncientLore { get; set; }
        int Armoury { get; set; }
        int Climb { get; set; }
        int Leadership { get; set; }
        int Navigation { get; set; }
        int Perception { get; set; }
        int PickLock { get; set; }
        int ReadRunes { get; set; }
        int Stealth { get; set; }
        int Strength { get; set; }
        int Survival { get; set; }
        int Swim { get; set; }
        int Traps { get; set; }
    }
}
