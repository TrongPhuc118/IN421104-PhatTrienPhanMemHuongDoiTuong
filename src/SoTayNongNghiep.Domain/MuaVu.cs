
namespace SoTayNongNghiep.Domain;

public class MuaVu
{
    public int Id { get; private set; }
    public string Ten { get; private set; }
    public string GiongCay { get; private set; }
    public DateTime NgayBatDau { get; private set; }
    public DateTime NgayKetThuc { get; private set; }
    public string TrangThai { get; private set; }

    private MuaVu(
        int id,
        string ten,
        string giongCay,
        DateTime ngayBatDau,
        DateTime ngayKetThuc)
    {
        Id = id;
        Ten = ten;
        GiongCay = giongCay;
        NgayBatDau = ngayBatDau;
        NgayKetThuc = ngayKetThuc;
        TrangThai = "Đang diễn ra";
    }

    public static MuaVu Create(
        int id,
        string ten,
        string giongCay,
        DateTime ngayBatDau,
        DateTime ngayKetThuc)
    {
        if (id <= 0)
            throw new ArgumentException("Id phải lớn hơn 0.");

        if (string.IsNullOrWhiteSpace(ten))
            throw new ArgumentException("Tên mùa vụ không được để trống.");

        if (string.IsNullOrWhiteSpace(giongCay))
            throw new ArgumentException("Giống cây không được để trống.");

        if (ngayKetThuc <= ngayBatDau)
            throw new ArgumentException(
                "Ngày kết thúc phải sau ngày bắt đầu.");

        return new MuaVu(
            id,
            ten.Trim(),
            giongCay.Trim(),
            ngayBatDau,
            ngayKetThuc);
    }
}
