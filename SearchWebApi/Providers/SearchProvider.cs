using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using SearchWebApi.DB;
using SearchWebApi.Enums;
using SearchWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebApi.Providers
{
    public class SearchProvider : ISearchProvider
    {
        private readonly IBingSearchClient _bingSearchClient;
        private readonly IGoogleSearchClient _googleSearchClient;
        private readonly IMapper _mapper;
        private readonly SearchApiDbContext _dbContext;
        private readonly ILogger<SearchProvider> _logger;

        public SearchProvider(IBingSearchClient bingSearchClient, 
            IGoogleSearchClient googleSearchClient,
            IMapper mapper,
            SearchApiDbContext dbContext,
            ILogger<SearchProvider> logger)
        {
            _bingSearchClient = bingSearchClient;
            _googleSearchClient = googleSearchClient;
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<SearchDataModel>> SearchAsync(string seachPhrase)
        {
            var bingSearchTask = _bingSearchClient.SearchAsync(seachPhrase);
            var googleSearchTask = _googleSearchClient.SearchAsync(seachPhrase);
            var bingResult = await bingSearchTask;
            var googleResult = await googleSearchTask;
            var result = new List<SearchDataModel>();
            if (bingResult.Any())
            {
                result.AddRange(await AddData(seachPhrase, bingResult, SearchEngine.Bing));
            }
            if (googleResult.Any())
            {
                result.AddRange(await AddData(seachPhrase, googleResult, SearchEngine.Google));
            }
            _dbContext.SaveChanges();
            return result;
        }

        private async Task<IEnumerable<SearchDataModel>> AddData(string seachPhrase, IEnumerable<string> result, SearchEngine engine)
        {
            var searchData = result.Select(result => new SearchDataModel
            {
                SearchEngine = engine,
                Request = seachPhrase,
                Title = result,
                EnteredDate = DateTime.UtcNow
            });
            await _dbContext.SearchData.AddRangeAsync(_mapper.Map<IEnumerable<SearchData>>(searchData));
            return searchData.ToList();
        }
    }
}
