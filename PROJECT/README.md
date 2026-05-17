# 🛒 ShopEZ — E-Commerce Platform

> A full-stack e-commerce platform built with **Angular 21** (frontend) and **ASP.NET Core 8 Microservices** (backend), connected via an **Ocelot API Gateway**, containerized with **Docker Compose**.

---

## Table of Contents

- [Project Overview](#-project-overview)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [Architecture](#-architecture)
- [Features](#-features)
- [Prerequisites](#-prerequisites)
- [Getting Started](#-getting-started)
  - [Option 1 — Docker (Recommended)](#option-1--docker-recommended)
  - [Option 2 — Manual / Development Mode](#option-2--manual--development-mode)
- [Environment Configuration](#-environment-configuration)
- [API Endpoints](#-api-endpoints)
- [Running Tests](#-running-tests)
- [Default Ports](#-default-ports)
- [User Roles](#-user-roles)
- [Project Team](#-project-team)

---

## Project Overview

ShopEZ is a capstone project implementing a production-style e-commerce platform. It supports two user roles — **Customer** and **Admin** — with a clean separation of concerns across independently deployable microservices, each owning its own SQL Server database.

The Angular 21 SPA communicates exclusively through the Ocelot API Gateway, never directly with individual services. Cart management is handled client-side via `localStorage`. Authentication uses stateless JWT tokens with role-based claims.

---

## Tech Stack

### Frontend

| Technology      | Version   | Purpose                                                  |
| --------------- | --------- | -------------------------------------------------------- |
| Angular         | 21.2.x    | SPA framework — standalone components, lazy loading, SSR |
| TypeScript      | 5.9.x     | Type-safe JavaScript                                     |
| Bootstrap       | 5.3.x     | UI styling                                               |
| ngx-toastr      | 20.x      | Toast notifications                                      |
| RxJS            | 7.8.x     | Reactive programming — BehaviorSubject, Observables      |
| Angular SSR     | 21.2.x    | Server-side rendering via Express                        |
| Karma + Jasmine | 6.x / 5.x | Unit testing                                             |

### Backend

| Technology            | Version   | Purpose                                            |
| --------------------- | --------- | -------------------------------------------------- |
| ASP.NET Core          | 8.0       | Web API framework for all microservices            |
| C#                    | 12        | Primary programming language                       |
| Entity Framework Core | 8.x       | ORM — Auth Service & Order Service                 |
| Dapper                | 2.x       | Micro-ORM — Product Service (search, pagination)   |
| BCrypt.Net            | Latest    | Password hashing                                   |
| JWT Bearer            | 8.x       | Authentication middleware                          |
| Ocelot                | 23.x      | API Gateway routing                                |
| Serilog               | 3.x       | Structured logging (Console + daily rolling files) |
| xUnit + Moq           | 2.x / 4.x | Unit testing                                       |

### Infrastructure

| Technology              | Purpose                                          |
| ----------------------- | ------------------------------------------------ |
| Docker & Docker Compose | Containerization and multi-service orchestration |
| SQL Server 2022         | Relational database (one per microservice)       |

---

## Project Structure

```
CapstoneProject/
├── Frontend/                          # Angular 21 SPA
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/            # Feature components (Cart, Checkout, Orders, Products)
│   │   │   ├── pages/                 # Page components (Home, Login, Register, Admin)
│   │   │   ├── services/              # ProductService, CartService, OrderService, UserService
│   │   │   ├── core/
│   │   │   │   ├── services/          # AuthService (BehaviorSubject-based)
│   │   │   │   ├── guards/            # authGuard, adminGuard
│   │   │   │   └── interceptors/      # jwtInterceptor, errorInterceptor
│   │   │   ├── models/                # TypeScript interfaces (User, Product, Order, etc.)
│   │   │   ├── shared/components/     # NavbarComponent, FooterComponent
│   │   │   ├── app.routes.ts          # Lazy-loaded route configuration
│   │   │   └── app.config.ts          # Root app configuration
│   │   ├── environments/              # API URL configuration
│   │   └── server.ts                  # Angular Universal SSR entry point
│   ├── Dockerfile
│   └── package.json
│
└── Backend/
    ├── ApiGateway/                    # Ocelot API Gateway
    │   ├── ocelot.json                # Route configuration
    │   └── Dockerfile
    ├── Services/
    │   ├── AuthService/               # User registration, login, JWT, role management
    │   │   ├── Controllers/           # AuthController
    │   │   ├── Services/              # AuthService1
    │   │   ├── Repositories/          # UserRepository
    │   │   ├── Entities/              # User entity
    │   │   ├── DTOs/                  # RegisterDto, LoginDto, AuthResponseDto
    │   │   ├── Helpers/               # JwtHelper
    │   │   ├── Data/                  # AuthDbContext (EF Core)
    │   │   └── Dockerfile
    │   ├── ProductService/            # Product CRUD, search, pagination, stock
    │   │   ├── Controllers/           # ProductsController
    │   │   ├── Services/              # ProductService (Dapper-based)
    │   │   ├── Repositories/          # ProductRepository
    │   │   ├── Entities/              # Product entity
    │   │   ├── DTOs/                  # ProductDto, PaginationResponseDto
    │   │   ├── Middlewares/           # ExceptionMiddleware
    │   │   └── Dockerfile
    │   └── OrderService/              # Order creation, history, status management
    │       ├── Controllers/           # OrdersController
    │       ├── Services/              # OrderService
    │       ├── Repositories/          # OrderRepository
    │       ├── Entities/              # Order, OrderItem entities
    │       ├── DTOs/                  # OrderDto, OrderItemDto
    │       ├── Data/                  # OrderDbContext (EF Core)
    │       ├── Middlewares/           # ExceptionMiddleware
    │       └── Dockerfile
    ├── Tests/
    │   ├── AuthService.Tests/         # xUnit tests — Auth controllers, services, repositories
    │   ├── ProductService.Tests/      # xUnit tests — Product controllers, services, repositories
    │   └── OrderService.Tests/        # xUnit tests — Order controllers, services, repositories
    └── docker-compose.yml
```

---

## Architecture

```
Browser (Angular 21 SPA — http://localhost:4200)
         │
         │  JWT Bearer token attached via jwtInterceptor
         ▼
Ocelot API Gateway (http://localhost:5139 dev / 5000 Docker)
         │
    ┌────┴──────────────────────┐
    │                           │                      │
    ▼                           ▼                      ▼
Auth Service              Product Service         Order Service
(port 5004 / 5001)        (port 5096 / 5002)     (port 5280 / 5003)
EF Core + AuthDB          Dapper + ProductDB      EF Core + OrderDB
         │                           │                      │
         └────────────────┬──────────┘                      │
                          ▼                                  │
                  SQL Server 2022 ◄────────────────────────┘
              (shopez-sqlserver:1433)
```

**Key design decisions:**

- Each microservice owns its own database (no shared schema)
- Frontend never calls microservices directly — always goes through the gateway
- JWT validation is configured per-service using a shared Issuer/Audience/Key
- Cart is managed client-side in `localStorage` for instant response without an API round-trip
- Order Service calls Product Service via `HttpClient` to reduce stock after each order

---

## Features

### Customer

- Browse all products with pagination and real-time search
- View individual product details
- Add/remove/update items in the cart (localStorage-persisted)
- Register and log in with JWT authentication
- Checkout and place multi-item orders
- View complete order history

### Admin

- All customer features
- Create, edit, and delete products
- View all platform orders and update order status
- View all registered users and update user roles (Customer ↔ Admin)

### Technical

- Server-Side Rendering (SSR) for SEO and first-paint performance
- Lazy-loaded routing — all feature modules loaded on demand
- Role-based route guards (`authGuard`, `adminGuard`) — SSR-safe using `isPlatformBrowser()`
- Global JWT interceptor — auto-attaches `Authorization: Bearer <token>` to every request
- Global error interceptor — maps HTTP status codes to user-friendly messages
- Serilog structured logging with daily rolling file output in every service
- Swagger UI available on every microservice in development mode

---

## Prerequisites

### For Docker (recommended)

- [Docker Desktop](https://www.docker.com/products/docker-desktop) — version 24+
- At least **4 GB RAM** allocated to Docker
- Ports `1433`, `4200`, `5000–5003` free on the host

### For Development Mode

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js 20+](https://nodejs.org) and npm 11+
- [Angular CLI 21+](https://angular.dev/tools/cli) — `npm install -g @angular/cli`
- SQL Server (local instance or Docker — see below)

---

## Getting Started

### Option 1 — Docker (Recommended)

Runs all services (SQL Server, Auth, Product, Order, API Gateway, Frontend) in one command.

```bash
# 1. Clone or extract the project
cd CapstoneProject/Backend

# 2. Build and start all containers
docker-compose up --build
```

> **First run:** Downloads the SQL Server 2022 image and builds all Dockerfiles — allow 5–10 minutes. Subsequent runs are faster.

**Verify everything is running:**

| Service                 | URL                   |
| ----------------------- | --------------------- |
| Angular Frontend        | http://localhost:4200 |
| API Gateway             | http://localhost:5000 |
| Auth Service Swagger    | http://localhost:5001 |
| Product Service Swagger | http://localhost:5002 |
| Order Service Swagger   | http://localhost:5003 |

**Stop all services:**

```bash
docker-compose down

# Also remove the SQL Server data volume (resets database):
docker-compose down -v
```

---

### Option 2 — Manual / Development Mode

Run each service independently for development and debugging.

#### Step 1 — Start SQL Server

If you don't have SQL Server installed locally, run it via Docker:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Pass123" \
  -p 1433:1433 --name shopez-sql \
  mcr.microsoft.com/mssql/server:2022-latest
```

#### Step 2 — Update Connection Strings

In each service's `appsettings.json`, update the `ConnectionStrings:DefaultConnection` to point to your SQL Server instance. The default development value uses a named instance — replace with your own:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=AuthDB;User Id=sa;Password=YourStrong@Pass123;TrustServerCertificate=True;"
}
```

Update similarly for `ProductService` (Database=`ProductDB`) and `OrderService` (Database=`OrderDB`).

#### Step 3 — Apply EF Core Migrations

```bash
# Auth Service
cd CapstoneProject/Backend/Services/AuthService
dotnet ef database update

# Order Service
cd CapstoneProject/Backend/Services/OrderService
dotnet ef database update
```

> ProductService uses Dapper — its table is created via a raw SQL script in the repository initializer.

#### Step 4 — Run Backend Services

Open four terminals:

```bash
# Terminal 1 — Auth Service (port 5004)
cd CapstoneProject/Backend/Services/AuthService
dotnet run

# Terminal 2 — Product Service (port 5096)
cd CapstoneProject/Backend/Services/ProductService
dotnet run

# Terminal 3 — Order Service (port 5280)
cd CapstoneProject/Backend/Services/OrderService
dotnet run

# Terminal 4 — API Gateway (port 5139)
cd CapstoneProject/Backend/ApiGateway
dotnet run
```

#### Step 5 — Run Angular Frontend

```bash
cd CapstoneProject/Frontend
npm install
ng serve
```

Open **http://localhost:4200** in your browser.

---

## Environment Configuration

### Frontend — `src/environments/environment.ts`

```typescript
export const environment = {
  production: false,
  apiUrl: "http://localhost:5139/api", // Points to API Gateway
};
```

For Docker mode, update `apiUrl` to `http://localhost:5000/api`.

### Backend — `appsettings.json` (all services)

```json
{
  "Jwt": {
    "Key": "THIS_IS_MY_SUPER_SECRET_KEY_123456789123456789",
    "Issuer": "ShopEZ",
    "Audience": "ShopEZUsers"
  }
}
```

> Change the `Jwt:Key` to a strong secret before deploying to production.

---

## API Endpoints

All calls go through the gateway at `http://localhost:5139` (dev) or `http://localhost:5000` (Docker).

### Auth — `/api/auth`

| Method | Endpoint              | Auth       | Description                 |
| ------ | --------------------- | ---------- | --------------------------- |
| `POST` | `/api/auth/register`  | None       | Register a new user         |
| `POST` | `/api/auth/login`     | None       | Login and receive JWT token |
| `GET`  | `/api/auth`           | Admin only | Get all users               |
| `PUT`  | `/api/auth/{id}/role` | Admin only | Update user role            |

### Products — `/api/products`

| Method   | Endpoint                          | Auth       | Description                                            |
| -------- | --------------------------------- | ---------- | ------------------------------------------------------ |
| `GET`    | `/api/products`                   | None       | Get all products (supports `?page=&pageSize=&search=`) |
| `GET`    | `/api/products/{id}`              | None       | Get product by ID                                      |
| `POST`   | `/api/products`                   | Admin only | Create a new product                                   |
| `PUT`    | `/api/products/{id}`              | Admin only | Update a product                                       |
| `DELETE` | `/api/products/{id}`              | Admin only | Delete a product                                       |
| `PUT`    | `/api/products/{id}/reduce-stock` | None       | Reduce product stock (called by Order Service)         |

### Orders — `/api/orders`

| Method   | Endpoint                       | Auth          | Description                 |
| -------- | ------------------------------ | ------------- | --------------------------- |
| `GET`    | `/api/orders`                  | Admin only    | Get all orders              |
| `GET`    | `/api/orders/user/{userId}`    | Auth required | Get orders for a user       |
| `GET`    | `/api/orders/{orderId}`        | Auth required | Get single order with items |
| `POST`   | `/api/orders`                  | Auth required | Place a new order           |
| `PUT`    | `/api/orders/{orderId}/status` | Admin only    | Update order status         |
| `DELETE` | `/api/orders/{orderId}`        | Auth required | Delete an order             |

---

## Running Tests

### Frontend (Karma + Jasmine)

```bash
cd CapstoneProject/Frontend

# Interactive mode (opens Chrome)
ng test

# Headless / CI mode
ng test --watch=false --browsers=ChromeHeadless
```

Test files are located alongside their components/services as `*.spec.ts`.

### Backend (xUnit + Moq)

```bash
# Run all backend tests
cd CapstoneProject/Backend
dotnet test

# Or run per service
cd CapstoneProject/Backend/Tests/AuthService.Tests && dotnet test
cd CapstoneProject/Backend/Tests/ProductService.Tests && dotnet test
cd CapstoneProject/Backend/Tests/OrderService.Tests && dotnet test
```

---

## Default Ports

| Service          | Development Port | Docker Port |
| ---------------- | ---------------- | ----------- |
| Angular Frontend | 4200             | 4200        |
| API Gateway      | 5139             | 5000        |
| Auth Service     | 5004             | 5001        |
| Product Service  | 5096             | 5002        |
| Order Service    | 5280             | 5003        |
| SQL Server       | 1433             | 1433        |

---

## User Roles

| Role         | Default              | Capabilities                                                |
| ------------ | -------------------- | ----------------------------------------------------------- |
| **Customer** | Yes (on register)    | Browse, cart, checkout, view own orders                     |
| **Admin**    | Seeded automatically | Everything + product CRUD, all orders, user role management |

### Seeded Admin Account

A default admin user is seeded automatically via `AuthDbContext.OnModelCreating()` when EF Core applies migrations. **No manual SQL is needed.**

| Field    | Value             |
| -------- | ----------------- |
| Email    | `admin@gmail.com` |
| Password | `Admin@123`       |
| Role     | `Admin`           |

The password is stored as a BCrypt hash (`$2a$11$7.PSaQ...`) — it is never stored in plain text.

**Login immediately** at `/login` with the credentials above after the database is created. The seeded admin account is available on both Docker and development mode as soon as migrations run.

### Promoting an Existing User to Admin

To give Admin rights to any registered user, log in as the seeded admin, navigate to **Admin → Users**, and update the role from the UI. Alternatively, use the API directly:

```http
PUT http://localhost:5139/api/auth/{userId}/role
Authorization: Bearer <admin-jwt-token>
Content-Type: application/json

"Admin"
```

---

## Project Team

| Name    | Role                                                            |
| ------- | --------------------------------------------------------------- |
| Hemanth | Full Stack Developer — Backend Microservices & Angular Frontend |

---

## License

This project is developed as a **Capstone Academic Project**. All rights reserved by the project author.
