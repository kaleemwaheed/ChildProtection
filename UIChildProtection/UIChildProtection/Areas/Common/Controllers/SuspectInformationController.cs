using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Common.Controllers
{
    public class SuspectInformationController : Controller
    {
        // GET: Common/SuspectInformation

        private SuspectPersonInformationBs objSuspectInformation;
        public SuspectInformationController()
        {
            objSuspectInformation = new SuspectPersonInformationBs();
        }
        public ActionResult Index()
        {

            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem { Text = "Select", Value = "Select" });
            gender.Add(new SelectListItem { Text = "Male  ", Value = "Male  " });
            gender.Add(new SelectListItem { Text = "Female", Value = "Female" });
            ViewBag.Gender = gender;

            List<SelectListItem> build = new List<SelectListItem>();
            build.Add(new SelectListItem { Text = "Select", Value = "Select" });
            build.Add(new SelectListItem { Text = "Slim", Value = "Slim      " });
            build.Add(new SelectListItem { Text = "Fat", Value = "Fat       " });
            build.Add(new SelectListItem { Text = "Stocky", Value = "Stocky    " });
            build.Add(new SelectListItem { Text = "Medium", Value = "Medium    " });
            build.Add(new SelectListItem { Text = "Thin", Value = "Thin      " });
            ViewBag.Build = build;

            List<SelectListItem> eyeColour = new List<SelectListItem>();
            eyeColour.Add(new SelectListItem { Text = "Select", Value = "Select" });
            eyeColour.Add(new SelectListItem { Text = "black", Value = "black     " });
            eyeColour.Add(new SelectListItem { Text = "brown", Value = "brown     " });
            eyeColour.Add(new SelectListItem { Text = "gray", Value = "gray      " });
            eyeColour.Add(new SelectListItem { Text = "Blue", Value = "Blue      " });

            ViewBag.EyeColour = eyeColour;

            List<SelectListItem> hairColour = new List<SelectListItem>();
            hairColour.Add(new SelectListItem { Text = "Select", Value = "Select" });
            hairColour.Add(new SelectListItem { Text = "black", Value = "black     " });
            hairColour.Add(new SelectListItem { Text = "white", Value = "white     " });
            hairColour.Add(new SelectListItem { Text = "brown", Value = "brown     " });
            hairColour.Add(new SelectListItem { Text = "gray", Value = "gray      " });
            hairColour.Add(new SelectListItem { Text = "No hair", Value = "No hair" });
            ViewBag.Haircolour = hairColour;

            List<SelectListItem> yesno = new List<SelectListItem>();
            yesno.Add(new SelectListItem { Text = "Select", Value = "Select" });
            yesno.Add(new SelectListItem { Text = "No", Value = "No " });
            yesno.Add(new SelectListItem { Text = "Yes", Value = "Yes" });
            ViewBag.Yesno = yesno;


            List<SelectListItem> identityMark = new List<SelectListItem>();
            identityMark.Add(new SelectListItem { Text = "Select", Value = "Select"/*, Selected = true */});
            identityMark.Add(new SelectListItem { Text = "Scars", Value = "Scars" });
            identityMark.Add(new SelectListItem { Text = "Birthmarks", Value = "Birthmarks" });
            identityMark.Add(new SelectListItem { Text = "moles", Value = "moles" });
            identityMark.Add(new SelectListItem { Text = "Tattoo", Value = "Tattoo" });
            ViewBag.IdentityMark = identityMark;

            List<SelectListItem> identityMarkLocation = new List<SelectListItem>();
            identityMarkLocation.Add(new SelectListItem { Text = "Select", Value = "Select" });
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
            Colour.Add(new SelectListItem { Text = "Select", Value = "Select" });
            Colour.Add(new SelectListItem { Text = "black", Value = "black" });
            Colour.Add(new SelectListItem { Text = "brown", Value = "brown" });
            Colour.Add(new SelectListItem { Text = "gray", Value = "gray" });
            Colour.Add(new SelectListItem { Text = "blue", Value = "blue" });
            Colour.Add(new SelectListItem { Text = "hazel", Value = "hazel" });
            Colour.Add(new SelectListItem { Text = "pink", Value = "pink" });
            Colour.Add(new SelectListItem { Text = "purple", Value = "purple" });
            Colour.Add(new SelectListItem { Text = "yellow", Value = "yellow" });
            Colour.Add(new SelectListItem { Text = "green", Value = "green" });
            Colour.Add(new SelectListItem { Text = "white", Value = "white" });
            Colour.Add(new SelectListItem { Text = "orange", Value = "orange" });
            ViewBag.Colour = Colour;


            List<SelectListItem> complexion = new List<SelectListItem>();
            complexion.Add(new SelectListItem { Text = "Select", Value = "Select" });
            complexion.Add(new SelectListItem { Text = "Sallow", Value = "Sallow" });
            complexion.Add(new SelectListItem { Text = "Olive", Value = "Olive" });
            complexion.Add(new SelectListItem { Text = "Yellow", Value = "Yellow" });
            complexion.Add(new SelectListItem { Text = "Pale", Value = "Pale" });
            complexion.Add(new SelectListItem { Text = "Dark", Value = "Dark" });

            ViewBag.Complexion = complexion;

            return View();
        }
        [HttpPost]
        public ActionResult index(tbl_SuspectPersonInformation obj)
        {

            if (ModelState.IsValid)
            {
                objSuspectInformation.Insert(obj);
                TempData["Msg"] = "Submit Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Msg"] = "Failed";
                return RedirectToAction("Index");

            }
        }


    }
}
