using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thirsty;
using Thirsty.Repositories;
using System.Linq;

namespace Thirsty.Tests
{
    [TestClass]
    public class GivenFilterParameters
    {
        [TestMethod]
        public void GivenFilterParameters_When_QueryConstraintsMethodInvoked_ShouldReturnQueryConstaintsWithCorrectState()
        {
            var filterParameters = new FilterParameters
            {
                AvailabilityId = 1
            };
            QueryConstraints constraints = filterParameters.GetQueryConstraints() as QueryConstraints;
            Assert.AreEqual(constraints.GetSortParameterString(), "ASC");
            Assert.AreEqual(constraints.SortPropertyName, "name");
            Assert.AreEqual(1, (int)constraints.FilterParameters.Single(p => p.Key == "availableId").Value);
        }
    }
}
