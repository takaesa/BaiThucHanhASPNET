using Microsoft.AspNetCore.Mvc;

using BaiThucHanhASPNET.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BaiThucHanhASPNET.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]

    public class HomeAdminController : Controller
    {
        QlhangHoaContext db = new QlhangHoaContext();
        [Route("")]
        [Route("index")]

        public IActionResult Index()
        {
            return View();
        }

        [Route("danhmucsanpham")]

        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);

            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);

            return View(lst);
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]

        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            return View();
        }

        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View();
        }


        [Route("SuaSanPham")]
        [HttpGet]

        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");

            var sanPham = db.TDanhMucSps.Find(maSanPham);
            return View(sanPham);
        }

        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SuaSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.TChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();

            if (chiTietSanPham.Count() > 0)
            {
                TempData["Message"] = "khong xoa duoc san pham nay";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }

            var anhSanPhams = db.TAnhSps.Where(x => x.MaSp == maSanPham);
            if (anhSanPhams.Any()) db.RemoveRange();
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();

            TempData["Message"] = "san pham da duoc xoa";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }

        [Route("danhsachkhachhang")]

        public IActionResult DanhSachKhachHang(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstkhachhang = db.TKhachHangs.AsNoTracking().OrderBy(x => x.TenKhachHang);

            PagedList<TKhachHang> lst = new PagedList<TKhachHang>(lstkhachhang, pageNumber, pageSize);

            return View(lst);
        }

        [Route("ThemKhachHangMoi")]
        [HttpGet]

        public IActionResult ThemKhachHangMoi()
        {
            ViewBag.Username = new SelectList(db.TKhachHangs.ToList(), "MaKhanhHang", "TenKhachHang");
            /*SelectList(db.TKhachHangs.ToList(), "Username", "Username")*/
            return View();
        }

        [Route("ThemKhachHangMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemKhachHangMoi(TKhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.TKhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("DanhSachKhachHang");
            }
            return View(khachHang);
        }
    }
}
