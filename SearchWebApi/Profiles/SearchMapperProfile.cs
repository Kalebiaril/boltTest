using SearchWebApi.DB;

namespace SearchWebApi.Profiles
{
    public class SearchMapperProfile : AutoMapper.Profile
    {
        public SearchMapperProfile()
        {
            CreateMap<SearchDataModel, SearchData>();

        }
    }
}
