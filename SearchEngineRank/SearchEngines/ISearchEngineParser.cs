using System.Collections.Generic;
using SearchEngineRank.Models;

namespace SearchEngineRank.SearchEngines
{
    public interface ISearchEngineParser
    {
        /// <summary>
        /// Identify number of pages.  
        /// </summary>
        /// <param name="html">HTML content passed as a string.</param>
        /// <returns></returns>
        public Page parsePage(string html);

        /// <summary>
        /// Scraping search results on a page and populate model.
        /// </summary>
        /// <param name="html">HTML content passed in as a string.</param>
        /// <returns></returns>
        public List<SearchResult> parseResults(string html);

        /// <summary>
        /// Creating the url to call.  
        /// </summary>
        /// <param name="keywords">Keyword on search screen.</param>
        /// <param name="pageNr">The Page number to call.</param>
        /// <returns></returns>
       public string constructSearchURL(string keywords, int pageNr);
    
    }
}
