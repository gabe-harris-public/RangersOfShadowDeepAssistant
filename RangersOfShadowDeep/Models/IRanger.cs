namespace RangersOfShadowDeep.Models
{
    public interface IRanger
    {
        int Armor { get; set; }
        int ExperiencePoints { get; set; }
        int Fight { get; set; }
        int Health { get; set; }
        int HealthMax { get; set; }
        Guid Id { get; set; }
        int Level { get; set; }
        int Move { get; set; }
        string Name { get; set; }
        int Recruitment { get; set; }
        int Shoot { get; set; }
        int Will { get; set; }
    }
}