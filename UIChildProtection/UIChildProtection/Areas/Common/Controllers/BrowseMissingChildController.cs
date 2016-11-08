using BLL;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Index( String Page)
        {

            //string[] filePaths = Directory.GetFiles(@"C:\Users\Your\Documents\Visual Studio 2015\Projects\ChildProtection\UIChildProtection\UIChildProtection\Upload");
            //foreach (string filePath in filePaths)
            //{
            //    System.IO.File.Delete(filePath);

            //}
            var childinfo = objBs.GetALL().Where(x => x.IsApproved == "A").Reverse();
          


            ViewBag.TotalPages = Math.Ceiling(objBs.GetALL().Where(x => x.IsApproved == "A").Count() / 6.0);


            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            childinfo = childinfo.Skip((page - 1) * 6).Take(6).ToList();
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