# Fruitkha - Quick Start Guide cho Visual Studio

## 🚀 Bắt đầu nhanh (3 bước)

### Bước 1: Mở Project
```
1. Mở Visual Studio 2022
2. File → Open → Project/Solution
3. Chọn Fruitkha.sln
```

### Bước 2: Restore Packages (tự động)
Visual Studio sẽ tự động restore NuGet packages. Nếu không:
```
Right-click Solution → Restore NuGet Packages
```

### Bước 3: Chạy Application
```
1. Chọn profile: FruitkhaWeb (Kestrel) hoặc IIS Express
2. Nhấn F5 (Debug) hoặc Ctrl+F5 (No Debug)
3. Database sẽ tự động được tạo lần đầu chạy
```

## 🌐 Truy cập Application

### Kestrel:
- **Homepage**: https://localhost:7146
- **Admin**: https://localhost:7146/Admin

### IIS Express:
- **Homepage**: http://localhost:29473
- **Admin**: http://localhost:29473/Admin

## 🔑 Tài khoản Admin

- **Email**: admin@fruitkha.com
- **Password**: Admin@123

## ⌨️ Phím tắt hữu ích

| Phím tắt | Chức năng |
|----------|-----------|
| F5 | Start Debugging |
| Ctrl+F5 | Start Without Debugging |
| Ctrl+Shift+B | Build Solution |
| F9 | Toggle Breakpoint |
| F10 | Step Over |
| F11 | Step Into |
| Ctrl+. | Quick Actions |
| F12 | Go to Definition |

## 📁 Cấu trúc Project

```
Fruitkha.sln                    # Solution file - mở file này
└── FruitkhaWeb/                # Web project
    ├── Areas/Admin/            # Admin area
    ├── Controllers/            # Controllers
    ├── Models/                 # Data models
    ├── Views/                  # Razor views
    ├── wwwroot/               # Static files
    └── Program.cs             # Entry point
```

## 🔧 Cấu hình Database

Connection string mặc định (LocalDB):
```
Server=(localdb)\\mssqllocaldb;Database=FruitkhaDb;Trusted_Connection=true
```

Nếu dùng SQL Server Express, đổi thành:
```
Server=.\\SQLEXPRESS;Database=FruitkhaDb;Trusted_Connection=true
```

File: `appsettings.json`

## 🐛 Debug

1. Click vào lề trái để đặt breakpoint (chấm đỏ)
2. Nhấn F5 để chạy Debug mode
3. Code sẽ dừng tại breakpoint
4. Dùng F10 (Step Over) hoặc F11 (Step Into) để debug

## 📦 Quản lý Packages

### UI:
```
Tools → NuGet Package Manager → Manage NuGet Packages for Solution
```

### Console:
```
Tools → NuGet Package Manager → Package Manager Console
```

## 💾 Database Migration

### Tạo migration mới:
```powershell
Add-Migration TenMigration
```

### Apply migration:
```powershell
Update-Database
```

## ❓ Troubleshooting

### Lỗi: "Unable to connect to database"
```
1. Kiểm tra SQL Server LocalDB: sqllocaldb info
2. Start LocalDB: sqllocaldb start MSSQLLocalDB
```

### Lỗi: "Port already in use"
```
1. Thay đổi port trong launchSettings.json
2. Hoặc kill process: taskkill /PID <PID> /F
```

### Build fails
```
1. Clean Solution: Right-click → Clean
2. Rebuild: Ctrl+Shift+B
3. Restore packages: Right-click → Restore NuGet Packages
```

## 📚 Tài liệu đầy đủ

Xem chi tiết tại:
- **[VISUAL_STUDIO_SETUP.md](./VISUAL_STUDIO_SETUP.md)** - Hướng dẫn đầy đủ
- **[VISUAL_STUDIO_INTEGRATION.md](./VISUAL_STUDIO_INTEGRATION.md)** - Tóm tắt thay đổi
- **[FruitkhaWeb/README.md](./FruitkhaWeb/README.md)** - README project

## ✅ Features

- ✅ Full Visual Studio 2022 support
- ✅ IntelliSense
- ✅ Debugging
- ✅ Git integration
- ✅ NuGet package management
- ✅ Database tools
- ✅ Multiple launch profiles
- ✅ IIS Express + Kestrel

---

**Cần trợ giúp?** Xem [VISUAL_STUDIO_SETUP.md](./VISUAL_STUDIO_SETUP.md) để có hướng dẫn chi tiết hơn.
