using System;
using SearchEngineRank.SearchEngines;
using Xunit;

namespace TestSearchEngineRankWebApp
{
    public class SearchEngineParserTest
    {

        [Fact]
        public void constructInfoTrackGoogleUrlTest()
        {
            InfotrackGoogleSearchEngineParser infotrackGoogleSearchEngineParser = new InfotrackGoogleSearchEngineParser();
            string test = infotrackGoogleSearchEngineParser.constructSearchURL(null, 3);
            Assert.Equal("https://infotrack-tests.infotrack.com.au/Google/Page03.html", test);
        }

        [Fact]
        public void constructInfoTrackBingUrlTest()
        {
            InfotrackBingSearchEngineParser infotrackGoogleSearchEngineParser = new InfotrackBingSearchEngineParser();
            string test = infotrackGoogleSearchEngineParser.constructSearchURL(null, 3);
            Assert.Equal("https://infotrack-tests.infotrack.com.au/Bing/Page03.html", test);
        }

    }
}
