using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using PagedList;
using PagedList.Mvc;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        // GET: SachOnline
      
        DataClasses1DataContext data = new DataClasses1DataContext();

        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.SACHes where s.MaSach == id select s;
            return View(sach.Single());
        }

        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }

        public ActionResult FooterPartial()
        {
            return PartialView();
        }

        public List<SACH> laySachNhieu (int count)
        {
            return data.SACHes.OrderByDescending(s => s.GiaBan > 0).Take(count).ToList();
        }

        public ActionResult LoginLogout()
        {
            return PartialView("LoginLogoutPartial");
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNXB = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(listNXB);
        }

      
        public ActionResult NavPartial()
        {
            return PartialView();
        }
        public ActionResult SliderPartial()
        {
            return PartialView();
        }
        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = laySachNhieu(Convert.ToInt32(6));
            return View(listSachBanNhieu);
        }

        //public ActionResult SachTheoChuDe(int id)
        //{
        //    var sach = from s in data.SACHes where s.MaCD == id select s;
        //    return View(sach);
        //}


        public ActionResult SachTheoChuDe(int id, int ? page)
        {
            ViewBag.MaCD = id;
            // Tạo biến quy định số sản phẩm trên mỗi trang
            int iSize = 3;
            // Tạo biến số trang
            int iPageNum = (page ?? 1);
            var sach = from s in data.SACHes where s.MaCD == id select s ;
            return View(sach.ToPagedList(iPageNum,iSize));
        }

        public ActionResult SachTheoNhaXuatBan(int id, int ? page)
        {
            ViewBag.MaNXB = id;
            // Tạo biến quy định số sản phẩm trên mỗi trang
            int iSize = 3;
            // Tạo biến số trang
            int iPageNum = (page ?? 1);
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach.ToPagedList(iPageNum, iSize));
        }

        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        // GET: SachOnline
        public ActionResult Index(int ? page)
        {
            //Lay 6 quyen sach moi
            var listSachMoi = LaySachMoi(20);
            int iSize = 3;
            int iPageNum = (page ?? 1);
            return View(listSachMoi.ToPagedList(iPageNum,iSize));
        }
    }
}
  