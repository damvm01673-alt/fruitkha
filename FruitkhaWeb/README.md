# Fruitkha E-commerce Web Application

## Giới thiệu
Fruitkha là ứng dụng web bán trái cây tươi được xây dựng bằng ASP.NET Core MVC với Entity Framework và ASP.NET Identity.

## Công nghệ sử dụng
- **ASP.NET Core 8.0 MVC**
- **Entity Framework Core** - ORM và quản lý database
- **ASP.NET Core Identity** - Xác thực và phân quyền
- **SQL Server** - Database
- **LINQ** - Truy vấn dữ liệu
- **Bootstrap** - Giao diện responsive

## Tính năng chính

### Phía khách hàng:
1. **Trang chủ**: 
   - Hiển thị danh sách phân loại sản phẩm (categories)
   - Sản phẩm mới nhất
   - Sản phẩm khuyến mãi

2. **Quản lý sản phẩm**:
   - Xem danh sách sản phẩm theo danh mục
   - Xem chi tiết sản phẩm
   - Tìm kiếm sản phẩm

3. **Giỏ hàng**:
   - Thêm/xóa/cập nhật sản phẩm trong giỏ hàng
   - Quản lý giỏ hàng bằng Session

4. **Đặt hàng**:
   - Thanh toán và tạo đơn hàng
   - Xem lịch sử đơn hàng

5. **Xác thực**:
   - Đăng ký tài khoản
   - Đăng nhập/Đăng xuất

### Phía quản trị (Admin):
1. **Quản lý danh mục**: CRUD operations (Create, Read, Update, Delete)
2. **Quản lý sản phẩm**: CRUD operations
3. **Quản lý đơn hàng**: Xem và cập nhật trạng thái đơn hàng

## Cấu trúc Database

### Tables:
- **Categories**: Danh mục sản phẩm
- **Products**: Sản phẩm
- **Orders**: Đơn hàng
- **OrderItems**: Chi tiết đơn hàng
- **AspNetUsers**: Người dùng (Identity)
- **AspNetRoles**: Vai trò (Identity)

## Cài đặt và chạy ứng dụng

### Yêu cầu:
- .NET 8.0 SDK
- SQL Server (LocalDB hoặc SQL Server Express)
- **Microsoft Visual Studio 2022** (khuyến nghị) hoặc VS Code

### Cách 1: Chạy với Microsoft Visual Studio 2022 (Khuyến nghị)

1. **Clone repository**:
```bash
git clone https://github.com/damvm01673-alt/fruitkha.git
```

2. **Mở solution trong Visual Studio**:
   - Mở Visual Studio 2022
   - File → Open → Project/Solution
   - Chọn file `Fruitkha.sln` trong thư mục root của repository

3. **Restore packages**:
   - Visual Studio sẽ tự động restore NuGet packages
   - Hoặc: Right-click Solution → Restore NuGet Packages

4. **Chạy application**:
   - Chọn launch profile: **FruitkhaWeb** hoặc **IIS Express**
   - Nhấn **F5** (Debug) hoặc **Ctrl+F5** (Without Debug)
   - Database sẽ tự động được tạo và seed data lần đầu chạy

5. **Truy cập ứng dụng**:
   - Kestrel: https://localhost:7146 hoặc http://localhost:5083
   - IIS Express: http://localhost:29473 hoặc https://localhost:44344
   - Trang Admin: https://localhost:7146/Admin

📖 **Xem hướng dẫn chi tiết**: [VISUAL_STUDIO_SETUP.md](../VISUAL_STUDIO_SETUP.md)

### Cách 2: Chạy với .NET CLI

1. **Clone repository**:
```bash
git clone https://github.com/damvm01673-alt/fruitkha.git
cd fruitkha/FruitkhaWeb
```

2. **Cấu hình connection string** (nếu cần):
Mở file `appsettings.json` và cập nhật connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FruitkhaDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

3. **Restore packages**:
```bash
dotnet restore
```

4. **Apply database migrations** (tự động chạy khi khởi động):
Ứng dụng sẽ tự động:
- Tạo database
- Apply migrations
- Seed dữ liệu mẫu
- Tạo Admin user

5. **Chạy ứng dụng**:
```bash
dotnet run
```

6. **Truy cập ứng dụng**:
- Trang chủ: https://localhost:7146 hoặc http://localhost:5083
- Trang Admin: https://localhost:7146/Admin

## Tài khoản Admin mặc định

**Email**: admin@fruitkha.com  
**Mật khẩu**: Admin@123

## Dữ liệu mẫu

Database sẽ được seed với:
- 4 danh mục sản phẩm
- 6 sản phẩm mẫu
- 1 tài khoản Admin

## Cấu trúc thư mục

```
FruitkhaWeb/
├── Areas/
│   └── Admin/              # Admin area
│       ├── Controllers/    # Admin controllers
│       └── Views/          # Admin views
├── Controllers/            # Main controllers
├── Data/                   # DbContext
├── Helpers/               # Helper classes
├── Migrations/            # EF migrations
├── Models/                # Entity models
├── Views/                 # Razor views
│   ├── Home/
│   ├── Products/
│   ├── Cart/
│   ├── Orders/
│   └── Shared/
└── wwwroot/               # Static files (CSS, JS, images)
```

## Chức năng đã thực hiện

✅ Thiết kế và tạo database với Entity Framework  
✅ Kết nối CSDL và sử dụng LINQ  
✅ Trang chủ hiển thị categories và product groups  
✅ Trang hiển thị sản phẩm theo danh mục  
✅ Trang chi tiết sản phẩm  
✅ Đăng ký/Đăng nhập (ASP.NET Identity)  
✅ Quản lý danh mục (CRUD)  
✅ Quản lý sản phẩm (CRUD)  
✅ Giỏ hàng và đặt hàng  
✅ Tất cả file HTML đã được chuyển sang Razor views  

## Lưu ý

- Ứng dụng sử dụng Session để quản lý giỏ hàng
- Identity được cấu hình với password đơn giản (tối thiểu 6 ký tự) để dễ test
- Giao diện giữ nguyên template Fruitkha đã được phân công
- Hỗ trợ Vietnamese (Tiếng Việt) trong giao diện

## Tác giả
Project được phát triển cho môn học ASP.NET Core MVC
