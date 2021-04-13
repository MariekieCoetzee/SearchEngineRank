using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using SearchEngineRank.SearchProviderClient;
using Xunit;

namespace TestSearchEngineRankWebApp
{


    public class EndPointClientTest
    {
        [Fact]
        public void extractedBaseDomainTest()
        {
            string[] urlitems =
            {
                "https://www.test.com.au/pages.aspx",
                "https://www.test.com.au/pages",
                "https://www.test.com/pages",
                "https://www.test.com",
                "www.test.com.au/pages",
                "www.test.com.au",
                "www.test.com/pages",
                "www.test.com",
                "test.com.au",
                "test.com.au/pages",
                "test.com/pages",
                "test.com",
            };
            string[] expected =
            {
                "test.com.au",
                "test.com.au",
                "test.com",
                "test.com",
                "test.com.au",
                "test.com.au",
                "test.com",
                "test.com",
                "test.com.au",
                "test.com.au",
                "test.com",
                "test.com",
            };
            List<string> expectedURL = new List<string>(expected);
            List<string> extractedTest = new List<string>();
            foreach (string url in urlitems)
            {
                EndPointClient endPointClient = new EndPointClient();
                string extractUrl = endPointClient.extractBaseDomain(url);
                extractedTest.Add(extractUrl);
            }
            Assert.Equal<string>(expectedURL, extractedTest);
        }

        [Fact]
        public void IsEnvokedEndpoint()
        {
             //ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("[{'id':1,'value':'1'}]"),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object);

            string testResponse = httpClient.GetStringAsync("https://infotrack-tests.infotrack.com.au/Google/Page01.html").ToString();

            Assert.StartsWith(htmlResponse, testResponse);

        }
        const string htmlResponse = "<!doctype html><html itemscope=\"\" itemtype=\"http://schema.org/SearchResultsPage\" lang=\"en-AU\"><head><meta content=\"/images/branding/googleg/1x/googleg_standard_color_128dp.png\" itemprop=\"image\"><meta content=\"origin\" name=\"referrer\"><title>online title search - Google Search</title><script nonce=\"0AA1t3MHBRqsXr68z54CSw==\">(function(){window.google={kEI:'vcYsX9rHNtHLrQGUyaygBA',kEXPI:'31',kBL:'aOZb'};google.sn='web';google.kHL='en-AU';})();(function(){google.lc=[];google.li=0;google.getEI=function(a){for(var c;a&&(!a.getAttribute||!(c=a.getAttribute(\"eid\")));)a=a.parentNode;return c||google.kEI};google.getLEI=function(a){for(var c=null;a&&(!a.getAttribute||!(c=a.getAttribute(\"leid\")));)a=a.parentNode;return c};google.ml=function(){return null};google.time=function(){return Date.now()};google.log=function(a,c,b,d,g){if(b=google.logUrl(a,c,b,d,g)){a=new Image;var e=google.lc,f=google.li;e[f]=a;a.onerror=a.onload=a.onabort=function(){delete e[f]};google.vel&&google.vel.lu&&google.vel.lu(b);a.src=b;google.li=f+1}};google.logUrl=function(a,c,b,d,g){var e=\"\",f=google.ls";

    }
}
