using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Thirsty.Repositories
{
    public class BeerRepository : ApiRepository, IRepository<Beer, string>
    {
        public Beer GetById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PagedResult<Beer>> GetByGlasswareId(int glasswareId, IQueryConstraints constraints = null)
        {
            var request = new RestRequest
            {
                Resource = "beers"
            };
            var response = await Api.Execute<RootObject<Beer>>(request);
            return new PagedResult<Beer>(response.Data, response.CurrentPage, response.TotalResults);
        }

        public virtual async Task<PagedResult<Beer>> GetByAvailabilityId(int availabilityId, IQueryConstraints constraints = null)
        {
            return new PagedResult<Beer>(new List<Beer>(), currentPageIndex: 0, totalPageCount: 0);
        }

        public virtual async Task<PagedResult<Beer>> GetByStyleId(int styleId, IQueryConstraints constraints = null)
        {
            return new PagedResult<Beer>(new List<Beer>(), currentPageIndex: 0, totalPageCount: 0);
        }
    }
}
