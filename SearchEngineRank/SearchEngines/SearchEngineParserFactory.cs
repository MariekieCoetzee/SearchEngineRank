using SearchEngineRank.Models;

namespace SearchEngineRank.SearchEngines
{
    public class SearchEngineParserFactory
    {
        public SearchEngineParserFactory()
        {

        }

        /// <summary>
        /// Search Engines is verified and a search engine parser is returned.
        /// Expansions is possible by adding Search Engine Parser and extending Factory.
        /// </summary>
        /// <param name="searchEngine">Return search engine parser based on value</param>
        /// <param name="keywords">Keywords is checked to verify if InfoTrack static pages should be returned</param>
        /// <returns></returns>
        public ISearchEngineParser getNewSearchEngineParser(string searchEngine, string keywords)
        {
            // If keyword is null or 'online title search' return InfoTrack Google/Bing static pages 
            if (searchEngine.ToLower() == "google")
            {
                //if (keywords == null || keywords.ToLower() == "online title search")
                //    return new InfotrackGoogleSearchEngineParser();
                //else
                return new GoogleSearchEngineParser();
            }
            if (searchEngine.ToLower() == "bing")
            {
                if (keywords == null || keywords.ToLower() == "online title search")
                    return new InfotrackBingSearchEngineParser();
                else
                    return new BingSearchEngineParser();
            }
            throw new SearchEngineNotFoundException("Search engine not found. ");
        }
    }
}