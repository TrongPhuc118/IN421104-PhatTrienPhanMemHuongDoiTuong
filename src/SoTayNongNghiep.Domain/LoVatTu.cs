
namespace SoTayNongNghiep.Domain;

public class LoVatTu
{
    public int Id { get; private set; }
    public int VatTuId { get; private set; }
    public DateTime NgayNhap { get; private set; }
    public DateTime? HanSuDung { get; private set; }
    public decimal SoLuongTon { get; private set; }
    public bool DaTieuHuy { get; private set; }

    private LoVatTu(
        int id,
        int vatTuId,
        DateTime ngayNhap,
        DateTime? hanSuDung,
        decimal soLuongTon)
    {
        Id = id;
        VatTuId = vatTuId;
        NgayNhap = ngayNhap;
        HanSuDung = hanSuDung;
        SoLuongTon = soLuongTon;
        DaTieuHuy = false;
    }

    public static LoVatTu Create(
        int id,
        int vatTuId,
        DateTime ngayNhap,
        DateTime? hanSuDung,
        decimal soLuongBanDau)
    {
        if (id <= 0)
            throw new ArgumentException("Id lô phải lớn hơn 0.");

        if (vatTuId <= 0)
            throw new ArgumentException("Mã vật tư không hợp lệ.");

        if (hanSuDung.HasValue && hanSuDung.Value.Date < ngayNhap.Date)
            throw new ArgumentException(
                "Hạn sử dụng không được trước ngày nhập.");

        if (soLuongBanDau <= 0)
            throw new ArgumentException(
                "Số lượng ban đầu phải lớn hơn 0.");

        return new LoVatTu(
            id,
            vatTuId,
            ngayNhap,
            hanSuDung,
            soLuongBanDau);
    }

    public void NhapThem(decimal soLuong)
    {
        if (DaTieuHuy)
            throw new InvalidOperationException(
                "Không thể nhập thêm vào lô đã tiêu hủy.");

        if (soLuong <= 0)
            throw new ArgumentException(
                "Số lượng nhập phải lớn hơn 0.");

        SoLuongTon += soLuong;
    }

    public void Xuat(decimal soLuong)
    {
        if (DaTieuHuy)
            throw new InvalidOperationException(
                "Không thể xuất từ lô đã tiêu hủy.");

        if (soLuong <= 0)
            throw new ArgumentException(
                "Số lượng xuất phải lớn hơn 0.");

        if (soLuong > SoLuongTon)
            throw new InvalidOperationException(
                "Số lượng xuất vượt quá tồn kho.");

        SoLuongTon -= soLuong;
    }

    public bool DaHetHan(DateTime ngayKiemTra)
    {
        return HanSuDung.HasValue
            && HanSuDung.Value.Date < ngayKiemTra.Date;
    }

    public void TieuHuy(DateTime ngayKiemTra)
    {
        if (DaTieuHuy)
            throw new InvalidOperationException(
                "Lô vật tư đã được tiêu hủy.");

        if (!DaHetHan(ngayKiemTra))
            throw new InvalidOperationException(
                "Lô chưa hết hạn, cần xác nhận trước khi tiêu hủy.");

        SoLuongTon = 0;
        DaTieuHuy = true;
    }
}
