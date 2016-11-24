using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Common.Controllers
{
   
    public class HomeController : Controller
    {
        // GET: Common/Home
        private ChildInfoBs objBs;
        public HomeController()
        {
            objBs = new ChildInfoBs();
        }
        public ActionResult Index()
        {
            var childinfo = objBs.GetALL().Where(x => x.IsApproved == "A").Reverse().Take(1);

            return View(childinfo);
        }
    }
}