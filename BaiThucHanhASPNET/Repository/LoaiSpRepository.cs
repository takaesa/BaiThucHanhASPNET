using BaiThucHanhASPNET.Models;

namespace BaiThucHanhASPNET.Repository
{
    public class LoaiSpRepository : ILoaiSPRepository
    {
        private readonly QlhangHoaContext _context;
        public LoaiSpRepository(QlhangHoaContext context)
        {
            _context = context;
        }
        public TLoaiSp Add(TLoaiSp loaiSP)
        {
            _context.TLoaiSps.Add(loaiSP);
            _context.SaveChanges();
            return loaiSP;
        }

        public TLoaiSp Delete(string maloaiSP)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoaiSp(string maloaiSP)
        {
            return _context.TLoaiSps.Find(maloaiSP);
        }

        public TLoaiSp Update(TLoaiSp loaiSP)
        {
            _context.Update(loaiSP);
            _context.SaveChanges();
            return loaiSP;
        }
    }
}
