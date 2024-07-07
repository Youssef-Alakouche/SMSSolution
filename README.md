**Student Management System API**

---

**Description:**

The Student Management System API is a backend service designed to manage student data, courses, and enrollment using .NET 8 and ASP.NET Core Web API. It provides CRUD operations and uses Entity Framework Core for database interactions. AutoMapper is employed to simplify object-object mapping, ensuring efficient and maintainable code.

---

**Features:**

- **CRUD Operations:** Create, read, update, and delete students, courses, and enrollments.
- **Entity Framework Core:** Seamless database interactions using EF Core with support for SQL Server.
- **AutoMapper:** Simplifies data transfer and mapping between data models and DTOs.
- **Scalable Architecture:** Designed with a focus on scalability and maintainability.

---

**Setup Instructions:**

1. **Clone the Repository:**
   ```
   git clone https://github.com/Youssef-Alakouche/SMSSolution.git
   ```

2. **Navigate to Project Directory:**
   ```
   cd SMSSolution
   ```

3. **Install Dependencies:**
   ```
   dotnet restore
   ```

4. **Database Configuration:**
    - Create a SQL Server database.
    - Update the connection string in `appsettings.json` to point to your SQL Server instance.

5. **Apply Migrations:**
   ```
   dotnet ef database update
   ```

6. **Run the Application:**
   ```
   dotnet run
   ```

7. **Access the API:**
   Open your web browser and navigate to endpoint below in the Usage Section.
   Or Use Postman or any other tool.

---

**Usage:**

1. **Students Management:**
    - `GET http://localhost:3000/api/student` - Retrieve all students.
    - `GET http://localhost:3000/api/student/{id}` - Retrieve a student by ID.
    - `POST http://localhost:3000/api/student` - Create a new student.
    - `DELETE http://localhost:3000/api/student` - Delete a student by ID.

2. **Courses Management:**
    - `GET http://localhost:3000/api/courses` - Retrieve all courses.
    - `POST http://localhost:3000/api/courses` - Create a new course.
    - `GET http://localhost:3000/api/courses/{id}` - Retrieve a course by ID.
    - `DELETE http://localhost:3000/api/courses/{id}` - Delete a course by ID.

3. **Enrollments Management:**
    - `GET http://localhost:3000/api/enrollment` - Retrieve all enrollments.
    - `GET http://localhost:3000/api/enrollment/{id}` - Retrieve enrollment by id.
    - `POST http://localhost:3000/api/enrollment` - Enroll a student in a course.
    - `DELETE http://localhost:3000/api/enrollment` - Remove a student from a course.

---

**Configuration:**

1. **Connection Strings:**
   Update the connection string in `appsettings.json` to match your SQL Server configuration.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
   }
   ```

---

**Contributing:**

Contributions are welcome! If you have any suggestions or improvements, feel free to open an issue or submit a pull request.

