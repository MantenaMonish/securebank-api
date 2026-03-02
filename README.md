# SecureBank Core API

> Enterprise-grade ASP.NET Core Banking API built with JWT authentication, role-based authorization, ADO.NET stored procedures, and clean layered architecture.

---

## Overview

SecureBank Core API is a production-style backend banking system developed using **ASP.NET Core Web API (.NET 8)**.

The project simulates real-world banking operations including:

- Secure user registration & login
- Account creation & balance tracking
- Fund transfers between accounts
- Fixed deposit management
- Role-based access control (Admin/User)

This project focuses on **security, architecture, and backend engineering best practices**, not just CRUD operations.

---

## Architecture

The application follows a clean layered architecture:

Controller Layer → Service Layer → Repository Layer → SQL Server  
HTTP APIs → Business Logic → Stored Procedures → Database

### Layers Explained

- **Controllers** – Handle HTTP requests and responses.
- **Services** – Contain business logic and validations.
- **Repositories** – Perform database operations via stored procedures.
- **Database** – SQL Server with structured stored procedures.
- **Security Layer** – JWT Authentication + Role-Based Authorization.

---

## Security Features

- JWT-based Authentication
- Role-Based Authorization (Admin / User)
- Password Hashing
- Protected API Endpoints
- Ownership Validation (users can only access their own data)
- Swagger JWT Integration for secure API testing

---

## Core Modules

### Authentication
- User Registration
- Login with JWT Token Generation

### Account Management
- Create Single / Joint Accounts
- View Account Balance
- Retrieve Account Overview

### Transactions
- Secure Fund Transfer
- Transaction Recording

### Fixed Deposit Module
- Create Fixed Deposit
- Close Fixed Deposit (Admin-controlled)

---

## Tech Stack

- ASP.NET Core Web API (.NET 8)
- SQL Server
- ADO.NET
- Stored Procedures
- JWT Bearer Authentication
- Swashbuckle (Swagger)
- Dependency Injection

---

## Database Design

The system uses normalized relational tables including:

- Users
- Accounts
- Transactions
- FixedDeposits

All database operations are executed via **stored procedures** to simulate enterprise-grade backend systems.

---

## How to Run the Project

### Clone the repository

```bash
git clone https://github.com/MantenaMonish/securebank-api.git
