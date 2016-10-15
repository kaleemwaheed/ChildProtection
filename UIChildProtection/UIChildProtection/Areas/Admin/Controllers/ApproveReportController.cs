using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Admin.Controllers
{
    [Authorize(Roles ="A")]
    public class ApproveReportController : Controller
    {
        private ChildInfoBs objBs;
        public ApproveReportController()
        {
            objBs = new ChildInfoBs();
        }

        // GET: Admin/ApproveReport
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? "A" : Status);
            if (Status == null)
            {
                var urls = objBs.GetALL().Where(x => x.IsApproved == "A").ToList();
                return View(urls);
            }
            else
            {
                var urls = objBs.GetALL().Where(x => x.IsApproved == Status).ToList();
                return View(urls);
            }

        }




        public ActionResult Approve(int id)
        {
            try
            {
                var myUrl = objBs.GetByID(id);
                myUrl.IsApproved = "A";
                objBs.Update(myUrl);
                TempData["Msg"] = "Approved Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Approval Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Reject(int id)
        {
            try
            {
                var myUrl = objBs.GetByID(id);
                myUrl.IsApproved = "R";
                objBs.Update(myUrl);
                TempData["Msg"] = "Rejected Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Rejection Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int id)
        {
            objBs.Delete(id);
            return RedirectToAction("Index");

        }
    }
}