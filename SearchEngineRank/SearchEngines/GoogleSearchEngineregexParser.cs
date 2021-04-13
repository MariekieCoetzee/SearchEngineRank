using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using SearchEngineRank.Models;
using SearchEngineRank.SearchProviderClient;

namespace SearchEngineRank.SearchEngines
{
    public class GoogleSearchEngineregexParser : ISearchEngineParser
    {
        public GoogleSearchEngineregexParser()
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
                Regex rx = new Regex("(?<=<div class=\"ZINbbc)(.*?)(?=</div><div class=\"ZINbbc)", RegexOptions.IgnoreCase);
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
                throw new ParsePageContentException("Unable to parse Google search results.", ex);
            }

        }

        private string extractName(string htmlSection)
        {
            Regex nameRX = new Regex("(?<=class=\"BNeawe vvjwJb AP7Wnd\">)(.*?)(?=<)");
            return WebUtility.HtmlDecode(nameRX.Match(htmlSection).Value);

        }
        private string extractDomain(string htmlSection)
        {
            Regex pageRX = new Regex("(?<=<div class=\"BNeawe UPmit AP7Wnd\">)(.*?)(?=<)");
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