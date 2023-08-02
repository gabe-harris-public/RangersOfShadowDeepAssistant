using Moq;
using RangersOfShadowDeep.Repository;

namespace RangerTests
{
    public class Integrations
    {
        [Fact]
        public void TestDatabase()
        {
            var rangersRepository = new RangersOfShadowDeep.Repository.RangersRepository();

            var listOfRangers = rangersRepository.ReadAll();
            Assert.NotNull(listOfRangers);
        }
        [Fact]
        public void TestMoq()
        {
            var mock = new Mock<IRangersRepository>();
        }
    }
}