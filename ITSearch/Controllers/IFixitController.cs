using ITSearch.Models;
using ITSearch.Models.IFixit;
using ITSearch.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ITSearch.Controllers
{
    public class IFixitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CallApi(iFixitViewModel searchItem)
        {
            IFixitApi ifa = new IFixitApi();

            string search = HttpUtility.UrlEncode(searchItem.NewSearch.SearchText);
            IFixitSearchResult data = ifa.MakeCall("search/" + search + "?pretty");

            iFixitViewModel ifvm = new iFixitViewModel();
            ifvm.IFixitSearchResult = data;

            return View("Index", ifvm);
        }


        [HttpGet]
        public IActionResult ViewGuide([FromQuery]int guideId)
        {
            IFixitApi ifa = new IFixitApi();

            string newSearch = HttpUtility.UrlEncode(guideId.ToString());
            IFixitGuide data = ifa.MakeGuideCall("guides/" + guideId + "?pretty");

            GuideViewModel ifvm = new GuideViewModel();
            ifvm.Guide = data;

            return View("ViewGuide", ifvm);
        }

        [HttpGet]
        public IActionResult ViewWiki([FromQuery] string wikiTitle)
        {
            IFixitApi ifa = new IFixitApi();

            //string ns = HttpUtility.UrlEncode(wikiNamespace);
            string title = HttpUtility.UrlEncode(wikiTitle);
            IFixitWiki data = ifa.MakeWikiCall("wikis/CATEGORY/" + title + "?pretty");

            WikiViewModel ifvm = new WikiViewModel();
            ifvm.IFixitWiki = data;

            return View("ViewWiki", ifvm);
        }
    }
}
