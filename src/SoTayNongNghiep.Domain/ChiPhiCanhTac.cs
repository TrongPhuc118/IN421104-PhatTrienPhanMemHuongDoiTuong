
namespace SoTayNongNghiep.Domain;

public class ChiPhiCanhTac
{
    public int Id { get; private set; }
    public int MuaVuId { get; private set; }
    public int DanhMucId { get; private set; }
    public decimal SoTien { get; private set; }
    public string GhiChu { get; private set; }
    public DateTime NgayChi { get; private set; }

    private ChiPhiCanhTac(
        int id, int muaVuId, int danhMucId,
        decimal soTien, string ghiChu, DateTime ngayChi)
    {
        Id = id;
        MuaVuId = muaVuId;
        DanhMucId = danhMucId;
        SoTien = soTien;
        GhiChu = ghiChu;
        NgayChi = ngayChi;
    }

    public static ChiPhiCanhTac Create(
        int id, int muaVuId, int danhMucId,
        decimal soTien, string ghiChu, DateTime ngayChi)
    {
        if (id <= 0 || muaVuId <= 0 || danhMucId <= 0)
            throw new ArgumentException("Mã chi phí, mùa vụ hoặc danh mục không hợp lệ.");

        if (soTien <= 0)
            throw new ArgumentException("Số tiền phải lớn hơn 0.");

        return new ChiPhiCanhTac(
            id, muaVuId, danhMucId,
            soTien, ghiChu?.Trim() ?? "", ngayChi);
    }
}
