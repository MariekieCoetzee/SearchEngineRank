using System;
using Xunit;
using SearchEngineRank.SearchEngines;

namespace TestSearchEngineRankWebApp
{
    public class FactoryUnitTest
    {
        [Fact]
        public void IsInfoTrackGoogleEngine()
        {
            SearchEngineParserFactory searchEngineParserFactory = new SearchEngineParserFactory();
            ISearchEngineParser engine = searchEngineParserFactory.getNewSearchEngineParser("GOOGLE", null);
            Assert.IsType<InfotrackGoogleSearchEngineParser>(engine);
        }

        [Fact]
        public void IsInfoTrackBingEngine()
        {
            SearchEngineParserFactory searchEngineParserFactory = new SearchEngineParserFactory();
            ISearchEngineParser engine = searchEngineParserFactory.getNewSearchEngineParser("Bing", null);
            Assert.IsType<InfotrackBingSearchEngineParser>(engine);
        }

        
    }
}
