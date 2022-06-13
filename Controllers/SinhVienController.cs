using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_TranDinhNguyen_B5.Models;

namespace KiemTra_TranDinhNguyen_B5.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        SinhVienDataContext context = new SinhVienDataContext();
        public ActionResult ListSV()
        {
            var all_SV = from sv in context.SinhViens select sv;
            return View(all_SV);
        }
        public ActionResult Detail(string id)
        {
            var D_sv = context.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sv);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var E_masv = collection["MaSV"];
            var E_hoten = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];
            if (string.IsNullOrEmpty(E_masv))
            {
                ViewData["Error"] = "Don't Empty";
            }
            else
            {
                sv.MaSV = E_masv.ToString();
                sv.HoTen = E_hoten.ToString();
                sv.GioiTinh = E_gioitinh.ToString();
                sv.NgaySinh = E_ngaysinh;
                sv.Hinh = E_hinh.ToString();
                sv.MaNganh = E_manganh.ToString();
                context.SinhViens.InsertOnSubmit(sv);
                context.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            return this.Create();
        }

        public ActionResult Edit(string id)
        {
            var E_sv = context.SinhViens.First(m => m.MaSV == id);
            return View(E_sv);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_sv = context.SinhViens.First(m => m.MaSV == id);
            var E_masv = collection["MaSV"];
            var E_hoten = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];
            return this.Edit(id);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            var D_sv = context.SinhViens.First(m => m.MaSV == id);
            return View(D_sv);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sv = context.SinhViens.Where(m => m.MaSV == id).First();
            context.SinhViens.DeleteOnSubmit(D_sv);
            context.SubmitChanges();
            return RedirectToAction("ListSV");
        }
    }
}