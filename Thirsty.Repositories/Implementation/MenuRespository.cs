using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thirsty.Repositories
{
    public class StyleMenuRepository : ApiRepository, IMenuRepository<Style>
    {
        public async Task<IEnumerable<Style>> GetMenu()
        {
            var request = new RestRequest
            {
                Resource = "menu/styles"
            };
            var response = await Api.Execute<RootObject<Style>>(request);
            return response.Data;
        }
    }

    public class GlasswareMenuRespository : ApiRepository, IMenuRepository<Glass>
    {
        public async Task<IEnumerable<Glass>> GetMenu()
        {
            var request = new RestRequest
            {
                Resource = "/menu/glassware"
            };
            var response = await Api.Execute<RootObject<Glass>>(request);
            return response.Data;
        }
    }

    public class AvailibilityMenuRespository : ApiRepository, IMenuRepository<Available>
    {
        public async Task<IEnumerable<Available>> GetMenu()
        {
            var request = new RestRequest
            {
                Resource = "/menu/beer-availability"
            };
            var response = await Api.Execute<RootObject<Available>>(request);
            return response.Data;
        }
    }
}
