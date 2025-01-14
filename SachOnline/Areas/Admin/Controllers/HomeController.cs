﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
namespace SachOnline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var sTenDN = f["UserName"];
            var sMatKhau = f["Password"];

            ADMIN ad = db.ADMINs.SingleOrDefault(n => n.TenDN == sTenDN && n.MatKhau == sMatKhau);
            if (ad != null)
            {
                Session["Admin"] = ad;
                return RedirectToAction("Index", "Sach");
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
            return View();
        }
    }
}