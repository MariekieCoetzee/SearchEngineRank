using System;
using System.Collections.Generic;
using SearchEngineRank.Models;

namespace SearchEngineRank.SearchEngines
{
    public class GoogleSearchEnginehtmlParser : ISearchEngineParser
    {
        public GoogleSearchEnginehtmlParser()
        {

        }
        public string constructSearchURL(string keywords, int pageNr)
        {
            try
            {
                if (pageNr == 1)
                {
                    return ($"https://www.google.com/search?q={keywords}&oq&csclient=gws-wiz");
                }
                else
                {
                    int pg = pageNr * 10;
                    return ($"https://www.google.com/search?q={keywords}&start={pg}&sa=N&biw=912&bih=756");
                }
            }
            catch (Exception ex)
            {
                throw new ConstructURLException("Error occurred while constructing url. ", ex);
            }

        }
        public Page parsePage(string html)
        {
            Page page = new Page();
            page.NumberOfPages = 5;

            return page;
        }

        public List<SearchResult> parseResults(string html)
        {
            try
            {
                List<SearchResult> results = new List<SearchResult>();


                return results;
            }
            catch (Exception ex)
            {
                throw new ParsePageContentException("Unable to parse Google search results.", ex);
            }

        }


    }
}
