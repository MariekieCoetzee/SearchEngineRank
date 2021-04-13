using System.Collections.Generic;
using System.ComponentModel;

namespace SearchEngineRank.Models
{
    public class SearchRequest
    {
        [DisplayName("Keywords")]
        public string Keywords { get; set; } 

        [DisplayName("Search url")]
        public string SearchUrl { get; set; } 

        [DisplayName("Search engine")]
        public string SearchEngine { get; set; }

        public string ErrorMessage { get; set; }

        public List<SearchResult> MatchList = new List<SearchResult>();

        public SearchRequest()
        {

        }

    }

   

    

}
