using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using SearchEngineRank.Models;
using SearchEngineRank.SearchProviderClient;

namespace SearchEngineRank.SearchEngines
{
    public class InfotrackBingSearchEngineParser : ISearchEngineParser
    {
        public InfotrackBingSearchEngineParser()
        {
        }

        public string constructSearchURL(string keywords, int pageNr)
        {
            try
            {
                    string pg = pageNr.ToString("D2");
                    return ($"https://infotrack-tests.infotrack.com.au/Bing/Page{pg}.html");
   
            }
            catch (Exception ex)
            {
                throw new ConstructURLException("Error occurred while constructing url. ", ex);
            }

        }


        public Page parsePage(string html)
        {
            Page page = new Page();
            page.NumberOfPages = extractPageCount(html);
            return page;

        }

        public List<SearchResult> parseResults(string html)
        {
            try
            {
                List<SearchResult> results = new List<SearchResult>();
                Regex rx = new Regex("(?<=<li class=\"b_algo\">)(.*?)(?=</li>)", RegexOptions.IgnoreCase);
                MatchCollection matches = rx.Matches(html);
                foreach (Match match in matches)
                {
                    SearchResult result = new SearchResult();
                    result.DomainName = extractDomain(match.Value);
                    result.Url = extractURL(match.Value);
                    result.Name = extractName(match.Value);
                    results.Add(result);
                }
                return results;
            }
            catch (Exception ex)
            {
                throw new ParsePageContentException("Unable to parse Infotrack Bing search results.", ex);
            }
        }

        private int extractPageCount(string htmlPage)
        {
            Regex rxPagesReturned = new Regex("(?<=b_widePag sb_bp\")");
            MatchCollection pagesMatch = rxPagesReturned.Matches(htmlPage);
            return pagesMatch.Count;
        }
        private string extractDomain(string htmlSection)
        {
            Regex pageRX = new Regex("(?<=<cite>)(.*?)(?=<)");
            EndPointClient endPointClient = new EndPointClient();
            return endPointClient.extractBaseDomain(pageRX.Match(htmlSection).Value);

        }

        private string extractName(string htmlSection)
        {
            Regex nameRX = new Regex("(?<=\">)(.*?)(?=</a>)");
            return WebUtility.HtmlDecode(nameRX.Match(htmlSection).Value);

        }

        private string extractURL(string htmlSection) { 
            Regex pageRX = new Regex("(?<=<a href=\")(.*?)(?=\" h=)");
            return pageRX.Match(htmlSection).Value;
        }
    }
}
