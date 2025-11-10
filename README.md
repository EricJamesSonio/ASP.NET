
---

# 📘 ASP.NET Backend Overview

### ⚙️ Program.cs — The Main Entry Point

* Acts as the **core setup** of the backend application.
* **Registers routes**, **configures ports**, and **sets up services** (like database and CORS).
* Builds and runs the entire backend server.
* Example responsibilities:

  * Configure **CORS policies**.
  * Register **controllers** and **services**.
  * Set up **database connection** using AppSettings configuration.

---

### 🧩 Controllers — API & Business Logic

* Controllers handle **requests and responses** between the frontend and the database.
* Interact with **Models** and **DbContext** to perform database operations (CRUD).
* Automatically create **API endpoints** based on their names.

  * Example:

    * `UserController` → automatically routes to `/api/user`
* Contain the **business logic** and routing structure for each feature or data model.

---

### 🏗️ Models — Database Tables

* Define the **structure of the database tables**.
* Each model represents one table.
* Contain **fields (properties)** that match the columns in the table.
* Example:

  ```csharp
  public class User {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
  }
  ```

---

### 🗄️ AppDbContext — The Database Connection

* Represents the **database itself**.
* Handles communication between the **controllers** and the **database**.
* Registers all the **models (tables)** you’ve created.
* Example structure:

  ```csharp
  public class AppDbContext : DbContext {
      public DbSet<User> Users { get; set; }
  }
  ```
* Steps:

  1. Create the **DbContext**.
  2. Create **Models** (tables).
  3. Register the models inside **DbContext**.
  4. Use **DbContext** in Controllers to perform CRUD operations.

---

### ⚙️ appsettings.json — Configuration Settings

* Stores **connection strings** and other **application configurations**.
* Example:

  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyDB;User Id=sa;Password=1234;"
  }
  ```
* Includes details such as:

  * Server/localhost
  * Database name
  * Username & password
  * Ports & environment configurations

---

### 🔗 Flow Summary

1. **AppSettings.json** → Holds database connection info.
2. **Program.cs** → Builds and configures everything (DbContext, CORS, Controllers).
3. **AppDbContext** → Represents the actual database and links models as tables.
4. **Models** → Define the structure of each table.
5. **Controllers** → Handle the routes, API logic, and CRUD using the models + DbContext.

---

