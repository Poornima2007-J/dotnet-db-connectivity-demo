# Course Enrollment Management System

An educational institution automation software to manage student course enrollment workflows. This project features a robust menu-driven architecture built in C# using pure native database connectivity tools.

## 🛠️ Architecture & Technical Stack

- **Application Type:** Command-Line Interface (CLI) Console Application
- **Language Core:** C# (.NET Core / Framework)
- **Database Engine:** Microsoft SQL Server (Relational DB Design)
- **Data Access Layer:** Pure ADO.NET Architecture
- **Operational Safety:** Parameterized Queries (Anti-SQL Injection) & Global Exception Handling

## 📋 Database Schema Layout

### 1. Students Table

| Column Name | Data Type | Key Attribute |
| :--- | :--- | :--- |
| `StudentId` | INT | Primary Key (Identity) |
| `StudentName`| VARCHAR(100) | Not Null |
| `Email` | VARCHAR(100) | - |
| `Department` | VARCHAR(50)  | - |

### 2. Courses Table

| Column Name | Data Type | Key Attribute |
| :--- | :--- | :--- |
| `CourseId` | INT | Primary Key (Identity) |
| `CourseName` | VARCHAR(100) | Not Null |
| `Duration` | INT | - |
| `Fee` | DECIMAL(10,2)| - |

### 3. Enrollments Table

| Column Name | Data Type | Key Attribute |
| :--- | :--- | :--- |
| `EnrollmentId` | INT | Primary Key (Identity) |
| `StudentId` | INT | Foreign Key (References Students) |
| `CourseId` | INT | Foreign Key (References Courses) |
| `EnrollmentDate`| DATE | Default System Date |

---

## 🚀 System Operation Menu

The application executes a recursive control loop providing the following exact structural operations:
1. **Add Student** -> Collects name, email, department and writes safely to DB.
2. **View Students** -> Streams entire student directory via `SqlDataReader`.
3. **Add Course** -> Inputs programmatic metadata including durations and fee limits.
4. **View Courses** -> Displays available educational packages in-system.
5. **Enroll Student in Course** -> Registers transactional data matching student keys to course targets.
6. **View All Enrollments** -> Compiles analytical insights leveraging native `SQL JOIN` scripts.
7. **Search Student Enrollments** -> Filters targeted registration maps for any specific ID block.
8. **Delete Enrollment** -> Revokes registered structural entities safely.
9. **Exit** -> Generates termination codes for the terminal console.

---

## ⚙️ Deployment & Local Setup

1. **Clone & Extract Workspace:**
   ```bash
   git clone https://github.com
   cd student-course-demo
   ```

2. **Database Engine Initialization:**
   - Execute the target setup SQL script against your SQL Server instance to create structural objects.
   - Adjust target backend strings inside the application setup variables:
   ```csharp
   private static string connectionString = "Server=YOUR_INSTANCE;Database=StudentCourseDB;Trusted_Connection=True;";
   ```

3. **Compilation & Execution:**
   - Boot code workspace through your Visual Studio platform IDE.
   - Trigger compiler standard operations via structural short-keys (**`F5`** or **`dotnet run`** commands).
