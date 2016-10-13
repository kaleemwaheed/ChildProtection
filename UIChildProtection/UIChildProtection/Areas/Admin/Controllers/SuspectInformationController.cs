using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class SuspectInformationController : Controller
    {
        private SuspectPersonInformationBs objBs;
        public SuspectInformationController()
        {
            objBs = new SuspectPersonInformationBs();
        }
        // GET: Admin/SuspectInformation
        public ActionResult Index()
        {
            var suspectInfo = objBs.GetALL();
            return View(suspectInfo);
            
        }
    }
}