using LiteDB;
using RangersOfShadowDeep.Models;

namespace RangersOfShadowDeep.Repository
{
    public class RangersRepository : IRangersRepository
    {
        private LiteDatabase liteDb;

        public RangersRepository()
        {
            liteDb = new LiteDbContext().Database;
        }

        public IRanger Create(IRanger rangerToSave)
        {
            // Get a collection (or create, if doesn't exist)
            liteDb.GetCollection<IRanger>("rangers").Insert(rangerToSave);
            liteDb.Dispose();
            return rangerToSave;
        }

        public void Delete(IRanger rangerToDelete)
        {
            var col = liteDb.GetCollection<IRanger>("rangers");
            try
            {
                var foundRanger = col.Query().Where(x => x.Id == rangerToDelete.Id).First();
                col.Delete(foundRanger.Id);
                liteDb.Dispose();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        public IRanger Read(Guid id)
        {
            var foundRanger = liteDb.GetCollection<IRanger>("rangers")
            .Query().Where(i => i.Id == id).Single();
            liteDb.Dispose();
            return foundRanger;
        }


        public IEnumerable<IRanger> ReadAll()
        {
            var col = liteDb.GetCollection<IRanger>("rangers");
            var results = col.Query()
                .OrderBy(x => x.Name)
                .ToList();
            liteDb.Dispose();
            return results;
        }

        public IRanger Update(Guid id, IRanger rangerToUpdate)
        {
            var col = liteDb.GetCollection<IRanger>("rangers");
            IRanger foundRanger = col.Query().Where(r => r.Id == id).Single();
            foundRanger.Armor = rangerToUpdate.Armor;
            foundRanger.ExperiencePoints = rangerToUpdate.ExperiencePoints;
            foundRanger.Fight = rangerToUpdate.Fight;
            foundRanger.Health = rangerToUpdate.Health;
            foundRanger.HealthMax = rangerToUpdate.HealthMax;
            foundRanger.Id = id;
            foundRanger.Level = rangerToUpdate.Level;
            foundRanger.Move = rangerToUpdate.Move;
            foundRanger.Name = rangerToUpdate.Name;
            foundRanger.Recruitment = rangerToUpdate.Recruitment;
            foundRanger.Shoot = rangerToUpdate.Shoot;
            foundRanger.Will = rangerToUpdate.Will;
            col.Update(foundRanger);
            liteDb.Dispose();
            return rangerToUpdate;
        }
    }
}