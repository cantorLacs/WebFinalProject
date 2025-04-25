# Property Rental Management System (PRMS)

## Course Information
- **Course Number**: 420-DW4-AS  
- **Course Title**: Web Server Applications Development II  
- **Session**: Winter 2025  
- **Group**: 6950  
- **Due Date**: 24/04/2025  

## Author
- **Student**: Luis Antonio Cantor  
- **Student ID**: 2234228  
- **Teacher**: Quang Hoang Cao  

---

## 📌 Project Description
A web-based property management system developed using ASP.NET Core that facilitates the management of residential properties. The system allows interaction between property owners, managers, and tenants, with features for apartment listings, appointment scheduling, and internal messaging.

---

## 🛠 Project Development

### Phase I: Project Analysis

#### Requirements Analysis
- Multi-user system with role-based access (Owner, Manager, Tenant)
- Property management (Buildings and Apartments)
- Appointment scheduling
- Internal messaging
- Secure authentication/authorization
- Responsive web interface

#### Technical Requirements
- ASP.NET Core with Razor Pages
- SQL Server with Entity Framework Core
- Bootstrap for responsive design
- Cookie-based authentication
- Form validation and data protection

---

### Phase II: Design

#### Database Design
- `Users` table (role-based)
- `Buildings` and `Apartments` tables
- `Appointments` table
- `Messages` table

- ![image](https://github.com/user-attachments/assets/cd08626e-2a85-4b45-b669-262c061211be)


#### Application Architecture

**Presentation Layer** (`Pages/`)
- Razor Pages per feature:
  - Apartments & Search
  - Buildings & Search
  - Appointments
  - Messages
  - Authentication (Login, Register, Logout)
- Shared layouts and Bootstrap-based UI

**Business Logic Layer**
- Page Models (`.cshtml.cs`)
- Authorization handlers
- Input validation
- Business logic

**Data Layer**
- `Models/`:
  - `User.cs`, `Building.cs`, `Apartment.cs`, `Appointment.cs`, `Message.cs`
- `Data/FinalProjectContext.cs` (DbContext)
- `Migrations/` for schema versioning

**Infrastructure**
- Cookie-based authentication
- Role-based access control
- Static file serving (`wwwroot/`)
- App configuration (`appsettings.json`)

![image](https://github.com/user-attachments/assets/8cc80ae0-388b-4e0a-804f-0a966173f00c)


---

### Phase III: Implementation

#### Core Features Implemented
- Code-first approach using ASP.NET Core MVC
- Dependency management with NuGet
- Database operations using EF Core
- Scaffolded Razor Pages with CRUD
- Features:
  - User auth & authorization
  - Building/apartment management
  - Appointment scheduling
  - Messaging
  - Search & filtering

#### Technical Highlights
- Secure cookie-based authentication
- Model validation with annotations
- Responsive UI using Bootstrap
- Role-based access control
- EF Core Migrations

---

### Phase IV: Testing

| User Type | Functional Requirement                        | Test Result |
|-----------|-----------------------------------------------|-------------|
| Owner     | Manage managers and tenants                   | ✅ Passed   |
| Manager   | Manage building appointments                  | ✅ Passed   |
| Manager   | Manage apartments                             | ✅ Passed   |
| Manager   | Manage appointments                           | ✅ Passed   |
| Tenant    | View available apartments                     | ✅ Passed   |
| Tenant    | Schedule visits                               | ✅ Passed   |
| Tenant    | View apartment details                        | ✅ Passed   |
| All Users | Messaging system                              | ✅ Passed   |
| All Users | Authentication and authorization              | ✅ Passed   |

---

## ✅ Features Overview
- 🔐 Authentication system
- 🧭 Navigation based on user role
- 🗂 Building & Apartment management views
- 🗓 Appointment system
- 💬 Messaging system

---

## 📚 Conclusion
Through this project, I gained experience in:
- Full-stack ASP.NET Core development
- Secure authentication & authorization
- Database management with EF Core
- Responsive UI with Razor Pages + Bootstrap
- Real-world property management logic
- Git version control & documentation best practices

---

## 📖 Bibliography
1. [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core)
2. [Entity Framework Core Docs](https://docs.microsoft.com/en-us/ef/core/)
3. [Bootstrap Docs](https://getbootstrap.com/docs)
4. [Razor Pages Docs](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/)
