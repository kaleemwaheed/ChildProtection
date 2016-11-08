using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChildProtection.Areas.Common.Controllers
{
    [Authorize(Roles = "A,U")]
    public class ViewMissingReportController : Controller
    {
        // GET: Common/ViewMissingReport
        private ChildInfoBs objBs;
        public ViewMissingReportController()
        {
            objBs = new ChildInfoBs();
        }

        public ActionResult Index()
        {
            var childinfo = objBs.GetALL().Where(x => x.IsApproved == "A");
            int NumberofMissingChild = childinfo.Count();
            ViewBag.Count = NumberofMissingChild;
            return View(childinfo);
        }

        public ActionResult Punjab()
        {
            var childinfo = objBs.GetALL().Where(x => x.Province == "Punjab");
            int NumberofMissingChild = childinfo.Count();
            ViewBag.Count = NumberofMissingChild;
            return View(childinfo);
        }

        public ActionResult Sindh()
        {
            var childinfo = objBs.GetALL().Where(x => x.Province== "Sindh");
            int NumberofMissingChild = childinfo.Count();
            ViewBag.Count = NumberofMissingChild;
            return View(childinfo);
        }
        public ActionResult KPK()
        {
            var childinfo = objBs.GetALL().Where(x => x.Province == "KPK");
            int NumberofMissingChild = childinfo.Count();
            ViewBag.Count = NumberofMissingChild;

            return View(childinfo);
        }
        public ActionResult Blochistan()
        {
            var childinfo = objBs.GetALL().Where(x => x.Province== "Blochistan");
            int NumberofMissingChild = childinfo.Count();
            ViewBag.Count = NumberofMissingChild;
            return View(childinfo);
        }
        public ActionResult Capital()
        {
            var childinfo = objBs.GetALL().Where(x => x.Province == "Capital");
            int NumberofMissingChild = childinfo.Count();
            ViewBag.Count = NumberofMissingChild;
            return View(childinfo);
        }
        public ActionResult Gilgit()
        {
            var childinfo = objBs.GetALL().Where(x => x.Province == "Gilgit");
            int NumberofMissingChild = childinfo.Count();
            ViewBag.Count = NumberofMissingChild;
            return View(childinfo);
        }
        public ActionResult Kashmir()
        {
            var childinfo = objBs.GetALL().Where(x => x.Province == "Kashmir");
            int NumberofMissingChild = childinfo.Count();
            ViewBag.Count = NumberofMissingChild;
            return View(childinfo);
        }
        public ActionResult City(string City)
        {
            var childinfo = objBs.GetALL().Where(x => x.City == City);
            int NumberofMissingChild = childinfo.Count();
            ViewBag.Count = NumberofMissingChild;
            return View(childinfo);
        }


        public ActionResult ProvinceChart()
        {
            double punjab = objBs.GetALL().Where(x => x.Province == "Punjab").Count(); ;
            double sindh = objBs.GetALL().Where(x => x.Province == "Sindh").Count();
            double blochistan = objBs.GetALL().Where(x => x.Province == "Blochistan").Count();
            double capital= objBs.GetALL().Where(x => x.Province == "Capital").Count();
            double kashmir = objBs.GetALL().Where(x => x.Province == "Kashmir").Count();
            double gilgit = objBs.GetALL().Where(x => x.Province == "Gilgit").Count();
            double kpk = objBs.GetALL().Where(x => x.Province == "KPK").Count();
            if (kpk == 0)
            {
                kpk = 1;
            }
            if (blochistan == 0)
            {
                blochistan = 1;
            }
            if (capital == 0)
            {
                capital = 1;
            }
            if (kashmir == 0)
            {
                kashmir = 1;
            }
            if (sindh == 0)
            {
                sindh = 1;
            }
            if (gilgit == 0)
            {
                gilgit = 1;
            }
            if (punjab == 0)
            {
                punjab = 1;
            }


            //string myTheme =@"<Chart Black=""TransParent""> 
            //                                            <ChartAreas>
            //                                            <ChartArae Name = ""Default"" BlackColor =""Transparent""></ChartArea>
            //                                             </CartAreas>";
            new System.Web.Helpers.Chart(width: 800,height:200).AddSeries(
                chartType: "Pie",
                xValue: new[] { "Punjab", "Sindh",  "Bloch", "Cap", "AK","Gilgit", "KPK" },
                yValues: new[] { punjab, sindh, blochistan, capital, kashmir, gilgit,kpk }).Write("png");

            return null;
        }


    }
}