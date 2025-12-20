# Hướng dẫn sử dụng Fruitkha với Microsoft Visual Studio

## Yêu cầu hệ thống

### Phần mềm cần thiết:
1. **Microsoft Visual Studio 2022** (Community, Professional, hoặc Enterprise)
   - Download tại: https://visualstudio.microsoft.com/vs/

2. **Workloads cần cài đặt trong Visual Studio:**
   - ASP.NET and web development
   - .NET desktop development (khuyến nghị)

3. **SQL Server:**
   - SQL Server LocalDB (đã bao gồm trong Visual Studio)
   - HOẶC SQL Server Express
   - HOẶC SQL Server Developer Edition

### Phiên bản .NET:
- .NET 8.0 SDK (thường đã được cài đặt cùng Visual Studio 2022)

## Cách mở project trong Visual Studio

### Phương pháp 1: Mở Solution File (Khuyến nghị)

1. Mở Visual Studio 2022
2. Chọn **File → Open → Project/Solution**
3. Duyệt đến thư mục project và chọn file `Fruitkha.sln`
4. Visual Studio sẽ tự động load project

### Phương pháp 2: Mở từ File Explorer

1. Duyệt đến thư mục project trong File Explorer
2. Double-click vào file `Fruitkha.sln`
3. Visual Studio sẽ tự động mở

### Phương pháp 3: Clone từ Git trong Visual Studio

1. Mở Visual Studio 2022
2. Chọn **Git → Clone Repository**
3. Nhập URL: `https://github.com/damvm01673-alt/fruitkha.git`
4. Chọn thư mục đích và click **Clone**
5. Sau khi clone xong, Visual Studio sẽ tự động phát hiện và mở solution

## Cấu hình Project

### 1. Restore NuGet Packages

Khi mở project lần đầu, Visual Studio sẽ tự động restore packages. Nếu không:

1. Right-click vào Solution trong **Solution Explorer**
2. Chọn **Restore NuGet Packages**

Hoặc sử dụng Package Manager Console:
```
Update-Package -Reinstall
```

### 2. Cấu hình Connection String

File `appsettings.json` đã có connection string mặc định:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FruitkhaDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

**Nếu sử dụng SQL Server Express**, thay đổi connection string thành:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=FruitkhaDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Database Migration

Application sẽ **tự động tạo database** khi chạy lần đầu thông qua `DbInitializer.cs`.

Nếu cần chạy migration thủ công:

**Sử dụng Package Manager Console** (Tools → NuGet Package Manager → Package Manager Console):
```powershell
Update-Database
```

**Hoặc sử dụng .NET CLI** (trong Terminal):
```bash
dotnet ef database update
```

## Chạy Application trong Visual Studio

### Cách 1: Sử dụng Debug (F5)

1. Đảm bảo **FruitkhaWeb** được chọn làm Startup Project (in bold trong Solution Explorer)
   - Nếu không: right-click vào FruitkhaWeb → **Set as Startup Project**

2. Chọn launch profile từ dropdown trên toolbar:
   - **FruitkhaWeb**: Chạy với Kestrel (HTTPS + HTTP)
   - **IIS Express**: Chạy với IIS Express
   - **https**: Chạy với Kestrel (HTTPS only)
   - **http**: Chạy với Kestrel (HTTP only)

3. Nhấn **F5** hoặc click nút **Play** (▶) màu xanh

4. Browser sẽ tự động mở tại:
   - HTTPS: `https://localhost:7146`
   - HTTP: `http://localhost:5083`
   - IIS Express: `http://localhost:29473` hoặc `https://localhost:44344`

### Cách 2: Chạy không Debug (Ctrl+F5)

- Nhấn **Ctrl+F5** để chạy application mà không attach debugger
- Nhanh hơn khi chỉ cần test giao diện

### Cách 3: Sử dụng Terminal trong Visual Studio

1. Mở **Terminal** (View → Terminal)
2. Chuyển đến thư mục FruitkhaWeb:
   ```bash
   cd FruitkhaWeb
   ```
3. Chạy application:
   ```bash
   dotnet run
   ```

## Debug trong Visual Studio

### Đặt Breakpoint

1. Click vào lề trái (margin) của dòng code cần debug
2. Hoặc đặt con trỏ tại dòng đó và nhấn **F9**
3. Chạy application với **F5**
4. Khi code chạm breakpoint, debugger sẽ dừng lại

### Debug Tools

- **F10**: Step Over (chạy qua function)
- **F11**: Step Into (vào trong function)
- **Shift+F11**: Step Out (thoát function)
- **F5**: Continue
- **Watch Window**: Theo dõi giá trị biến
- **Immediate Window**: Thực thi code trong runtime
- **Locals/Autos**: Xem biến local tự động

## Cấu trúc Project trong Solution Explorer

