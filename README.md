# Stock Management System API

This is a simple **Stock Management Web API** built using **ASP.NET Core Web API**. It allows users to register, login, manage roles, and perform full CRUD operations on inventory items. The project also uses **AutoMapper** to handle model mapping and exposes endpoints via **Swagger** for easy testing.

---

## 📌 Features

- 🔐 **Authentication & Authorization**
  - Register new users
  - Login and receive a token
  - Add roles to users

- 📦 **Item Management (CRUD)**
  - Create new items
  - Update existing items
  - Delete items
  - Get all items or a specific item by ID
  - Increase item quantity

- ⚙️ Swagger UI for testing all endpoints
- 🎯 AutoMapper for clean mapping between entities and DTOs

---

## 🧰 Technologies Used

- ASP.NET Core Web API (.NET 6+)
- Entity Framework Core
- AutoMapper
- JWT Authentication
- Swagger / Swashbuckle

---

## 📂 API Endpoints Overview

### 🔐 Auth Controller

| Method | Endpoint               | Description        |
|--------|------------------------|--------------------|
| POST   | `/api/Auth/register`   | Register a user    |
| POST   | `/api/Auth/login`      | Login & get token  |
| POST   | `/api/Auth/addrole`    | Assign a role      |

### 📦 Item Controller

| Method | Endpoint                        | Description                  |
|--------|----------------------------------|------------------------------|
| POST   | `/api/Item/create`              | Add a new item               |
| POST   | `/api/Item/update`              | Update an existing item      |
| DELETE | `/api/Item/{id}`                | Delete item by ID            |
| GET    | `/api/Item/GetAllitem`          | Get all items                |
| GET    | `/api/Item/Get/{id}`            | Get item by ID               |
| POST   | `/api/Item/IncreaseQuantity`    | Increase item quantity       |

---

## 🗂️ Project Structure

- `Models`: Entity classes used for database operations.
- `DTOs`: Data Transfer Objects used for input/output.
- `Profiles`: AutoMapper profile configurations.
- `Controllers`: API endpoints for Auth and Item.
- `Services`: Business logic layer (if separated).
- `Program.cs`: Swagger, authentication, and DI setup.

---

## 🧭 How to Run

1. **Clone the repo:**
   ```bash
   git clone https://github.com/Basant-mahmoud/Stock.git
