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
  
    public class ImageSearchController : Controller
    {
        // GET: Common/ImageSearch
        List<String> list = new List<string>();
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult Find(HttpPostedFileBase file)
        {
            string time = DateTime.Now.ToString("HHmmss");


            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", ".jpeg"
        };


            if (file != null)
            {

                if (file.ContentLength > (1 * 1024 * 1024))
                {
                    TempData["Msg"] = "Image size Must be less than 1MB";

                    return View("Index");
                }

                string ImageName = System.IO.Path.GetFileName(file.FileName.ToString());
                string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/images"));


                var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                string physicalPath = Server.MapPath("~/Upload/" + time + ImageName);
                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    file.SaveAs(physicalPath);
                }
                else
                {
                    TempData["Msg"] = ("Only select  .Jpg , .png ,.jpg ,jpeg");
                    return View("Index");
                }

                //var imageFile = Server.MapPath("~/images/" + item);

                //var imageFile = Server.MapPath("~") + @"Content\Images\Logo.png";
                //for (int i = 0; i < item.Count(); i++) {

                //var imageFile = Server.MapPath("~") + @"images\" + item[i];
                Bitmap largeImage = (Bitmap)Bitmap.FromFile(physicalPath);
                for (int i = 0; i < filesindirectory.Count(); i++)
                {

                    string physicalPath2 = filesindirectory[i];
                    Bitmap smallImage = (Bitmap)Bitmap.FromFile(physicalPath2);
                    // (set similarity threshold to 90%)
                    ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.50f);

                    Size size = GetSize(largeImage.Size, smallImage.Size);
                    ResizeBilinear filter = new ResizeBilinear(size.Width, size.Height);
                    smallImage = filter.Apply(smallImage);
                    TemplateMatch[] matches = tm.ProcessImage(largeImage, smallImage);

                    // find all matchings with specified above similarity
                    //TemplateMatch[] matches = tm.ProcessImage(largeImage, smallImage);

                    if (matches.Length > 0 && matches.Length <= 1)
                    {

                        list.Add(physicalPath2);
                        TemplateMatch match = matches[0];
                        //TempData["Msg"] = "Match Found X: " + match.Rectangle.Location.X + match.Rectangle.Location.Y + "--" + count;
                    }
                    else
                    {
                        // TempData["Msg"] = "Match NOT Match found:";
                    }


                }

               /* physicalPath = null*/;

            }   //End if file
            else
            {

                TempData["Msg"] = "Please select Image for search";
                return View("Index");
            }

            if (list != null)
            {
                ViewBag.List = list;
                return View();


            }
            else
            {
                TempData["Msg"] = "Match Not Found";
                return View("Index");
            }

        }


        private Size GetSize(Size maxSize, Size size)
        {

            double ratioWidth = (double)maxSize.Width / size.Width;
            double ratioHeight = (double)maxSize.Height / size.Height;
            double ratio = Math.Min(ratioWidth, ratioHeight);
            return new Size((int)Math.Floor(size.Width * ratio), (int)Math.Floor(size.Height * ratio));
        }



    }
}
