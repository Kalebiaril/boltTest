using Microsoft.Extensions.Configuration;
using SearchWebApi.Interfaces;

namespace SearchWebApi.Clients
{
    public class GoogleSearchClient : BaseSearchClient, IGoogleSearchClient
    {
        public override string SearchEngine => "GoogleSearch";
        public GoogleSearchClient(IConfiguration config) : base(config)
        {

        }
    }
}
