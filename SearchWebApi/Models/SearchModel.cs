using System.ComponentModel.DataAnnotations;

namespace SearchWebApi.Models
{
    public class SearchModel
    {
        [Required]
        [StringLength(2000, ErrorMessage = "Search phrase is not valid", MinimumLength = 2)]
        public string SearchPhrase { get; set; }
    }
}
