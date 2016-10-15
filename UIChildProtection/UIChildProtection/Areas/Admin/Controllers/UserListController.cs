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
        public static string UserName;
        
        public UserListController()
        {
            objBs = new UserBs();
        }
        public ActionResult Index()
        {
            var userList = objBs.GetALL().Where(x => x.Role == "U");
            return View(userList);
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = objBs.GetByID(id);
             UserName = user.UserEmail;
            ViewBag.USERNAME = UserName;
            return View(user);


        }
        [HttpPost]
        public ActionResult Edit(tbl_User user)
        {
            
            try
            {

                ModelState.Remove("UserEmail");

                if (ModelState.IsValid)
                {
                    user.UserEmail = UserName;
                    objBs.Update(user);
                    TempData["Msg"] = "Update Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.USERNAME = UserName;
                    return View("Edit");
                }
            }
            catch (Exception e1)
            {
                ViewBag.USERNAME = UserName;
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Edit");
            }



        }

        public ActionResult Delete(int id)
        {
            objBs.Delete(id);
            return RedirectToAction("Index");

        }
    }
}