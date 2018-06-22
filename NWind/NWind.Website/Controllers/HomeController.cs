using NWind.ProxyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWind.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var proxy = new Proxy();
            var products =  proxy.FilterProductsByCategoryID(3);
            return View(products);
        }
    }
}