
namespace SoTayNongNghiep.Domain;

public enum LoaiGiaoDichKho
{
    Nhap,
    Xuat,
    DieuChinh,
    TieuHuy
}

public class GiaoDichKho
{
    public int Id { get; private set; }
    public int LoVatTuId { get; private set; }
    public LoaiGiaoDichKho Loai { get; private set; }
    public decimal SoLuong { get; private set; }
    public string LyDo { get; private set; }
    public DateTime NgayTao { get; private set; }

    private GiaoDichKho(
        int id, int loVatTuId, LoaiGiaoDichKho loai,
        decimal soLuong, string lyDo, DateTime ngayTao)
    {
        Id = id;
        LoVatTuId = loVatTuId;
        Loai = loai;
        SoLuong = soLuong;
        LyDo = lyDo;
        NgayTao = ngayTao;
    }

    public static GiaoDichKho Create(
        int id, int loVatTuId, LoaiGiaoDichKho loai,
        decimal soLuong, string lyDo, DateTime ngayTao)
    {
        if (id <= 0 || loVatTuId <= 0)
            throw new ArgumentException("Mã giao dịch hoặc mã lô không hợp lệ.");

        if (!Enum.IsDefined(loai))
            throw new ArgumentException("Loại giao dịch không hợp lệ.");

        if (soLuong <= 0)
            throw new ArgumentException("Số lượng phải lớn hơn 0.");

        if (loai == LoaiGiaoDichKho.DieuChinh &&
            string.IsNullOrWhiteSpace(lyDo))
            throw new ArgumentException("Điều chỉnh phải có lý do.");

        return new GiaoDichKho(
            id, loVatTuId, loai, soLuong,
            lyDo?.Trim() ?? "", ngayTao);
    }
}
