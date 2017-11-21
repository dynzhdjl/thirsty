using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Thirsty.Repositories
{

    public class ApiRepository
    {
        protected BreweryApi Api { get; private set; }
        public ApiRepository()
        {
            Api = new BreweryApi();
        }
    }
}
