
namespace SoTayNongNghiep.Domain;

public class DoanhThu
{
    public int Id { get; private set; }
    public int MuaVuId { get; private set; }
    public string TenThuongLai { get; private set; }
    public decimal SoTien { get; private set; }
    public string GhiChu { get; private set; }
    public DateTime NgayBan { get; private set; }

    private DoanhThu(
        int id, int muaVuId, string tenThuongLai,
        decimal soTien, string ghiChu, DateTime ngayBan)
    {
        Id = id;
        MuaVuId = muaVuId;
        TenThuongLai = tenThuongLai;
        SoTien = soTien;
        GhiChu = ghiChu;
        NgayBan = ngayBan;
    }

    public static DoanhThu Create(
        int id, int muaVuId, string tenThuongLai,
        decimal soTien, string ghiChu, DateTime ngayBan)
    {
        if (id <= 0 || muaVuId <= 0)
            throw new ArgumentException("Mã doanh thu hoặc mùa vụ không hợp lệ.");

        if (string.IsNullOrWhiteSpace(tenThuongLai))
            throw new ArgumentException("Tên thương lái không được để trống.");

        if (soTien <= 0)
            throw new ArgumentException("Số tiền phải lớn hơn 0.");

        return new DoanhThu(
            id, muaVuId, tenThuongLai.Trim(),
            soTien, ghiChu?.Trim() ?? "", ngayBan);
    }
}