```
Fruitkha (Solution)
└── FruitkhaWeb (Project)
    ├── Areas
    │   └── Admin
    │       ├── Controllers
    │       └── Views
    ├── Controllers
    ├── Data
    ├── Helpers
    ├── Migrations
    ├── Models
    ├── Properties
    │   └── launchSettings.json
    ├── Views
    │   ├── Home
    │   ├── Products
    │   ├── Cart
    │   ├── Orders
    │   └── Shared
    ├── wwwroot
    │   └── assets
    ├── appsettings.json
    ├── appsettings.Development.json
    └── Program.cs
```

## Thêm Migration mới

Khi thay đổi Models và cần update database:

### Package Manager Console:
```powershell
Add-Migration TenMigration
Update-Database
```

### .NET CLI (Terminal):
```bash
dotnet ef migrations add TenMigration
dotnet ef database update
```

## Build và Publish

### Build Project

- **Build Solution**: Ctrl+Shift+B
- **Rebuild Solution**: Right-click Solution → Rebuild
- **Clean Solution**: Right-click Solution → Clean

### Publish Application

1. Right-click vào **FruitkhaWeb** project
2. Chọn **Publish**
3. Chọn target:
   - **Folder**: Publish to local folder
   - **IIS**: Deploy to IIS server
   - **Azure**: Deploy to Azure App Service
4. Cấu hình settings và click **Publish**

## Các tính năng Visual Studio hữu ích

### 1. IntelliSense
- Auto-complete cho code
- Gợi ý methods và properties
- Hiển thị documentation

### 2. Code Refactoring
- Right-click → **Quick Actions** (Ctrl+.)
- Rename (F2)
- Extract Method/Interface
- Generate Constructor/Properties

### 3. Package Manager
- **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**
- Search và install packages trực tiếp trong UI

### 4. Git Integration
- View → Git Repository
- Git Changes window để commit/push
- Branch management
- Merge conflict resolution

### 5. Database Tools
- **View → SQL Server Object Explorer**
- Xem và quản lý database trực tiếp
- Run queries
- View table data

## Troubleshooting

### Lỗi: "Unable to connect to web server 'IIS Express'"

**Giải pháp:**
1. Đóng Visual Studio
2. Xóa folder `.vs` trong thư mục solution
3. Mở lại Visual Studio

### Lỗi: "Database connection failed"

**Giải pháp:**
1. Kiểm tra SQL Server LocalDB đã được cài đặt:
   ```bash
   sqllocaldb info
   ```
2. Nếu chưa có, tạo instance mới:
   ```bash
   sqllocaldb create MSSQLLocalDB
   sqllocaldb start MSSQLLocalDB
   ```

### Lỗi: "Port already in use"

**Giải pháp:**
1. Thay đổi port trong `launchSettings.json`
2. Hoặc kill process đang dùng port:
   ```bash
   netstat -ano | findstr :7146
   taskkill /PID <PID> /F
   ```

### Build Warnings về Nullable Reference

Project sử dụng nullable reference types. Để tắt warnings:

Thêm vào `FruitkhaWeb.csproj`:
```xml
<PropertyGroup>
  <Nullable>enable</Nullable>
  <NoWarn>$(NoWarn);CS8602;CS8629</NoWarn>
</PropertyGroup>
```

## Tài khoản Admin mặc định

Sau khi chạy application lần đầu, database sẽ được seed với:

- **Email**: admin@fruitkha.com
- **Password**: Admin@123

## Các URL quan trọng

- **Trang chủ**: https://localhost:7146/
- **Đăng nhập**: https://localhost:7146/Identity/Account/Login
- **Admin Panel**: https://localhost:7146/Admin
- **Sản phẩm**: https://localhost:7146/Products
- **Giỏ hàng**: https://localhost:7146/Cart

## Phím tắt Visual Studio hữu ích

- **F5**: Start Debugging
- **Ctrl+F5**: Start Without Debugging
- **Ctrl+Shift+B**: Build Solution
- **Ctrl+K, Ctrl+D**: Format Document
- **Ctrl+.**: Quick Actions
- **F12**: Go to Definition
- **Alt+F12**: Peek Definition
- **Ctrl+Shift+F**: Find in Files
- **Ctrl+T**: Go to All (tìm file/class/method)

## Tài liệu tham khảo

- [Visual Studio Documentation](https://docs.microsoft.com/en-us/visualstudio/)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)

## Hỗ trợ

Nếu gặp vấn đề, vui lòng:
1. Kiểm tra lại requirements
2. Xem troubleshooting section
3. Check GitHub Issues
4. Liên hệ với team phát triển

---

**Lưu ý**: Document này được tạo để hỗ trợ việc sử dụng project với Microsoft Visual Studio. Mọi tính năng đều tương thích 100% với Visual Studio 2022.
