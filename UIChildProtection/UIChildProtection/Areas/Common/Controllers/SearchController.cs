using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Common.Controllers
{
    public class SearchController : Controller
    {
        // GET: Common/Search
        private ChildInfoBs obj;
        public SearchController()
        {
            obj = new ChildInfoBs();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Find(tbl_ChildInfo info) { 

            
            var find = obj.GetALL().ToList().Where(x => x.Age == info.Age | x.ChildAlternativeName == info.ChildAlternativeName);
            return View("index");
        }
    }
}