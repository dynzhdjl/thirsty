using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirsty.Repositories
{
    public class BreweryApi
    {
        private const string baseUrl = "http://api.brewerydb.com/v2/";
        private const string apiKey= "c0813936ad4aca3a17126145c60abac4";

        public async Task<T> Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new System.Uri(baseUrl);
            request.AddQueryParameter("key", apiKey);
            request.AddHeader("HTTP_ACCEPT", "application/json");
            var response = await client.ExecuteTaskAsync<T>(request);
            if (response.ErrorException != null)
            {
                var message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }
            return response.Data;
        }
    }
}
