using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchEngineRank.Models;

namespace SearchEngineRank.Controllers
{
    public class HomeController : Controller
    {
        private static readonly SearchRequest _request;

        static HomeController()
        {
            _request = new SearchRequest();
            _request.Keywords = "online title search";
            _request.SearchUrl= "www.infotrack.com.au";
            _request.SearchEngine = "Google";
        }


        public ActionResult Index()
        {
            return View();
        }

        [Route("query")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Query()
        {
            return Json(_request);
        }
        
        [Route("search")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<JsonResult> Search(SearchRequest searchRequest)
        {
            try
            {

                var requestSearchClient = new SearchProviderClient.RequestSearchClient();
                List<SearchResult> searchResults = await requestSearchClient.Query(searchRequest);
                return Json(searchResults);
            }
            catch (Exception ex)
            {
                searchRequest.ErrorMessage = ex.Message;
                return Json(searchRequest);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var error = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(error);
        }
    }
}
