using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Common.Controllers
{
    public class SubmitReportController : Controller
    {
        // GET: Common/SubmitReport
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(tbl_ChildInfo obj)
        {
            return View();
        }
    }
}