using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Admin.Controllers
{
    [Authorize(Roles = "A,U")]
    public class MissingChildController : Controller
    {
        // GET: Admin/MissingChild
        private ChildInfoBs objBs;

        public MissingChildController()
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
            int Id = Convert.ToInt32(SortOrder);

            var childinfo = objBs.GetALL().Where(x => x.ChildId == Id);
            return View(childinfo);
        }




        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var user = objBs.GetByID(id);
        //   // UserName = user.UserEmail;
        //   // ViewBag.USERNAME = UserName;
        //    return View(user);
        //}
        //[HttpPost]
        //public ActionResult Edit(tbl_ChildInfo user)
        //{

        //    try
        //    {

        //       // ModelState.Remove("UserEmail");

        //        if (ModelState.IsValid)
        //        {
        //         //   user.UserEmail = UserName;
        //            objBs.Update(user);
        //            TempData["Msg"] = "Update Successfully";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //         //   ViewBag.USERNAME = UserName;
        //            return View("Edit");
        //        }
        //    }
        //    catch (Exception e1)
        //    {
        //        //ViewBag.USERNAME = UserName;
        //        TempData["Msg"] = "Create Failed : " + e1.Message;
        //        return RedirectToAction("Edit");
        //    }



        //}

        public ActionResult Delete(int id)
        {
            objBs.Delete(id);
            TempData["Msg"] = "Delete Successfully";
            return View("Index");

        }

    }
}