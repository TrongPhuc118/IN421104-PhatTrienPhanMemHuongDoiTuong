
namespace SoTayNongNghiep.Domain;

public class NhatKyCanhTac
{
    public int Id { get; private set; }
    public int MuaVuId { get; private set; }
    public DateTime Ngay { get; private set; }
    public string NoiDung { get; private set; }

    private NhatKyCanhTac(
        int id, int muaVuId, DateTime ngay, string noiDung)
    {
        Id = id;
        MuaVuId = muaVuId;
        Ngay = ngay;
        NoiDung = noiDung;
    }

    public static NhatKyCanhTac Create(
        int id, int muaVuId, DateTime ngay,
        string noiDung, DateTime ngayHienTai)
    {
        if (id <= 0 || muaVuId <= 0)
            throw new ArgumentException("Mã nhật ký hoặc mùa vụ không hợp lệ.");

        if (ngay.Date > ngayHienTai.Date)
            throw new ArgumentException("Ngày nhật ký không được ở tương lai.");

        if (string.IsNullOrWhiteSpace(noiDung))
            throw new ArgumentException("Nội dung nhật ký không được để trống.");

        return new NhatKyCanhTac(
            id, muaVuId, ngay, noiDung.Trim());
    }
}
