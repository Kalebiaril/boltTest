using SearchWebApi.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchWebApi.Interfaces
{
    public interface ISearchProvider
    {
        /// <summary>
        /// Searches phrase in Google and Bing 
        /// </summary>
        /// <param name="seachPhrase"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchDataModel>> SearchAsync(string seachPhrase);
    }
}
