using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Common.Controllers
{
    public class ViewMissingReportController : Controller
    {
        // GET: Common/ViewMissingReport
        private ChildInfoBs objBs;
        public ViewMissingReportController()
        {
            objBs = new ChildInfoBs();
        }

        public ActionResult Index()
        {
            var childinfo = objBs.GetALL().Where(x => x.IsApproved == "A");
            return View(childinfo);
        }
    }
}