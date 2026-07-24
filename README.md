# Product Management API

A RESTful Product Management API built using ASP.NET Core 8 following Clean Architecture principles.

## Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- FluentValidation
- AutoMapper
- Serilog
- Swagger / OpenAPI
- xUnit & Moq
- Docker

---

## Project Structure

```
ProductManagementAPI
│
├── src
│   ├── API
│   ├── Application
│   ├── Domain
│   └── Infrastructure
│
├── tests
│   ├── API.Tests
│   ├── Application.Tests
│   └── Infrastructure.Tests
│
├── docker-compose.yml
├── README.md
└── ProductManagementAPI.sln
```

---

## Features

- Product CRUD Operations
- JWT Authentication
- Refresh Token Support
- Repository Pattern
- Unit of Work Pattern
- FluentValidation
- Global Exception Middleware
- API Versioning
- Swagger Documentation
- Serilog Logging
- Unit & Integration Tests
- Docker Support

---

## Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio Code or Visual Studio 2022

---

## Setup

Clone the repository

```bash
git clone <repository-url>
```

Go to API project

```bash
cd src/API
```
Update the connection string in
```
appsettings.json
```
Apply migrations

```bash
dotnet ef database update
```
Run the application

```bash
dotnet run
```
---

## Authentication

Login Endpoint

```
POST /api/Auth/login
```
After successful login, use the returned Access Token in Swagger.
Authorization Header

```
Bearer {your_access_token}
```
---
## API Documentation

Swagger is available at

```
http://localhost:5232/swagger
```
---

## Run Tests

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

## Author
Jayesh Ishi