using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Controllers
{
    public class NhaXuatBanController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: NhaXuatBan
        public ActionResult Index()
        {
            var kq = from s in data.NHAXUATBANs select s;

            return View(kq);
        }

        public ActionResult Details()
        {
            int manxb = int.Parse(Request.QueryString["id"]);
            return View(GetNXB(manxb));
        }

        public NHAXUATBAN GetNXB(int id)
        {
            return data.NHAXUATBANs.Where(nxb => nxb.MaNXB == id).SingleOrDefault();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(GetNXB(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit()
        {
            if(ModelState.IsValid)
            {
                var nxb = GetNXB(int.Parse(Request.Form["MaNXB"]));
                nxb.TenNXB = Request.Form["TenNXB"];
                nxb.DiaChi = Request.Form["DiaChi"];
                nxb.DienThoai = Request.Form["DienThoai"];
                data.SubmitChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Edit");
            }    
        }

    }
}