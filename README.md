# 📱 Phone Service Management System

## 🎯 Overview

Phone Service Management System is a comprehensive web application built with ASP.NET Core MVC 6.0 that streamlines phone repair services, customer requests, and phone model management. The system offers a user-friendly interface for both customers and service administrators to handle repair requests, track repairs, and manage phone inventory.

## ⚡ Key Features

✅ User Authentication & Role-based Authorization  
✅ Phone Model Management & Inventory  
✅ Repair Request Processing & Tracking  
✅ Customer Management  
✅ Service History Tracking  
✅ Admin Dashboard  
✅ Responsive Web Interface  
✅ Automated Role Management

## 🛠️ Built With

- **ASP.NET Core MVC 6.0** - Web Framework
- **Entity Framework Core 6.0** - ORM
- **Microsoft SQL Server** - Database
- **ASP.NET Core Identity** - Authentication & Authorization
- **Razor Views** - View Engine
- **Bootstrap** - Frontend Styling

## 📁 Project Structure

```
PHONE-SERVICE/
├── Controllers/         # MVC Controllers for handling user requests
├── Models/             # Domain & View Models
│   ├── HomeModels/     # Home page view models
│   ├── RepairRequestModels/  # Repair request models
│   ├── UserModels/     # User profile and management models
│   ├── RepairModels/   # Repair service models
│   └── PhoneModelModels/  # Phone inventory models
├── Views/              # Razor Views (UI Templates)
│   ├── Home/          # Home page views
│   ├── Account/       # Authentication views
│   ├── Repair/        # Repair management views
│   ├── PhoneModel/    # Phone model views
│   └── Shared/        # Layout and partial views
├── Data/              # Database Context & Services
├── wwwroot/           # Static Files
│   ├── css/          # Stylesheets
│   ├── js/           # JavaScript files
│   └── images/       # Image assets
└── Migrations/        # Database Migrations
```

## 🚀 Getting Started

### Prerequisites

- **.NET 6.0 SDK**
- **Microsoft SQL Server**
- **Visual Studio 2022** (recommended) or VS Code

### Installation

1️⃣ Clone the Repository

```bash
git clone [your-repository-url]
cd PHONE-SERVICE
```

2️⃣ Update Connection String
Edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_SQL_Server_Connection_String"
  }
}
```

3️⃣ Apply Database Migrations

```bash
Update-Database
```

4️⃣ Build and Run

```bash
dotnet build
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`

## 🔐 Authentication & Authorization

The system implements a robust role-based authentication system using ASP.NET Core Identity:

### User Roles

- **Administrator** - Full system access including:
  - Managing phone models
  - Processing repair requests
  - User management
  - System settings
- **User** - Customer functionality including:
  - Submitting repair requests
  - Tracking repair status
  - Viewing repair history
  - Profile management

### Key Security Features

- Secure Cookie Authentication
- Role-based Authorization
- Secure Password Hashing
- Account Management
- Anti-forgery Token Validation

## 📱 Main Features

### Home Page

- Service overview
- Latest announcements
- Quick access to common functions

### Repair Management

- Create new repair requests
- Track repair status
- View repair history
- Manage repair queue
- Generate repair reports

### Phone Model Management

- Add new phone models
- Update model information
- Manage model inventory
- View model repair history

### User Management

- User registration
- Profile management
- Role assignment (Admin only)
- User activity tracking

## 📦 Dependencies

```xml
<PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="6.0.25" />
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.25" />
<PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="6.0.25" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.25" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="6.0.25" />
```

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
