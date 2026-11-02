# SỔ TAY NÔNG NGHIỆP

## 1. Giới thiệu
Sổ Tay Nông Nghiệp là ứng dụng hỗ trợ quản lý mùa vụ, vật tư, nhật ký canh tác, chi phí và doanh thu trong hoạt động nông nghiệp.

## 2. Chức năng nghiệp vụ
- Quản lý danh mục vật tư và chi phí.
- Quản lý mùa vụ.
- Quản lý vật tư và lô vật tư.
- Quản lý nhập kho, xuất kho và điều chỉnh tồn kho.
- Theo dõi nhật ký canh tác.
- Quản lý chi phí canh tác.
- Quản lý doanh thu.
- Tổng hợp báo cáo mùa vụ.

## 3. Công nghệ sử dụng
- C#
- .NET 10
- Object-Oriented Programming
- Visual Studio Code

## 4. Cấu trúc dự án
- `src/SoTayNongNghiep.Domain`: Các lớp nghiệp vụ.
- `src/SoTayNongNghiep.Console`: Chương trình Console.
- `docs`: Tài liệu BT1 và BT2.

## 5. Tài liệu bài tập
- BT1: User Stories – `docs/BT1_User Stories .docx`
- BT2: Sơ đồ lớp – `docs/BT2_So_do_lop.jpg`

## 6. Build và chạy chương trình

```bash
dotnet build SoTayNongNghiep.slnx
dotnet run --project src/SoTayNongNghiep.Console