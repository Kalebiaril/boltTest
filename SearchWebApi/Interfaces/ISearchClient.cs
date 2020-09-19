using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchWebApi.Interfaces
{
    public interface ISearchClient
    {
        Task<IEnumerable<string>> SearchAsync(string searchString);
    }
}
