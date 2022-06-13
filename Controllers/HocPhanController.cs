using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_TranDinhNguyen_B5.Models;

namespace KiemTra_TranDinhNguyen_B5.Controllers
{
    public class HocPhanController : Controller
    {
        // GET: HocPhan
        SinhVienDataContext context = new SinhVienDataContext();

        
            public List<HocPhan> LayHocPhan()
            {
                List<HocPhan> listHocPhan = Session["HocPhan"] as List<HocPhan>;
                if (listHocPhan == null)
                {
                    listHocPhan = new List<HocPhan>();
                    Session["HocPhan"] = listHocPhan;
                }
                return listHocPhan;
            }
        

        public ActionResult ThemHocPhan(string id, string strURL)
        {
            List<HocPhan> listHocPhan = LayHocPhan();
            HocPhan hocphan = listHocPhan.Find(n => n.MaHP == id);
            if (hocphan == null)
            {
                hocphan = new HocPhan(id);
                listHocPhan.Add(hocphan);
                return Redirect(strURL);
            }
            else
            {
                hocphan.SoTinChi++;
                return Redirect(strURL);
            }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}