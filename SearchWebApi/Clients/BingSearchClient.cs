using Microsoft.Extensions.Configuration;
using SearchWebApi.Interfaces;
namespace SearchWebApi.Clients
{
    public class BingSearchClient : BaseSearchClient, IBingSearchClient
    {
        public override string SearchEngine => "BingSearch";
        public BingSearchClient(IConfiguration config) : base(config)
        {

        }
    }
}
