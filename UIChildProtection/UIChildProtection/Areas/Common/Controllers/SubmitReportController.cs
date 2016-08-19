using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Common.Controllers
{
    public class SubmitReportController : Controller
    {
        // GET: Common/SubmitReport
        // GET: Common/BrowseMissingChild
        private ChildInfoBs objBs;
        public SubmitReportController()
        {
            objBs = new ChildInfoBs();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_ChildInfo obj, HttpPostedFileBase file)
        {
            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", ".jpeg"
        };

           
                if (ModelState.IsValid)
                {


                    if (file != null)
                    {

                        string ImageName = Path.GetFileName(file.FileName);


                        var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string physicalPath = Server.MapPath("~/images/" + ImageName);
                            file.SaveAs(physicalPath);

                        // tbl_ChildInfo newRecord = new tbl_ChildInfo();
                        // newRecord.imageUrl = ImageName;
                        // objBs.Insert(newRecord);
                        // ViewBag.image = ImageName;

                        try
                        {
                            obj.imageUrl = ImageName;
                            objBs.Insert(obj);
                            TempData["Msg"] = "Created Successfully";
                            return RedirectToAction("Index");
                        }
                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {
                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                                }
                            }
                        }
                       
                        }
                        else
                        {
                            TempData["Msg"] = "Only select  .Jpg , .png ,.jpg ,jpeg";
                            return RedirectToAction("Index");

                        }
                    }

                }
           
            return RedirectToAction("Index");

        }


    }
}