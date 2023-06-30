namespace RangersOfShadowDeep.Models
{
    public class Ranger : IRanger
    {
        public int Armor { get; set; } = 0;
        public int ExperiencePoints { get; set; } = 0;
        public int Fight { get; set; } = 0;
        public int Health { get; set; } = 0;
        public int HealthMax { get; set; } = 0;
        public Guid Id { get; set; }
        public int Level { get; set; } = 0;
        public int Move { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Recruitment { get; set; } = 0;
        public int Shoot { get; set; } = 0;
        public int Will { get; set; } = 0;
    }
}