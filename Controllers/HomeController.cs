Cusing System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_TranDinhNguyen_B5.Models;
using PagedList;


namespace KiemTra_TranDinhNguyen_B5.Controllers
{
    public class HomeController : Controller
    {
        SinhVienDataContext context = new SinhVienDataContext();
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var all_book = (from s in context.SinhViens select s).OrderBy(m => m.MaSV);
            int pageNum = page ?? 1;
            int pageSize = 6;

            return View(all_book.ToPagedList(pageNum, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}