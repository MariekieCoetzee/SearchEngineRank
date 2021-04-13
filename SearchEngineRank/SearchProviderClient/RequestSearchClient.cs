using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SearchEngineRank.SearchEngines;
using SearchEngineRank.Models;

namespace SearchEngineRank.SearchProviderClient
{
   public class RequestSearchClient
    {
        public RequestSearchClient()
        {

        }
        public async Task<List<SearchResult>> Query(SearchRequest searchRequest)
        {

            try
            {
                SearchEngineParserFactory searchEngineParserFactory = new SearchEngineParserFactory();
                ISearchEngineParser engine = searchEngineParserFactory.getNewSearchEngineParser(searchRequest.SearchEngine, searchRequest.Keywords);

                string url = engine.constructSearchURL(searchRequest.Keywords, 1);

                EndPointClient endPointClient = new EndPointClient();
                HttpClient httpClient = new HttpClient();

                string response = await endPointClient.InvokeEndpoint(httpClient, url);
                Page pageResults = engine.parsePage(response);

                for (int i = 1; i <= pageResults.NumberOfPages;)
                {
                    if (pageResults.Results.Count < 50)
                    {
                        pageResults.Results.AddRange(engine.parseResults(response));

                        //next page
                        i++;
                        url = engine.constructSearchURL(searchRequest.Keywords, i);
                        response = await endPointClient.InvokeEndpoint(httpClient, url);
                    }
                    else break;
                }

                string baseDomain = endPointClient.extractBaseDomain(searchRequest.SearchUrl);
                List<SearchResult> searchResults = filterResults(pageResults, baseDomain);

                return searchResults;

            }
           
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private List<SearchResult> filterResults(Page pageResults, string baseDomain)
        {
            try
            {
                pageResults.Results.Select((x, index) => { x.Position = index + 1; return x; }).ToList();

                return pageResults.Results.Where(x => x.DomainName.Contains(baseDomain)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while filtering results. " + ex.Message);
            }

        }
    }
}