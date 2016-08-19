using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Common.Controllers
{
    public class BrowseMissingChildController : Controller
    {
        // GET: Common/BrowseMissingChild
        private ChildInfoBs objBs;
        public BrowseMissingChildController()
        {
            objBs = new ChildInfoBs();
        }
        public ActionResult Index()
        {
            var childinfo = objBs.GetALL();
            return View(childinfo);
        }
    }
}