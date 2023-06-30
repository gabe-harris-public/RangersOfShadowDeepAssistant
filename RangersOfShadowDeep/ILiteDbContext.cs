using LiteDB;

namespace RangersOfShadowDeep
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}