# 🛒 ShopEZ.API – E-Commerce Backend API

A complete **E-Commerce Backend API** built using **ASP.NET Core Web API (.NET 8)**, **Entity Framework Core**, and **SQL Server**.

This project simulates an online shopping system where:

* Users can browse products & place orders
* Admin can manage products & inventory

---

## 🚀 Features

* 🔐 JWT Authentication & Authorization
* 👤 User Registration & Login
* 👑 Admin Role (Seeded in Database)
* 🛍️ Product Management (CRUD)
* 📦 Order Management with Stock Validation
* 🔄 Transaction Handling (Rollback Support)
* 🔍 Search, Filter & Pagination
* 🛡️ Role-Based Authorization (Admin/User)
* 📘 Swagger Documentation
* 📬 Postman Collection Included

---

## 🏗️ Architecture

```plaintext
Controller → Service → Repository → DbContext
```

---

## 📂 Project Structure

```plaintext
ShopEZ.API/
│
├── Controllers/
├── Services/
├── Repositories/
├── DTOs/
├── Models/
├── Data/
├── Middleware/
├── Helpers/
└── Program.cs
```

---

## 🧱 Technologies Used

* ASP.NET Core Web API (.NET 8)
* Entity Framework Core
* SQL Server (Express)
* JWT Authentication
* BCrypt Password Hashing
* Swagger (Swashbuckle)
* Postman (API Testing)

---

## 👑 Default Admin User

Admin is automatically created using EF Core seed data.

### 🔐 Credentials

```plaintext
Email: admin@gmail.com
Password: Admin@123
Role: Admin
```

### ⚠️ Important

* Password is stored as **hashed value**
* Admin role is **NOT taken from user input**
* Created during **migration**

---

## 🔐 Authentication Flow

```plaintext
Register → Login → Get Token → Authorize → Access APIs
```

---

## 📡 API Endpoints

### 🔑 Auth APIs

| Method | Endpoint             |
| ------ | -------------------- |
| POST   | `/api/auth/register` |
| POST   | `/api/auth/login`    |

---

### 🛍️ Product APIs

| Method | Endpoint               | Access |
| ------ | ---------------------- | ------ |
| GET    | `/api/products`        | Public |
| GET    | `/api/products/{id}`   | Public |
| GET    | `/api/products/search` | Public |
| POST   | `/api/products`        | Admin  |
| PUT    | `/api/products/{id}`   | Admin  |
| DELETE | `/api/products/{id}`   | Admin  |

---

### 📦 Order APIs

| Method | Endpoint           | Access        |
| ------ | ------------------ | ------------- |
| GET    | `/api/orders`      | Authenticated |
| GET    | `/api/orders/{id}` | Authenticated |
| POST   | `/api/orders`      | Authenticated |

---

## 🔍 Pagination, Search & Filtering

```plaintext
GET /api/products/search?search=iphone&minPrice=10000&maxPrice=80000&pageNumber=1&pageSize=5
```

---

## 📬 Postman Collection

For testing purposes, **Postman is used** and a collection is included.

### How to Use:

1. Open Postman
2. Click **Import**
3. Select the collection file
4. Add JWT token in **Authorization → Bearer Token**
5. Test APIs

---

## 📸 API Testing (Postman Screenshots)

### 🔐 Login API (JWT Token)

![Login](./screenshots/login.png)

---

### 🛍️ Products API

![Products](./screenshots/products.png)

---

### 📦 Orders API

![Orders](./screenshots/orders.png)

---

## ⚙️ Setup Instructions

### 1️⃣ Clone Repository

```bash
git clone https://github.com/your-username/ShopEZ.API.git
```

---

### 2️⃣ Configure Database

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=HEMANTH\\SQLEXPRESS;Database=ShopEZDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

### 3️⃣ Run Migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### 4️⃣ Run Project

```bash
dotnet run
```

---

### 5️⃣ Open Swagger

```plaintext
https://localhost:<port>/swagger
```

---

## 🔐 Security Features

* Password hashing using BCrypt
* JWT Authentication
* Role-based Authorization
* Input validation
* Global exception handling

---

## 🧠 Business Logic Highlights

* Stock validation before order
* Automatic stock reduction
* Transaction rollback on failure
* Clean layered architecture

---

## 🚀 Future Enhancements

* Refresh Tokens
* Email Verification
* Payment Integration
* Order Status Tracking
* Caching (Redis)
