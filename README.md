#  Electricity Billing System

A Windows Forms desktop application for managing electricity billing. Designed for utility companies or housing societies to handle customer data, consumption records, bill generation, payments, and reports – with role‑based access (Admin / User).

![C#](https://img.shields.io/badge/C%23-10.0-blue)
![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![Windows Forms](https://img.shields.io/badge/UI-WinForms-0078d7)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)
![License](https://img.shields.io/badge/License-MIT-green)

---

##  Features

### Admin
- Manage customers (CRUD)
- Record consumption (units per customer/date)
- Generate bills automatically (rate: Rs. 10/unit)
- Process payments – updates bill status
- View reports (customer bills, payment history, unpaid bills)
- Manage system users (Admin / User roles)

### User (Customer Portal)
- View account summary (profile, amount due, due date)
- Browse monthly bills
- Pay outstanding bills online (within the app)
- See payment history

---

##  Technologies Used

- **C# 10** – logic and forms
- **.NET 10.0** – framework
- **Windows Forms** – GUI
- **Microsoft.Data.SqlClient** – database access
- **Microsoft SQL Server** – backend database

---

##  Prerequisites

- Windows 10 / 11
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) (or Visual Studio 2022 with .NET 10 workload)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express edition is fine)
- [Git](https://git-scm.com/) (optional, for cloning)

---

##  Setup Instructions

### 1. Clone the repository
```bash
git clone https://github.com/sammar-abbas-shah/ElectricityBillingSystem.git
