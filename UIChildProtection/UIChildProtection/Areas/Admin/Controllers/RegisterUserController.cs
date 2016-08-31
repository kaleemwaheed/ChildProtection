using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Admin.Controllers
{
    [Authorize]
    public class RegisterUserController : Controller
    {

        private UserBs objBs;
        // GET: Admin/RegisterUser
        public RegisterUserController()
        {
            objBs = new UserBs();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    objBs.Insert(user);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
