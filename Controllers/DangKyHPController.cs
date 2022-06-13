using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_TranDinhNguyen_B5.Models;

namespace KiemTra_TranDinhNguyen_B5.Controllers
{
    public class DangKyHPController : Controller
    {
        SinhVienDataContext context = new SinhVienDataContext();
        // GET: DangKyHP
        public ActionResult Index()
        {
            return View();
        }
    }
}