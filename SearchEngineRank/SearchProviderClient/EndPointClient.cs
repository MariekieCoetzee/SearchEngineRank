using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SearchEngineRank.Models;

namespace SearchEngineRank.SearchProviderClient
{
    public class EndPointClient
    {
        public EndPointClient()
        {
        }


        public async Task<string> InvokeEndpoint(HttpClient client, string url)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                string response = await client.GetStringAsync(url);
                return response;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Search engine is not available. ", ex);
            }

        }

        public string extractBaseDomain(string searchUrl)
        {
            if (searchUrl == null) return "";
            try
            {

                List<string> splitUrl = searchUrl.Split('.').ToList();
                if (splitUrl == null) return "";

                if (splitUrl[0].Contains("www")) splitUrl.RemoveAt(0);

                bool removeAfterSlash = false;
                for (int i = 0; i < splitUrl.Count; i++)
                {
                    if (removeAfterSlash)
                    {
                        splitUrl.RemoveAt(i);
                    }
                    else
                    if (splitUrl[i].Contains("/"))
                    {
                        Regex rx = new Regex("(.*?)(?=/)");
                        splitUrl[i] = rx.Match(splitUrl[i]).Value;
                        removeAfterSlash = true;
                    }
                }

                return String.Join(".", splitUrl);
            }
            catch (Exception ex)
            {
                throw new BaseDomainNotFoundException("Error occured while extracting base domain name. ", ex);
            }

        }

    }
}
