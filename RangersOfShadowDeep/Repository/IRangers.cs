﻿using RangersOfShadowDeep.Models;

namespace RangersOfShadowDeep.Repository
{
    public interface IRangers
    {
        IRanger Create(IRanger rangerToSave);

        void Delete(IRanger rangerToDelete);

        IRanger Read(Guid id);

        IEnumerable<IRanger> ReadAll();

        IRanger Update(Guid id, IRanger rangerToUpdate);
    }
}