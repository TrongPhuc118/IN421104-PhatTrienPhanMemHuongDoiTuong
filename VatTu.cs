
namespace SoTayNongNghiep.Domain;

public class VatTu
{
    public int Id { get; private set; }
    public string Ten { get; private set; }
    public string DonViTinh { get; private set; }
    public decimal TonToiThieu { get; private set; }

    private VatTu(
        int id,
        string ten,
        string donViTinh,
        decimal tonToiThieu)
    {
        Id = id;
        Ten = ten;
        DonViTinh = donViTinh;
        TonToiThieu = tonToiThieu;
    }

    public static VatTu Create(
        int id,
        string ten,
        string donViTinh,
        decimal tonToiThieu)
    {
        if (id <= 0)
            throw new ArgumentException("Id phải lớn hơn 0.");

        if (string.IsNullOrWhiteSpace(ten))
            throw new ArgumentException("Tên vật tư không được để trống.");

        if (string.IsNullOrWhiteSpace(donViTinh))
            throw new ArgumentException("Đơn vị tính không được để trống.");

        if (tonToiThieu < 0)
            throw new ArgumentException(
                "Tồn tối thiểu không được âm.");

        return new VatTu(
            id,
            ten.Trim(),
            donViTinh.Trim(),
            tonToiThieu);
    }

    public bool CanNhapThem(decimal soLuong)
    {
        return soLuong > 0;
    }

    public bool DuoiMucTonToiThieu(decimal soLuongTon)
    {
        return soLuongTon < TonToiThieu;
    }
}
