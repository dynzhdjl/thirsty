using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thirsty.Repositories;
using RestSharp;
using System.Linq;

namespace Thirsty.Repositories.Tests
{
    [TestClass]
    public class GivenRestRequestExtensions
    {
        [TestMethod]
        public void GivenRestRequestExtensions_When_ConstraintsAppliedToRestRequest_ParameterListShouldBeCunstractedAsExpected()
        {
            var request = new RestRequest();
            var constraints = new QueryConstraints();
            constraints.Page(2).SortBy("name").Descending();
            request.ApplyConstraints(constraints);

            Assert.AreEqual(2, (int)request.Parameters.Single(p => p.Name == "p").Value);
            Assert.AreEqual(constraints.GetSortParameterString(), request.Parameters.Single(p => p.Name == "sort").Value);
            Assert.AreEqual(constraints.SortPropertyName, request.Parameters.Single(p => p.Name == "order").Value);
        }

        [TestMethod]
        public void GivenRestRequestExtensions_When_ConstraintAppliedToRestRequestIsNull_ParameterListShouldNotBeChanged()
        {
            var request = new RestRequest();
            request.ApplyConstraints(null);
        }
    }
}
