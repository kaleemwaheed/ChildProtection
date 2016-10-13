using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class UserListController : Controller
    {
        // GET: Admin/UserList
        private UserBs objBs;
        public UserListController()
        {
            objBs = new UserBs();
        }
        public ActionResult Index()
        {
            var userList = objBs.GetALL().Where(x => x.Role == "U");
            return View(userList);
            
        }
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var user = objBs.GetByID(id);
        //    return View(user);
           

        //}
        //[HttpPost]
        //public ActionResult Edit(tbl_User user)
        //{
        //    try
        //    {

                
        //        if (ModelState.IsValid)
        //        {
        //            objBs.Update(user);
        //            TempData["Msg"] = "Update Successfully";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return View("Edit");
        //        }
        //    }
        //    catch (Exception e1)
        //    {
        //        TempData["Msg"] = "Create Failed : " + e1.Message;
        //        return RedirectToAction("Edit");
        //    }



        //}

        public ActionResult Delete(int id)
        {
            objBs.Delete(id);
            return RedirectToAction("Index");

        }
    }
}