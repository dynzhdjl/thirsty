using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Thirsty.Repositories.Tests
{
    public class MockMenuRepository : IMenuRepository<MockEntity>
    {
        public async Task<IEnumerable<MockEntity>> GetMenu()
        {
            return await Task.FromResult(new List<MockEntity>());
        }
    }
    public class MockEntity {};

    [TestClass]
    public class GivenMenuRepository
    {
        [TestMethod]
        public async Task GivenMenuRepository_When_RequestingMenuFromGenericType_Than_ShouldReturnCorrectTypeOfList()
        {
            var repository = new MockMenuRepository();
            var list = await repository.GetMenu();
            Assert.AreEqual(list.GetType(), typeof(List<MockEntity>));
        }
    }
}
