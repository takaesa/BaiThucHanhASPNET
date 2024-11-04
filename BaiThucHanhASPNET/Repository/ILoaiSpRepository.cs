using BaiThucHanhASPNET.Models;

namespace BaiThucHanhASPNET.Repository
{
    public interface ILoaiSPRepository
    {
        TLoaiSp Add(TLoaiSp loaiSP);
        TLoaiSp Update(TLoaiSp loaiSP);
        TLoaiSp Delete(String maloaiSP);
        TLoaiSp GetLoaiSp(String maloaiSP);
        IEnumerable<TLoaiSp> GetAllLoaiSp();

    }
}
