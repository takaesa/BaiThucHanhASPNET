using BaiThucHanhASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using BaiThucHanhASPNET.Repository;
namespace BaiThucHanhASPNET.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSPRepository _loaiSp;
        public LoaiSpMenuViewComponent(ILoaiSPRepository loaiSPRepository)
        {
            _loaiSp = loaiSPRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
