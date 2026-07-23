# Product Management API

## Overview

This project is a RESTful Backend API built using .NET 8 and ASP.NET Core Web API for managing Products and Items. It follows Clean Architecture principles with separate Domain, Application, Infrastructure, and API layers.

## Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Refresh Token
- FluentValidation
- AutoMapper
- Swagger
- Serilog
- xUnit
- Moq
- WebApplicationFactory
- Docker

---

## Architecture

```
API
    ↓
Application
    ↓
Infrastructure
    ↓
SQL Server

Domain
```

---

## Project Structure

```
src
 ├── API
 ├── Application
 ├── Domain
 └── Infrastructure

tests
 ├── API.Tests
 ├── Application.Tests
 └── Infrastructure.Tests
```

---

## Database Setup

Update the connection string in:

```
src/API/appsettings.json
```

Run migrations:

```bash
dotnet ef database update --project src/Infrastructure --startup-project src/API
```

---

## Running the Project

```bash
dotnet restore
dotnet build
cd src/API
dotnet run
```

Swagger:

```
http://localhost:5232/swagger
```

---

## Authentication

Login API returns:

- Access Token
- Refresh Token

Use the Access Token as:

```
Authorization: Bearer <token>
```

---

## API Endpoints

### Authentication

```
POST /api/Auth/login
```

### Products

```
GET     /api/v1/Products
GET     /api/v1/Products/{id}
POST    /api/v1/Products
PUT     /api/v1/Products/{id}
DELETE  /api/v1/Products/{id}
```

---

## Running Tests

```bash
dotnet test
```

---

## Docker

Build

```bash
docker compose build
```

Run

```bash
docker compose up
```
---
## Features
- Product CRUD
- JWT Authentication
- Refresh Token
- Repository Pattern
- Unit of Work
- FluentValidation
- Global Exception Middleware
- API Versioning
- Swagger Documentation
- Serilog Logging
- Unit Testing
- Integration Testing