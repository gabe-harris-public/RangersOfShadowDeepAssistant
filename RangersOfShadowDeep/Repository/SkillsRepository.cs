using LiteDB;
using RangersOfShadowDeep.Models;

namespace RangersOfShadowDeep.Repository
{
    public class SkillsRepository : ISkillsRepository
    {
        private LiteDatabase liteDb;

        public SkillsRepository()
        {
            liteDb = new LiteDbContext().Database;
        }

        public ISkills Create(ISkills skillToSave)
        {
            // Get a collection (or create, if doesn't exist)
            liteDb.GetCollection<ISkills>("skills").Insert(skillToSave);
            liteDb.Dispose();
            return skillToSave;
        }

        public void Delete(ISkills skillToDelete)
        {
            var col = liteDb.GetCollection<ISkills>("skills");
            try
            {
                var foundSkill = col.Query().Where(x => x.Id == skillToDelete.Id).First();
                col.Delete(foundSkill.Id);
                liteDb.Dispose();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        public ISkills Read(Guid id)
        {
            var foundSkill = liteDb.GetCollection<ISkills>("skills")
            .Query().Where(i => i.Id == id).Single();
            liteDb.Dispose();
            return foundSkill;
        }

        public IEnumerable<ISkills> ReadAll()
        {
            var col = liteDb.GetCollection<ISkills>("skills");
            var results = col.Query()
                .ToList();
            liteDb.Dispose();
            return results;
        }

        public ISkills Update(Guid id, ISkills skillToUpdate)
        {
            var col = liteDb.GetCollection<ISkills>("skills");
            ISkills foundSkill = col.Query().Where(r => r.Id == id).Single();
            foundSkill.Acrobatics = skillToUpdate.Acrobatics;
            foundSkill.AncientLore = skillToUpdate.AncientLore;
            foundSkill.Armoury = skillToUpdate.Armoury;
            foundSkill.Climb = skillToUpdate.Climb;
            foundSkill.Id = id;
            foundSkill.Leadership = skillToUpdate.Leadership;
            foundSkill.Navigation = skillToUpdate.Navigation;
            foundSkill.Perception = skillToUpdate.Perception;
            foundSkill.PickLock = skillToUpdate.PickLock;
            foundSkill.ReadRunes = skillToUpdate.ReadRunes;
            foundSkill.Stealth = skillToUpdate.Stealth;
            foundSkill.Strength = skillToUpdate.Strength;
            foundSkill.Survival = skillToUpdate.Survival;
            foundSkill.Swim = skillToUpdate.Swim;
            foundSkill.Traps = skillToUpdate.Traps;
            col.Update(foundSkill);
            liteDb.Dispose();
            return skillToUpdate;
        }
    }
}