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

        public IActionResult CallApi()
        {
            IFixitApi ifa = new IFixitApi();

            //ifa.CreateToken();
            string search = HttpUtility.UrlEncode("MacBook Pro 15");
            string newSearch = HttpUtility.UrlEncode("4000");
            IFixitSearchResult data = ifa.MakeCall("search/" + search + "?pretty");

            iFixitViewModel ifvm = new iFixitViewModel();
            ifvm.IFixitSearchResult = data;

            return View("Index", ifvm);
        }


        [HttpGet]
        public IActionResult ViewGuide([FromQuery]int guideId)
        {
            IFixitApi ifa = new IFixitApi();

            //ifa.CreateToken();
            string search = HttpUtility.UrlEncode("MacBook Pro 15");
            string newSearch = HttpUtility.UrlEncode(guideId.ToString());
            IFixitGuide data = ifa.MakeGuideCall("guides/" + guideId + "?pretty");

            GuideViewModel ifvm = new GuideViewModel();
            ifvm.Guide = data;

            return View("ViewGuide", ifvm);
        }
    }
}
