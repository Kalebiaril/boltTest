using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SearchWebApi.Interfaces;
using SearchWebApi.Profiles;
using SearchWebApi.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Tests;
using Xunit;

namespace SearchWebApi.Tests
{
    public class SearchProviderTest : IClassFixture<DataBaseFixture>
    {
        private readonly ILogger<SearchProvider> _logger;
        private readonly IMapper _mapper;
        private readonly DataBaseFixture _fixture;
        private readonly Mock<IBingSearchClient> _bingSearchClient;
        private readonly Mock<IGoogleSearchClient> _googleSearchClient;

        public SearchProviderTest(DataBaseFixture fixture)
        {
            _fixture = fixture;
            var searchMapperProfile = new SearchMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(searchMapperProfile));
            _mapper = new Mapper(configuration);
            _logger = new Mock<ILogger<SearchProvider>>().Object;
            _bingSearchClient = new Mock<IBingSearchClient>();
            _googleSearchClient = new Mock<IGoogleSearchClient>();
        }

        [Fact]
        public async Task SearchProvider_ReturnsItems()
        {
            //Arrange
            var context = _fixture.SearchApiDbContext;
            _googleSearchClient.Setup(x => x.SearchAsync(It.IsAny<string>())).ReturnsAsync(new List<string>() { "G1", "G2", "G3", "G4", "G5", "G6" });
            _bingSearchClient.Setup(x => x.SearchAsync(It.IsAny<string>())).ReturnsAsync(new List<string>() { "B1", "B2", "B3", "B4", "B5", "B6" });

            var searchProvider = new SearchProvider(_bingSearchClient.Object, _googleSearchClient.Object, _mapper, context, _logger);

            //Act
            var result = await searchProvider.SearchAsync("cat");

            //Assert
            Assert.Equal(12 ,result.Count());
        }


        [Fact]
        public async Task SearchProvider_WritesResultToDb()
        {
            //Arrange
            var context = _fixture.SearchApiDbContext;
            _googleSearchClient.Setup(x => x.SearchAsync(It.IsAny<string>())).ReturnsAsync(new List<string>() { "G1", "G2", "G3", "G4", "G5", "G6" });
            _bingSearchClient.Setup(x => x.SearchAsync(It.IsAny<string>())).ReturnsAsync(new List<string>() { "B1", "B2", "B3", "B4", "B5", "B6" });

            var searchProvider = new SearchProvider(_bingSearchClient.Object, _googleSearchClient.Object, _mapper, context, _logger);

            //Act
            var result = await searchProvider.SearchAsync("cat");
           
            //Assert
            Assert.Equal(12, _fixture.SearchApiDbContext.SearchData.Count());
        }
    }
}
