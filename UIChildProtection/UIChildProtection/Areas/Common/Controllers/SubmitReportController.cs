using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UIChildProtection.Areas.Common.Models;

namespace UIChildProtection.Areas.Common.Controllers
{
    public class SubmitReportController : Controller
    {
        // GET: Common/SubmitReport
        // GET: Common/BrowseMissingChild
        private ChildInfoBs objBs;
        OptionList opt = new OptionList();

        public SubmitReportController()
        {
            objBs = new ChildInfoBs();
        }
        public ActionResult Index()
        {
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem { Text = "Male", Value = "Male" });
            gender.Add(new SelectListItem { Text = "Female", Value = "Female" });
            ViewBag.Gender = gender;

            List<SelectListItem> build = new List<SelectListItem>();
            build.Add(new SelectListItem { Text = "Fat", Value = "Fat" });
            build.Add(new SelectListItem { Text = "Stocky", Value = "Stocky" });
            build.Add(new SelectListItem { Text = "Slim", Value = "Slim" });
            build.Add(new SelectListItem { Text = "Medium", Value = "Medium" });
            build.Add(new SelectListItem { Text = "Thin", Value = "Thin" });
            ViewBag.Build = build;

            List<SelectListItem> eyeColour = new List<SelectListItem>();
            eyeColour.Add(new SelectListItem { Text = "black", Value = "black" });
            eyeColour.Add(new SelectListItem { Text = "brown", Value = "brown" });
            eyeColour.Add(new SelectListItem { Text = "gray", Value = "gray" });
            eyeColour.Add(new SelectListItem { Text = "Blue", Value = "Blue" });

            ViewBag.EyeColour = eyeColour;

            List<SelectListItem> hairColour = new List<SelectListItem>();

            hairColour.Add(new SelectListItem { Text = "black", Value = "black" });
            hairColour.Add(new SelectListItem { Text = "white", Value = "white" });
            hairColour.Add(new SelectListItem { Text = "brown", Value = "brown" });
            hairColour.Add(new SelectListItem { Text = "gray", Value = "gray" });
            hairColour.Add(new SelectListItem { Text = "No hair", Value = "No hair" });
            ViewBag.Haircolour = hairColour;


            List<SelectListItem> glasses = new List<SelectListItem>();
            glasses.Add(new SelectListItem { Text = "Yes", Value = "Yes" });
            glasses.Add(new SelectListItem { Text = "No", Value = "No" });
            ViewBag.Glasses = glasses;


            List<SelectListItem> identityMark = new List<SelectListItem>();
            identityMark.Add(new SelectListItem { Text = "Yes", Value = "Yes" });
            identityMark.Add(new SelectListItem { Text = "No", Value = "No" });
            ViewBag.IdentityMark = identityMark;

            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_ChildInfo obj, HttpPostedFileBase file)
        {
            //if (file.ContentLength > (4 * 1024 * 1024))
            //{
            //    TempData["Msg"] = "Created Failed File Lenght Must be less than 4MB";

            //    return View("Index");
            //}


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
                            obj.IsApproved = "P";
                            obj.PoliceStationEmail = "null";
                            obj.PoliceStation = "null";
                            obj.Report_Created_Date_Time = DateTime.Now;
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
            TempData["Msg"] = "Created Failed";
            return RedirectToAction("Index");

        }


    }
}
