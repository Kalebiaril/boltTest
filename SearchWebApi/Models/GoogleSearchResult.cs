using System.Collections.Generic;

namespace SearchWebApi.Models
{
    public class GoogleSearchResult
    {
        public string Kind { get; set; }
        public string Title { get; set; }

        public IEnumerable<GoogleSearchResult> Items { get; set; }
    }
}
