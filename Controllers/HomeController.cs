using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAD_Assignment_No_3.Models;

namespace EAD_Assignment_No_3.Controllers
{
    public class HomeController : Controller
    {
        MosqueListClassDataContext dc = new MosqueListClassDataContext();
        public ActionResult Index()
        {
            return View(dc.MosqueLists.Select(m => m.Area).Distinct().ToList());
        }

        public ActionResult Category()
        {
            var SelectedArea = Request["cat"];
           // return View(SelectedArea);
           return View(dc.MosqueLists.Where(a => a.Area == SelectedArea));
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddMosque()
        {
            ViewBag.Message = "Enter the follwoing Details to Add Mosque";

            return View();
        }
        public ActionResult Add()
        {
            string name = Request["MosqueName"];
            string address = Request["MosqueAddress"];
            string area = Request["Area"];
            area=area.Replace(" ","-");
            string FajarTime = Request["FajarHours"] +":"+ Request["FajarMinutes"] +" "+ Request["FajarMeridium"];
            string ZuharTime = Request["ZuharHours"] + ":" + Request["ZuharMinutes"] + " " + Request["ZuharMeridium"];
            string AsarTime = Request["AsarHours"] + ":" + Request["AsarMinutes"] + " " + Request["AsarMeridium"];
            string MaghribTime = Request["MaghribHours"] + ":" + Request["MaghribMinutes"] + " " + Request["MaghribMeridium"];
            string IshaTime = Request["IshaHours"] + ":" + Request["IshaMinutes"] + " " + Request["IshaMeridium"];
            string JummaTime = Request["JummaHours"] + ":" + Request["JummaMinutes"] + " " + Request["JummaMeridium"];
            MosqueList masjid = new MosqueList();
            masjid.Name = name;
            masjid.Address = address;
            masjid.Area = area;
            masjid.Fajar = FajarTime;
            masjid.Zuhar = ZuharTime;
            masjid.Asar = AsarTime;
            masjid.Maghrib = MaghribTime;
            masjid.Isha = IshaTime;
            masjid.Jumma = JummaTime;
            dc.MosqueLists.InsertOnSubmit(masjid);
            dc.SubmitChanges();
            return RedirectToAction("Index");


        }
        public ActionResult EditMosque(int id)
        {
            

            return View(dc.MosqueLists.First(m=>m.Id==id));
        }
        public ActionResult EditDone(int id)
        {

            var a = dc.MosqueLists.First(m => m.Id == id);
            a.Name = Request["MosqueName"];
            a.Address = Request["MosqueAddress"];
            a.Area = Request["Area"];
            if (Request["FajarHours"] != "00" || Request["FajarMinutes"] != "00")
            {
                a.Fajar = Request["FajarHours"] + ":" + Request["FajarMinutes"] + " " + Request["FajarMeridium"];
            }
            if (Request["ZuharHours"] != "00" || Request["ZuharMinutes"] != "00")
            {
                a.Zuhar = Request["ZuharHours"] + ":" + Request["ZuharMinutes"] + " " + Request["ZuharMeridium"];
            }
            if (Request["AsarHours"] != "00" || Request["AsarMinutes"] != "00")
            {
                a.Asar = Request["AsarHours"] + ":" + Request["AsarMinutes"] + " " + Request["AsarMeridium"];
            }
            if (Request["MaghribHours"] != "00" || Request["MaghribMinutes"] != "00")
            {
                a.Maghrib = Request["MaghribHours"] + ":" + Request["MaghribMinutes"] + " " + Request["MaghribMeridium"];
            }
            if (Request["IshaHours"] != "00" || Request["IshaMinutes"] != "00")
            {
                a.Isha = Request["IshaHours"] + ":" + Request["IshaMinutes"] + " " + Request["IshaMeridium"];
            }
            if (Request["JummaHours"] != "00" || Request["JummaMinutes"] != "00")
            {
                a.Jumma = Request["JummaHours"] + ":" + Request["JummaMinutes"] + " " + Request["JummaMeridium"];
            }
            dc.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}