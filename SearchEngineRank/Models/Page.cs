using System;
using System.Collections.Generic;

namespace SearchEngineRank.Models
{
    public class Page
    {

        public int NumberOfPages { get; set; }

        public List<SearchResult> Results { get; set; }
        public string ErrorMessage { get; set; }

        public Page()
        {
            Results = new List<SearchResult>();
        }

    }
}
