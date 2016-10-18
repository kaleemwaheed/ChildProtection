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
       // OptionList opt = new OptionList();

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
            build.Add(new SelectListItem { Text = "Muscular", Value = "Muscular" });
            ViewBag.Build = build;

            List<SelectListItem> eyeColour = new List<SelectListItem>();
            eyeColour.Add(new SelectListItem { Text = "black", Value = "black" });
            eyeColour.Add(new SelectListItem { Text = "brown", Value = "brown" });
            eyeColour.Add(new SelectListItem { Text = "gray", Value = "gray" });
            eyeColour.Add(new SelectListItem { Text = "Blue", Value = "Blue" });
            eyeColour.Add(new SelectListItem { Text = "Hazel", Value = "Hazel" });

            ViewBag.EyeColour = eyeColour;

            List<SelectListItem> hairColour = new List<SelectListItem>();

            hairColour.Add(new SelectListItem { Text = "black", Value = "black" });
            hairColour.Add(new SelectListItem { Text = "white", Value = "white" });
            hairColour.Add(new SelectListItem { Text = "brown", Value = "brown" });
            hairColour.Add(new SelectListItem { Text = "gray", Value = "gray" });
            hairColour.Add(new SelectListItem { Text = "Red", Value = "Red" });
            hairColour.Add(new SelectListItem { Text = "No hair", Value = "No hair" });
            ViewBag.Haircolour = hairColour;


            List<SelectListItem> glasses = new List<SelectListItem>();
            glasses.Add(new SelectListItem { Text = "Yes", Value = "Yes" });
            glasses.Add(new SelectListItem { Text = "No", Value = "No" });
            ViewBag.Glasses = glasses;


            List<SelectListItem> identityMark = new List<SelectListItem>();
            identityMark.Add(new SelectListItem { Text = "No", Value = "No"/*, Selected = true */});
            identityMark.Add(new SelectListItem { Text = "Scars", Value = "Scars" });
            identityMark.Add(new SelectListItem { Text = "Birthmarks", Value = "Birthmarks" });
            identityMark.Add(new SelectListItem { Text = "moles", Value = "moles" });
            identityMark.Add(new SelectListItem { Text = "Tattoo", Value = "Tattoo" });
            ViewBag.IdentityMark = identityMark;

            List<SelectListItem> identityMarkLocation = new List<SelectListItem>();
            identityMarkLocation.Add(new SelectListItem { Text = "No", Value = "No" });
            identityMarkLocation.Add(new SelectListItem { Text = "face", Value = "face" });
            identityMarkLocation.Add(new SelectListItem { Text = "mouth", Value = "mouth" });
            identityMarkLocation.Add(new SelectListItem { Text = "chin", Value = "chin" });
            identityMarkLocation.Add(new SelectListItem { Text = "arm", Value = "arm" });
            identityMarkLocation.Add(new SelectListItem { Text = "shoulder", Value = "shoulder" });
            identityMarkLocation.Add(new SelectListItem { Text = "elbow", Value = "elbow" });
            identityMarkLocation.Add(new SelectListItem { Text = "forearm", Value = "forearm" });
            identityMarkLocation.Add(new SelectListItem { Text = "hand", Value = "hand" });
            identityMarkLocation.Add(new SelectListItem { Text = "foot", Value = "foot" });
            ViewBag.IdentityMarkLocation = identityMarkLocation;

 

            List<SelectListItem> Colour = new List<SelectListItem>();
            Colour.Add(new SelectListItem { Text = "blue", Value = "blue" });
            Colour.Add(new SelectListItem { Text = "black", Value = "black" });
            Colour.Add(new SelectListItem { Text = "brown", Value = "brown" });
            Colour.Add(new SelectListItem { Text = "gray", Value = "gray" });
            Colour.Add(new SelectListItem { Text = "hazel", Value = "hazel" });
            Colour.Add(new SelectListItem { Text = "pink", Value = "pink" });
            Colour.Add(new SelectListItem { Text = "purple", Value = "purple" });
            Colour.Add(new SelectListItem { Text = "yellow", Value = "yellow" });
            Colour.Add(new SelectListItem { Text = "green", Value = "green" });
            Colour.Add(new SelectListItem { Text = "white", Value = "white" });
            Colour.Add(new SelectListItem { Text = "orange", Value = "orange" });
            ViewBag.Colour = Colour;



            List<SelectListItem> province = new List<SelectListItem>();
            province.Add(new SelectListItem { Text = "Punjab", Value = "Punjab" });
            province.Add(new SelectListItem { Text = "Blochistan", Value = "Blochistan" });
            province.Add(new SelectListItem { Text = "KPK", Value = "KPK" });
            province.Add(new SelectListItem { Text = "Sindh", Value = "Sindh" });
            province.Add(new SelectListItem { Text = "Gilgit", Value = "Gilgit" });
            province.Add(new SelectListItem { Text = "Kashmir", Value = "Kashmir" });
            ViewBag.Province = province;



            List<SelectListItem> city = new List<SelectListItem>();
            city.Add(new SelectListItem { Text = "Lahore", Value = "Lahore" });
            city.Add(new SelectListItem { Text = "Islamabad", Value = "Islamabad" });
            city.Add(new SelectListItem { Text = "Faisalabad", Value = "Faisalabad" });
            city.Add(new SelectListItem { Text = "Rawalpindi", Value = "Rawalpindi" });
            city.Add(new SelectListItem { Text = "Multan", Value = "Multan" });
            city.Add(new SelectListItem { Text = "Gujranwala", Value = "Gujranwala" });
            city.Add(new SelectListItem { Text = "Sargodha", Value = "Sargodha" });
            city.Add(new SelectListItem { Text = "Sialkot", Value = "Sialkot" });
            city.Add(new SelectListItem { Text = "Sheikhupura", Value = "Sheikhupura" });
            city.Add(new SelectListItem { Text = "Bahawalpur", Value = "Bahawalpur" });
            city.Add(new SelectListItem { Text = "Gujrat", Value = "Gujrat" });
            city.Add(new SelectListItem { Text = "Jhang", Value = "Jhang" });
            city.Add(new SelectListItem { Text = "Sahiwal", Value = "Sahiwal" });


            city.Add(new SelectListItem { Text = "Quetta", Value = "Quetta" });
            city.Add(new SelectListItem { Text = "Turbat", Value = "Turbat" });
            city.Add(new SelectListItem { Text = "Sibi", Value = "Sibi" });
            city.Add(new SelectListItem { Text = "Lasbela", Value = "Lasbela" });
            city.Add(new SelectListItem { Text = "Zhob", Value = "Zhob" });
            city.Add(new SelectListItem { Text = "Gwadar", Value = "Gwadar" });
            city.Add(new SelectListItem { Text = "Nasirabad", Value = "Nasirabad" });
            city.Add(new SelectListItem { Text = "Jaffarabad", Value = "Jaffarabad" });
            city.Add(new SelectListItem { Text = "Khuzdar", Value = "Khuzdar" });


            city.Add(new SelectListItem { Text = "Peshawar", Value = "Peshawar" });
            city.Add(new SelectListItem { Text = "Mardan", Value = "Mardan" });
            city.Add(new SelectListItem { Text = "Abbottabad", Value = "Abbottabad" });
            city.Add(new SelectListItem { Text = "Mingora", Value = "Mingora" });
            city.Add(new SelectListItem { Text = "Kohat", Value = "Kohat" });
            city.Add(new SelectListItem { Text = "Bannu", Value = "Bannu" });
            city.Add(new SelectListItem { Text = "Swabi", Value = "Swabi" });
            city.Add(new SelectListItem { Text = "Charsadda", Value = "Charsadda" });
            city.Add(new SelectListItem { Text = "Nowshera", Value = "Nowshera" });

            city.Add(new SelectListItem { Text = "Karachi", Value = "Karachi" });
            city.Add(new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" });
            city.Add(new SelectListItem { Text = "Sukkur", Value = "Sukkur" });
            city.Add(new SelectListItem { Text = "Larkana", Value = "Larkana" });
            city.Add(new SelectListItem { Text = "Nawabshah", Value = "Nawabshah" });
            city.Add(new SelectListItem { Text = "MirpurKhas", Value = "MirpurKhas" });
            city.Add(new SelectListItem { Text = "Jacobabad", Value = "Jacobabad" });
            city.Add(new SelectListItem { Text = "Shikarpur", Value = "Shikarpur" });
            city.Add(new SelectListItem { Text = "Dadu", Value = "Dadu" });


            city.Add(new SelectListItem { Text = "Gilgit", Value = "Gilgit" });
            city.Add(new SelectListItem { Text = "Skardu", Value = "Skardu" });
            ViewBag.City = city;


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
                            obj.ChildName = obj.ChildName.ToUpper();
                            obj.ChildAlternativeName = obj.ChildAlternativeName.ToUpper();
                            obj.PoliceStationEmail = " ";
                            obj.PoliceStation = " ";
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
                        return View("Index");

                    }
                }else
                {
                    TempData["Msg"] = "Please select image file";
                    return View("Index");
                }

            }
            TempData["Msg"] = "Created Failed";
            return View("Index");

        }


    }
}
