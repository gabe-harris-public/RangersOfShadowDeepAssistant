using RangersOfShadowDeep.Models;

namespace RangersOfShadowDeep.Repository
{
    public interface ISkillsRepository
    {
        ISkills Create(ISkills skillToSave);

        void Delete(ISkills skillToDelete);

        ISkills Read(Guid id);

        IEnumerable<ISkills> ReadAll();

        ISkills Update(Guid id, ISkills skillToUpdate);
    }
}