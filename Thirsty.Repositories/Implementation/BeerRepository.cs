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
            if(response.Data == null)
            {
                return PagedResult<Beer>.Empty;
            }
            return new PagedResult<Beer>(response.Data, response.CurrentPage, response.TotalResults);
        }

        public virtual async Task<PagedResult<Beer>> GetBeers(IQueryConstraints constraints = null)
        {
            var request = new RestRequest
            {
                Resource = "beers"
            };
            request.AddParameter("hasLabels", "Y");
            request.ApplyConstraints(constraints);
            var response = await Api.Execute<RootObject<Beer>>(request);
            if(response.Data == null)
            {
                return PagedResult<Beer>.Empty;
            }
            return new PagedResult<Beer>(response.Data, response.CurrentPage, response.NumberOfPages);
        }

        public virtual async Task<PagedResult<Beer>> GetByAvailabilityId(int availabilityId, IQueryConstraints constraints = null)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PagedResult<Beer>> GetByStyleId(int styleId, IQueryConstraints constraints = null)
        {
            throw new NotImplementedException();
        }
    }
}
