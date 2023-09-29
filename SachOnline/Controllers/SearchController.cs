using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using SachOnline.Controllers;

namespace SachOnline.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search

        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string strSearch)
        {
            if (strSearch != null && strSearch != "")
            {
                //var kq = from s in db.SACHes select s;
                var kq = db.SACHes.Where(s => s.TenSach.Contains(strSearch));
                ViewBag.KQ = kq.Count();
                ViewBag.Search = strSearch;
                //var kq = db.SACHes…
                return View(kq);
            }
            return View();
        }
    }
}