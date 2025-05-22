# 👥 PeopleHub - Human Resource Management System

PeopleHub is a desktop-based **Human Resource Management System (HRMS)** developed in **C#** using **Windows Forms** and enhanced with **DevExpress components** such as XtraReports and advanced UI controls. It uses **SQL Server** for database management (via SSMS) and is packaged using the **Visual Studio Installer (VSI) bundle** for easy deployment.

> ⚠️ **Note:** The project may not be fully compatible with certain versions of Visual Studio or SQL Server due to dependencies on specific DevExpress and installer tools.

---

## 🧩 Features

- 🧑‍💼 Employee Records Management  
- 🗓️ Leave & Attendance Tracking  
- 📊 Custom Reporting via **XtraReports**  
- 🗂️ Department and Role-Based Organization  
- 💵 Payroll Information Display  
- 🔐 Login-based Access Control (Admin/User)  
- 📦 MSI Installer support using Visual Studio Installer Projects

---

## 🛠️ Built With

| Technology                    | Description                                       |
|------------------------------|---------------------------------------------------|
| `C# (.NET Framework)`        | Core backend and logic                           |
| `Windows Forms`              | User interface layer                             |
| `DevExpress`                 | Enhanced controls and reporting tools            |
| `XtraReports`                | Custom dynamic report generation                 |
| `SQL Server` (via SSMS)      | Backend database management                      |
| `Visual Studio Installer`    | MSI-based bundling and deployment tool           |

---

## 🖥️ Requirements

- 🧰 **Visual Studio 2019 or later** (with DevExpress extension installed)
- 🖼️ **.NET Framework 4.7.2+**
- 🗄️ **SQL Server 2017 or newer**
- 🧪 **SQL Server Management Studio (SSMS)**
- 📦 **Visual Studio Installer Projects Extension**

> ⚠️ Make sure to install the correct version of DevExpress that matches the one used in the project.

---

## 📦 Installation Guide

🔧 1. Clone the Repository
-bash
git clone https://github.com/yourusername/peoplehub-hrms.git
cd peoplehub-hrms

🖥️ 2. Open with Visual Studio
Open the .sln file using Visual Studio.

Ensure all required NuGet packages and DevExpress dependencies are restored.

🗃️ 3. Configure the Database
Use SQL Server Management Studio (SSMS) to restore or manually create the database.

Update the App.config or Settings.settings file with your SQL Server connection string:
<connectionStrings>
  <add name="PeopleHubConnection" connectionString="Data Source=YOUR_SERVER;Initial Catalog=PeopleHubDB;Integrated Security=True" />
</connectionStrings>

🛠️ 4. Build and Run the Project
Compile the project (Ctrl+Shift+B).

Start debugging or run the application directly.

📦 5. Generate Installer (Optional)
Open the VSI (Installer) project inside the solution.

Right-click → Build to generate .msi installer.

---

## 📘 Notes
This app uses DevExpress controls—you must have the licensed or trial version installed.

The project may not build on newer Visual Studio editions without updating the Installer Project extension and DevExpress references.

Make sure SQL Server is properly configured to allow connections.

---

## 📫 Contact
Developer: Adzyl Hilary A. Jipos

Email: adzyl.jipos@gmail.com

GitHub: @dev-aziii

