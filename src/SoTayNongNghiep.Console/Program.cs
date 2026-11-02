
using SoTayNongNghiep.Domain;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("==================================");
Console.WriteLine("   SO TAY NONG NGHIEP - DEMO");
Console.WriteLine("==================================");

// 1. Tạo danh mục
var danhMucVatTu = DanhMuc.Create(1, "Phân bón", "Vật tư");
var danhMucChiPhi = DanhMuc.Create(2, "Nhân công", "Chi phí");

Console.WriteLine("\n1. DANH MUC");
Console.WriteLine($"{danhMucVatTu.Ten} - {danhMucVatTu.Loai}");
Console.WriteLine($"{danhMucChiPhi.Ten} - {danhMucChiPhi.Loai}");

// 2. Tạo mùa vụ
var muaVu = MuaVu.Create(
    1,
    "Mùa vụ Đông Xuân",
    "Lúa ST25",
    new DateTime(2026, 1, 1),
    new DateTime(2026, 6, 30));

Console.WriteLine("\n2. MUA VU");
Console.WriteLine($"Tên: {muaVu.Ten}");
Console.WriteLine($"Giống: {muaVu.GiongCay}");
Console.WriteLine($"Trạng thái: {muaVu.TrangThai}");

// 3. Tạo vật tư và lô vật tư
var vatTu = VatTu.Create(1, "Phân NPK", "Kg", 20);

var loVatTu = LoVatTu.Create(
    1,
    vatTu.Id,
    DateTime.Today,
    DateTime.Today.AddMonths(6),
    100);

Console.WriteLine("\n3. VAT TU");
Console.WriteLine($"{vatTu.Ten}: {loVatTu.SoLuongTon} {vatTu.DonViTinh}");

// 4. Nhập kho
loVatTu.NhapThem(50);

var giaoDichNhap = GiaoDichKho.Create(
    1,
    loVatTu.Id,
    LoaiGiaoDichKho.Nhap,
    50,
    "Nhập thêm phân",
    DateTime.Now);

Console.WriteLine("\n4. NHAP KHO");
Console.WriteLine($"Số lượng nhập: {giaoDichNhap.SoLuong}");
Console.WriteLine($"Tồn kho: {loVatTu.SoLuongTon}");

// 5. Xuất kho
loVatTu.Xuat(30);

var giaoDichXuat = GiaoDichKho.Create(
    2,
    loVatTu.Id,
    LoaiGiaoDichKho.Xuat,
    30,
    "Bón phân",
    DateTime.Now);

Console.WriteLine("\n5. XUAT KHO");
Console.WriteLine($"Số lượng xuất: {giaoDichXuat.SoLuong}");
Console.WriteLine($"Tồn kho còn: {loVatTu.SoLuongTon}");

// 6. Nhật ký canh tác
var nhatKy = NhatKyCanhTac.Create(
    1,
    muaVu.Id,
    DateTime.Today,
    "Bón phân đợt 1",
    DateTime.Today);

Console.WriteLine("\n6. NHAT KY");
Console.WriteLine($"{nhatKy.Ngay:dd/MM/yyyy}: {nhatKy.NoiDung}");

// 7. Chi phí
var chiPhi = ChiPhiCanhTac.Create(
    1,
    muaVu.Id,
    danhMucChiPhi.Id,
    500000,
    "Thuê nhân công",
    DateTime.Today);

Console.WriteLine("\n7. CHI PHI");
Console.WriteLine($"{chiPhi.SoTien:N0} VND");

// 8. Doanh thu
var doanhThu = DoanhThu.Create(
    1,
    muaVu.Id,
    "Nguyễn Văn A",
    1500000,
    "Bán lúa",
    DateTime.Today);

Console.WriteLine("\n8. DOANH THU");
Console.WriteLine($"{doanhThu.SoTien:N0} VND");

// 9. Báo cáo mùa vụ
var baoCao = BaoCaoMuaVu.Create(
    muaVu.Id,
    new List<DoanhThu> { doanhThu },
    new List<ChiPhiCanhTac> { chiPhi });

Console.WriteLine("\n9. BAO CAO MUA VU");
Console.WriteLine($"Tổng doanh thu: {baoCao.TongDoanhThu:N0} VND");
Console.WriteLine($"Tổng chi phí: {baoCao.TongChiPhi:N0} VND");
Console.WriteLine($"Lợi nhuận: {baoCao.LoiNhuan:N0} VND");
Console.WriteLine($"Kết quả: {baoCao.KetQua}");

Console.WriteLine("\n==================================");
Console.WriteLine("DEMO HOAN THANH");
Console.WriteLine("==================================");
