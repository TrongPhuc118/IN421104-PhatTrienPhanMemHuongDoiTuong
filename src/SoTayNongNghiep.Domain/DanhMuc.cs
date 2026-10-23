
namespace SoTayNongNghiep.Domain;

public class DanhMuc
{
    public int Id { get; private set; }
    public string Ten { get; private set; }
    public string Loai { get; private set; }

    private DanhMuc(int id, string ten, string loai)
    {
        Id = id;
        Ten = ten;
        Loai = loai;
    }

    public static DanhMuc Create(int id, string ten, string loai)
    {
        if (id <= 0)
            throw new ArgumentException("Id phải lớn hơn 0.");

        if (string.IsNullOrWhiteSpace(ten))
            throw new ArgumentException("Tên danh mục không được để trống.");

        if (loai != "Vật tư" && loai != "Chi phí")
            throw new ArgumentException(
                "Loại danh mục phải là Vật tư hoặc Chi phí.");

        return new DanhMuc(id, ten.Trim(), loai);
    }
}
