
namespace SoTayNongNghiep.Domain;

public class BaoCaoMuaVu
{
    public int MuaVuId { get; private set; }
    public decimal TongDoanhThu { get; private set; }
    public decimal TongChiPhi { get; private set; }

    public decimal LoiNhuan => TongDoanhThu - TongChiPhi;

    public string KetQua =>
        LoiNhuan > 0 ? "Có lãi" :
        LoiNhuan < 0 ? "Bị lỗ" : "Hòa vốn";

    private BaoCaoMuaVu(
        int muaVuId, decimal tongDoanhThu, decimal tongChiPhi)
    {
        MuaVuId = muaVuId;
        TongDoanhThu = tongDoanhThu;
        TongChiPhi = tongChiPhi;
    }

    public static BaoCaoMuaVu Create(
        int muaVuId,
        IEnumerable<DoanhThu> doanhThu,
        IEnumerable<ChiPhiCanhTac> chiPhi)
    {
        if (muaVuId <= 0)
            throw new ArgumentException("Mã mùa vụ không hợp lệ.");

        ArgumentNullException.ThrowIfNull(doanhThu);
        ArgumentNullException.ThrowIfNull(chiPhi);

        decimal tongThu = doanhThu
            .Where(x => x.MuaVuId == muaVuId)
            .Sum(x => x.SoTien);

        decimal tongChi = chiPhi
            .Where(x => x.MuaVuId == muaVuId)
            .Sum(x => x.SoTien);

        return new BaoCaoMuaVu(muaVuId, tongThu, tongChi);
    }
}
