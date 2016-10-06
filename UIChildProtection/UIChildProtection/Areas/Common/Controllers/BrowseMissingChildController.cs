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
           
            var childinfo = objBs.GetALL().Where(x => x.IsApproved == "A");
            return View(childinfo);
        }
        public ActionResult Display(string SortOrder)
        {
            ViewBag.SortOrder = SortOrder;
            int abc = Convert.ToInt32(SortOrder);
            
            var childinfo = objBs.GetALL().Where(x => x.ChildId == abc);
            return View(childinfo);
        }



        public ActionResult DisplaySearch(string SortOrder)
        {
            //ViewBag.SortOrder = SortOrder;
            //int abc = Convert.ToInt32(SortOrder);

            var childinfo = objBs.GetALL().Where(x => x.imageUrl == SortOrder);
            return View(childinfo);
        }


        public ActionResult Delete(int id)
        {
            objBs.Delete(id);
            return View("Index");
        }
    }
}