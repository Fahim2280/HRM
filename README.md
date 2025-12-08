# Human Resource Management (HRM) System

## Overview

The HRM System is a RESTful API built with ASP.NET Core that provides comprehensive human resource management capabilities. The system allows organizations to manage employee information and department structures efficiently.

## Table of Contents

1. [Architecture](#architecture)
2. [Features](#features)
3. [Project Structure](#project-structure)
4. [Technologies Used](#technologies-used)
5. [Setup and Installation](#setup-and-installation)
6. [API Endpoints](#api-endpoints)
7. [Database Schema](#database-schema)
8. [Error Handling](#error-handling)
9. [Configuration](#configuration)

## Architecture

The HRM System follows a clean architecture pattern with separation of concerns:

- **HRM.Domain**: Contains core business entities and interfaces
- **HRM.Application**: Implements business logic and defines DTOs
- **HRM.Infrastructure**: Handles data persistence and external services
- **HRM.API**: Exposes RESTful endpoints for client applications

This layered approach ensures maintainability, testability, and scalability.

## Features

- Full CRUD operations for employees and departments
- Data validation at both API and service layers
- Global exception handling middleware
- Entity Framework Core for data persistence
- AutoMapper for object-to-object mapping
- Swagger/OpenAPI documentation
- RESTful API design principles

## Project Structure

```
HRM/
├── HRM.API/                 # Presentation layer (Web API)
│   ├── Controllers/         # API controllers
│   ├── Middleware/          # Custom middleware components
│   └── Program.cs           # Application entry point
├── HRM.Application/         # Application layer
│   ├── Department/          # Department-related logic
│   ├── Employee/            # Employee-related logic
│   └── Extensions/          # Service collection extensions
├── HRM.Domain/              # Domain layer
│   ├── Entities/            # Business entities
│   └── Interfaces/          # Repository interfaces
├── HRM.Infrastructure/      # Infrastructure layer
│   ├── Persistence/         # Database context
│   ├── Repositories/        # Repository implementations
│   └── Extensions/          # Service collection extensions
└── HRM.slnx                 # Solution file
```

## Technologies Used

- **ASP.NET Core 10** - Web API framework
- **Entity Framework Core** - ORM for data access
- **SQL Server** - Relational database
- **AutoMapper** - Object-to-object mapping
- **Swagger/OpenAPI** - API documentation
- **Dependency Injection** - Built-in DI container

## Setup and Installation

### Prerequisites

- .NET 10 SDK
- SQL Server (or SQL Server Express)
- Visual Studio or Visual Studio Code

### Database Configuration

1. Update the connection string in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=HRM;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
   }
   ```

2. Apply migrations to create the database:
   ```bash
   cd HRM.Infrastructure
   dotnet ef database update
   ```

### Running the Application

1. Navigate to the API project:

   ```bash
   cd HRM.API
   ```

2. Run the application:

   ```bash
   dotnet run
   ```

3. Access the API documentation at:
   ```
   https://localhost:5001/swagger
   ```

## API Endpoints

### Employee Endpoints

| Method | Endpoint            | Description           |
| ------ | ------------------- | --------------------- |
| GET    | /api/employees      | Get all employees     |
| GET    | /api/employees/{id} | Get employee by ID    |
| POST   | /api/employees      | Create a new employee |
| PUT    | /api/employees/{id} | Update an employee    |
| DELETE | /api/employees/{id} | Delete an employee    |

### Department Endpoints

| Method | Endpoint              | Description             |
| ------ | --------------------- | ----------------------- |
| GET    | /api/departments      | Get all departments     |
| GET    | /api/departments/{id} | Get department by ID    |
| POST   | /api/departments      | Create a new department |
| PUT    | /api/departments/{id} | Update a department     |
| DELETE | /api/departments/{id} | Delete a department     |

## Database Schema

### Departments Table

| Column       | Type          | Constraints             |
| ------------ | ------------- | ----------------------- |
| Id           | int           | Primary Key, Identity   |
| Name         | nvarchar(100) | Not Null, Unique Index  |
| Description  | nvarchar(500) | Nullable                |
| IsActive     | bit           | Not Null, Default: true |
| CreatedDate  | datetime2     | Not Null, Default: UTC  |
| ModifiedDate | datetime2     | Nullable                |

### Employees Table

| Column       | Type          | Constraints                      |
| ------------ | ------------- | -------------------------------- |
| Id           | int           | Primary Key, Identity            |
| FirstName    | nvarchar(50)  | Not Null                         |
| LastName     | nvarchar(50)  | Not Null                         |
| Email        | nvarchar(100) | Not Null, Unique Index           |
| PhoneNumber  | nvarchar(20)  | Nullable                         |
| DateOfBirth  | datetime2     | Not Null                         |
| HireDate     | datetime2     | Not Null                         |
| Salary       | decimal(18,2) | Not Null                         |
| IsActive     | bit           | Not Null, Default: true          |
| CreatedDate  | datetime2     | Not Null, Default: UTC           |
| ModifiedDate | datetime2     | Nullable                         |
| DepartmentId | int           | Foreign Key to Departments table |

## Error Handling

The application implements global exception handling through middleware. All API responses follow consistent error formats:

- **400 Bad Request**: Validation errors or malformed requests
- **404 Not Found**: Requested resource does not exist
- **500 Internal Server Error**: Unexpected server errors

## Configuration

The application uses standard ASP.NET Core configuration. Key settings include:

- **ConnectionStrings**: Database connection string
- **Logging**: Log level configuration

Example `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=SERVER_NAME;Database=HRM;User Id=USER;Password=PASSWORD;TrustServerCertificate=True;"
  },
  "AllowedHosts": "*"
}
```
