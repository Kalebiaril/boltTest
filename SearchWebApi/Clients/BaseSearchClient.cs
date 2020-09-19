using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SearchWebApi.Interfaces;
using SearchWebApi.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SearchWebApi.Clients
{
    public abstract class BaseSearchClient : ISearchClient
    {
        public virtual string SearchEngine => string.Empty;
        private readonly IConfiguration _config;

        public BaseSearchClient(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<string>> SearchAsync(string searchPhraze)
        {
            var encoded = HttpUtility.UrlEncode(searchPhraze);
            string url = GetUrl(encoded);
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    return ParseHtmlRespone(apiResponse);
                }
            }
        }

        private IEnumerable<string> ParseHtmlRespone(string apiResponse)
        {
            var pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(apiResponse);

            if (pageDocument == null)
            {
                return Enumerable.Empty<string>();
            }
            var xPath = _config.GetValue<string>($"{SearchEngine}:Xpath");
            var searhItems = pageDocument.DocumentNode.SelectNodes(xPath).ToList();

            if (searhItems.Any())
            {
                return searhItems.Take(5).Select(item => HttpUtility.UrlDecode(item.InnerHtml)).ToList();
            }

            return Enumerable.Empty<string>();
        }

        private string GetUrl(string encoded)
        {
            var url = _config.GetValue<string>(
                $"{SearchEngine}:Url");
            var searchParams = _config.GetValue<string>(
               $"SearchEngine:Params");
            return $"{url}{encoded}{searchParams}";
        }
    }
}
