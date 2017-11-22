using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Thirsty.Repositories.Tests
{
    [TestClass]
    public class GivenQueryConstraints
    {
        [TestMethod]
        public void GivenQueryConstraint_When_OnlySortByMethodInvoked_Then_SortOrderShouldBeAscending()
        {
            var queryConstraints = new QueryConstraints();
            queryConstraints.Page(1).SortBy("name");
            Assert.AreEqual(queryConstraints.SortOrder, SortOrder.Ascending);
        }

        [TestMethod]
        public void GivenQueryConstraint_When_OnlySortByDescendingMethodInvoked_Then_SortOrderShouldBeDescending()
        {
            var queryConstraints = new QueryConstraints();
            queryConstraints.Page(1).SortByDescending("name");
            Assert.AreEqual(queryConstraints.SortOrder, SortOrder.Descending);
        }

        [TestMethod]
        public void GivenQueryConstraint_When_SortPropertyNameMethodInvoked_Then_SortPropertyNameAreSetCorrectly()
        {
            var queryConstraints = new QueryConstraints();
            queryConstraints.Page(1).SortBy("name");
            Assert.AreEqual(queryConstraints.SortPropertyName, "name");
        }

        [TestMethod]
        public void GivenQueryConstraint_When_SortByAndSortByDescMethodsUsedTogahter_Then_SortORderShouldBeDescinding()
        {
            var queryConstraints = new QueryConstraints();
            queryConstraints.Page(1).SortBy("name").Descending();
            Assert.AreEqual(queryConstraints.SortPropertyName, "name");
            Assert.AreEqual(queryConstraints.SortOrder, SortOrder.Descending);
        }
    }
}
