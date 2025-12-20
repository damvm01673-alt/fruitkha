# Fruitkha E-commerce Web Application

> Ứng dụng bán trái cây tươi được xây dựng với ASP.NET Core MVC

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?logo=visual-studio)](https://visualstudio.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4)](https://learn.microsoft.com/en-us/aspnet/core/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-8.0-512BD4)](https://learn.microsoft.com/en-us/ef/core/)

## 📋 Mục lục

- [Giới thiệu](#giới-thiệu)
- [Công nghệ](#công-nghệ)
- [Tính năng](#tính-năng)
- [Bắt đầu nhanh](#bắt-đầu-nhanh)
- [Tài liệu](#tài-liệu)
- [Cấu trúc project](#cấu-trúc-project)

## 🎯 Giới thiệu

Fruitkha là ứng dụng web e-commerce hoàn chỉnh để bán trái cây tươi, được xây dựng với ASP.NET Core MVC. Project bao gồm:

- 🛒 Hệ thống giỏ hàng và thanh toán
- 👤 Xác thực người dùng (ASP.NET Identity)
- 🔐 Phân quyền Admin
- 📦 Quản lý sản phẩm và danh mục
- 💾 Entity Framework Core + SQL Server
- 🎨 Giao diện responsive với Bootstrap

## 🛠 Công nghệ

- **Backend**: ASP.NET Core 8.0 MVC
- **ORM**: Entity Framework Core 8.0
- **Database**: SQL Server (LocalDB/Express)
- **Authentication**: ASP.NET Core Identity
- **Frontend**: Razor Views, Bootstrap 5
- **Query**: LINQ

## ✨ Tính năng

### Khách hàng:
- ✅ Xem danh mục và sản phẩm
- ✅ Tìm kiếm sản phẩm
- ✅ Giỏ hàng (Session-based)
- ✅ Đặt hàng và thanh toán
- ✅ Xem lịch sử đơn hàng
- ✅ Đăng ký/Đăng nhập

### Quản trị viên (Admin):
- ✅ Quản lý danh mục (CRUD)
- ✅ Quản lý sản phẩm (CRUD)
- ✅ Quản lý đơn hàng
- ✅ Dashboard

## 🚀 Bắt đầu nhanh

### Yêu cầu:
- ✅ Visual Studio 2022 (Community/Professional/Enterprise)
- ✅ .NET 8.0 SDK
- ✅ SQL Server LocalDB (included with Visual Studio)

### 3 bước đơn giản:

#### 1️⃣ Clone repository
```bash
git clone https://github.com/damvm01673-alt/fruitkha.git
cd fruitkha
```

#### 2️⃣ Mở trong Visual Studio
```
Double-click vào Fruitkha.sln
```

#### 3️⃣ Chạy application
```
Nhấn F5 hoặc Ctrl+F5
```

### URLs:
- **Trang chủ**: https://localhost:7146
- **Admin**: https://localhost:7146/Admin
- **Đăng nhập**: https://localhost:7146/Identity/Account/Login

### Tài khoản Admin mặc định:
```
Email: admin@fruitkha.com
Password: Admin@123
```

## 📚 Tài liệu

| Tài liệu | Mô tả |
|----------|-------|
| **[QUICKSTART.md](./QUICKSTART.md)** | 🚀 Hướng dẫn khởi động nhanh |
| **[VISUAL_STUDIO_SETUP.md](./VISUAL_STUDIO_SETUP.md)** | 📖 Hướng dẫn chi tiết Visual Studio |
| **[VISUAL_STUDIO_INTEGRATION.md](./VISUAL_STUDIO_INTEGRATION.md)** | ✨ Tóm tắt tích hợp Visual Studio |
| **[IMPLEMENTATION_SUMMARY.md](./IMPLEMENTATION_SUMMARY.md)** | 📋 Tổng quan triển khai |
| **[FruitkhaWeb/README.md](./FruitkhaWeb/README.md)** | 📄 README project |

### 🎓 Tài liệu khuyến nghị:

- **Mới bắt đầu?** → Đọc [QUICKSTART.md](./QUICKSTART.md)
- **Dùng Visual Studio?** → Đọc [VISUAL_STUDIO_SETUP.md](./VISUAL_STUDIO_SETUP.md)
- **Muốn hiểu chi tiết?** → Đọc [IMPLEMENTATION_SUMMARY.md](./IMPLEMENTATION_SUMMARY.md)

## 📁 Cấu trúc Project

```
fruitkha/
├── Fruitkha.sln                          # ⭐ Visual Studio Solution
├── FruitkhaWeb/                          # 📦 Main Web Project
│   ├── Areas/Admin/                      # Admin area
│   │   ├── Controllers/
│   │   └── Views/
│   ├── Controllers/                      # MVC Controllers
│   │   ├── HomeController.cs
│   │   ├── ProductsController.cs
│   │   ├── CartController.cs
│   │   └── OrdersController.cs
│   ├── Models/                          # Entity Models
│   │   ├── Category.cs
│   │   ├── Product.cs
│   │   ├── Order.cs
│   │   └── OrderItem.cs
│   ├── Views/                           # Razor Views
│   ├── Data/                            # DbContext
│   ├── Migrations/                      # EF Migrations
│   ├── wwwroot/                         # Static files
│   ├── Program.cs                       # Entry point
│   └── appsettings.json                 # Configuration
├── QUICKSTART.md                        # 🚀 Quick start guide
├── VISUAL_STUDIO_SETUP.md               # 📖 VS setup guide
└── IMPLEMENTATION_SUMMARY.md            # 📋 Implementation details
```

## 🔧 Cấu hình

### Connection String

File: `FruitkhaWeb/appsettings.json`

**LocalDB (default):**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FruitkhaDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

**SQL Server Express:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=FruitkhaDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### Database

Database sẽ **tự động được tạo** khi chạy application lần đầu với:
- ✅ 4 categories mẫu
- ✅ 6 products mẫu
- ✅ Admin và Customer roles
- ✅ 1 Admin user

## 🎯 Launch Profiles (Visual Studio)

| Profile | Server | URLs |
|---------|--------|------|
| **FruitkhaWeb** | Kestrel | https://localhost:7146, http://localhost:5083 |
| **IIS Express** | IIS Express | http://localhost:29473, https://localhost:44344 |
| **https** | Kestrel | https://localhost:7146 |
| **http** | Kestrel | http://localhost:5083 |

## 🧪 Testing

### Build
```bash
dotnet build Fruitkha.sln
```

### Run
```bash
cd FruitkhaWeb
dotnet run
```

### Migrations
```bash
# Package Manager Console (Visual Studio)
Add-Migration MigrationName
Update-Database

# .NET CLI
dotnet ef migrations add MigrationName
dotnet ef database update
```

## 📸 Screenshots

### Trang chủ
![Homepage](https://via.placeholder.com/800x400?text=Homepage+Screenshot)

### Admin Panel
![Admin](https://via.placeholder.com/800x400?text=Admin+Panel+Screenshot)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📝 License

This project is for educational purposes.

## 👨‍💻 Author

Developed for ASP.NET Core MVC course

## 🆘 Support

Nếu gặp vấn đề:
1. Xem [VISUAL_STUDIO_SETUP.md](./VISUAL_STUDIO_SETUP.md) - Phần Troubleshooting
2. Kiểm tra Issues trên GitHub
3. Tạo Issue mới nếu cần

## ⭐ Features Highlights

- ✅ **100% Visual Studio Compatible** - Mở và chạy ngay
- ✅ **Entity Framework Code-First** - Database migrations
- ✅ **LINQ Queries** - Type-safe data access
- ✅ **Identity Authentication** - Secure user management
- ✅ **Role-based Authorization** - Admin/Customer roles
- ✅ **Session Management** - Shopping cart
- ✅ **Responsive Design** - Bootstrap 5
- ✅ **Vietnamese Language** - Full Vietnamese UI

## 📈 Project Status

✅ **Completed and Production Ready**

All features implemented and tested:
- ✅ Database design & migrations
- ✅ Entity Framework with LINQ
- ✅ Homepage with categories & products
- ✅ Product listing & details
- ✅ Shopping cart & checkout
- ✅ Order management
- ✅ Admin panel (CRUD operations)
- ✅ Authentication & Authorization
- ✅ Visual Studio integration

---

<div align="center">

**[🚀 Quick Start](./QUICKSTART.md)** • **[📖 Documentation](./VISUAL_STUDIO_SETUP.md)** • **[💡 Issues](https://github.com/damvm01673-alt/fruitkha/issues)**

Made with ❤️ using ASP.NET Core & Visual Studio

</div>
