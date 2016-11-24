using AForge.Imaging;
using AForge.Imaging.Filters;
using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Common.Controllers
{
    public class SearchController : Controller
    {
        // GET: Common/Search
        private ChildInfoBs obj;
        // int count = 0;
        //static ArrayList list = new ArrayList();
        List<String> list = new List<string>();

        public SearchController()
        {
            obj = new ChildInfoBs();
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


            List<SelectListItem> glasses = new List<SelectListItem>();
            glasses.Add(new SelectListItem { Text = "Select", Value = "Select" });
            glasses.Add(new SelectListItem { Text = "No", Value = "No " });
            glasses.Add(new SelectListItem { Text = "Yes", Value = "Yes" });
            ViewBag.Glasses = glasses;


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
            Colour.Add(new SelectListItem { Text = "black", Value = "Black" });
            Colour.Add(new SelectListItem { Text = "brown", Value = "Brown" });
            Colour.Add(new SelectListItem { Text = "gray", Value = "Gray" });
            Colour.Add(new SelectListItem { Text = "blue", Value = "Blue" });
            Colour.Add(new SelectListItem { Text = "hazel", Value = "Hazel" });
            Colour.Add(new SelectListItem { Text = "pink", Value = "Pink" });
            Colour.Add(new SelectListItem { Text = "purple", Value = "Purple" });
            Colour.Add(new SelectListItem { Text = "yellow", Value = "Yellow" });
            Colour.Add(new SelectListItem { Text = "green", Value = "Green" });
            Colour.Add(new SelectListItem { Text = "white", Value = "White" });
            Colour.Add(new SelectListItem { Text = "orange", Value = "Orange" });
            ViewBag.Colour = Colour;



            List<SelectListItem> province = new List<SelectListItem>();
            province.Add(new SelectListItem { Text = "Select", Value = "Select" });
            province.Add(new SelectListItem { Text = "Punjab", Value = "Punjab" });
            province.Add(new SelectListItem { Text = "Blochistan", Value = "Blochistan" });
            province.Add(new SelectListItem { Text = "KPK", Value = "KPK" });
            province.Add(new SelectListItem { Text = "Sindh", Value = "Sindh" });
            province.Add(new SelectListItem { Text = "Gilgit", Value = "Gilgit" });
            province.Add(new SelectListItem { Text = "Kashmir", Value = "Kashmir" });
            ViewBag.Province = province;



            List<SelectListItem> city = new List<SelectListItem>();
            city.Add(new SelectListItem { Text = "Select", Value = "Select" });
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
        public ActionResult Find(tbl_SearchValidation info)
        {
          

            if (info.ChildName != null)
            {
                info.ChildName = info.ChildName.ToUpper();
            }
            if (info.ChildAlternativeName != null)
            {
                info.ChildAlternativeName = info.ChildAlternativeName.ToUpper();
            }


            var find = obj.GetALL().ToList().Where(x => x.ChildName == info.ChildName || (x.ChildId == info.id && x.IsApproved == "A") || x.Age == info.Age || x.Gender == info.Gender || x.ChildAlternativeName == info.ChildAlternativeName || x.HairColor == info.HairColor || x.Build == info.Build || x.EyeColor == info.EyeColor || x.Glasses == info.Glasses || x.IdentityMark == info.IdentityMark || x.Shirt == info.Shirt || x.Trouser_Skert == info.Trouser_Skert || x.Province == info.Province || x.City == info.City || x.IdentificationMarkOnBody == info.IdentificationMarkOnBody );
            if (find.Any() /*|| list!=null*/)
            {
                
                return View(find);
                
            }
            else
            {
                TempData["Msg"] = "Match Not Found";
                return RedirectToAction("Index");
            }

        }
        
    }
}