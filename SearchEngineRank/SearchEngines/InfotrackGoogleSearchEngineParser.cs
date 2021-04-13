using System;
using System.Net;
using SearchEngineRank.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SearchEngineRank.SearchProviderClient;

namespace SearchEngineRank.SearchEngines
{
    public class InfotrackGoogleSearchEngineParser : ISearchEngineParser
    {
        public InfotrackGoogleSearchEngineParser()
        {

        }

        public string constructSearchURL(string keywords, int pageNr)
        {
            try
            {
                string pg = pageNr.ToString("D2");
                return ($"https://infotrack-tests.infotrack.com.au/Google/Page{pg}.html");
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
                Regex rx = new Regex("(?<=class=\"r\">)(.*?)(?=<div class=\"s\">)", RegexOptions.IgnoreCase);
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
                throw new ParsePageContentException("Unable to parse Infotrack Google search results.", ex);
            }

        }
        public int extractPageCount(string htmlPage)
        {
            Regex rxPagesReturned = new Regex("(?<=<td>)(.*?)(?=</td>)");
            MatchCollection pagesMatch = rxPagesReturned.Matches(htmlPage);
            return pagesMatch.Count;
        }

        private string extractName(string htmlSection)
        {
            Regex nameRX = new Regex("(?<=class=\"LC20lb DKV0Md\">)(.*?)(?=<)");
            return WebUtility.HtmlDecode(nameRX.Match(htmlSection).Value);

        }
        private string extractDomain(string htmlSection)
        {
            Regex pageRX = new Regex("(?<=<cite class=\"iUh30 bc tjvcx\">)(.*?)(?=<)");
            EndPointClient endPointClient = new EndPointClient();
            return endPointClient.extractBaseDomain(pageRX.Match(htmlSection).Value);

        }

        private string extractURL(string htmlSection)
        {
            Regex pageRX = new Regex("(?<=href=\")(.*?)(?=\")");
            return pageRX.Match(htmlSection).Value;
        }
    }
}
