namespace RangersOfShadowDeep.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> ReadAll();
        IQueryable<TEntity> Query { get; }
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
