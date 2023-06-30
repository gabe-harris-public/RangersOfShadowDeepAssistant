using LiteDB;

namespace RangersOfShadowDeep
{
    public class LiteDbContext : ILiteDbContext
    {
        private string liteDbPath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8))}\\RangersLiteDb.db";

        public LiteDatabase Database { get; }
        public LiteDbContext()
        {
            Database = new LiteDatabase(liteDbPath);
        }
    }

}
