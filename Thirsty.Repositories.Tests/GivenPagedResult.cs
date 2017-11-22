using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thirsty.Repositories.Tests
{
    [TestClass]
    public class GivenPagedResult
    {
        [TestMethod]
        public void GivenPagedResult_When_PageIndexIsZero_Than_ShouldThrowInvalidArgumentException()
        {
            var items = new List<MockEntity> {};
            var exception = Assert.ThrowsException<ArgumentException>(() => { new PagedResult<MockEntity>(items, currentPageIndex: 0, totalItemCount: 0); });
        }

        [TestMethod]
        public void GivenPagedResult_When_CurrentPageIndexGreaterThanPageCount_Than_ShouldThrowInvalidArgumentException()
        {
            var items = new List<MockEntity> { };
            var exception = Assert.ThrowsException<ArgumentException>(() => { new PagedResult<MockEntity>(items, currentPageIndex: 5, totalItemCount: 2); });
        }
    }
}
