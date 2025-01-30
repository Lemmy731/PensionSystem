Pension Management System

 Project Overview

The Pension Management System is a simplified contribution management system designed to handle pension contributions, member management, and benefit calculations. Built using .NET Core 8, Entity Framework Core, and SQL Server, it follows Clean Architecture principles, Domain-Driven Design (DDD), and implements background job processing with Hangfire.

  Folder Structure

  PensionManagement
      Presentation (Controllers & Middleware)
      Application (Business Logic, Services, DTOs)
      Domain (Entities, Validators, Interfaces)
      Infrastructure (Data Access, EF Core, Repositories)
      BackgroundJobs (Hangfire Jobs)
      Tests (Unit & Integration Tests)
      README.md
      appsettings.json
      PensionManagement.sln

  Tech Stack

.NET Core 8.0 (Web API)

Entity Framework Core (EF Core) for database access

SQL Server (Database)

FluentValidation (Data validation)

Hangfire (Background job processing)

xUnit / Moq (Unit Testing)

Swagger / Postman (API Documentation & Testing)

  Features

1. Member Management API

  Register a new pension member

  Update member details

  Retrieve member information

  Soft delete member

2. Contribution & Benefit Processing

   Monthly & Voluntary contributions

   Enforce one monthly contribution per month

   Contribution statements generation

   Basic benefit calculations

3. Business Rules & Background Processing

   Monthly contribution validation

   Benefit eligibility checks

   Scheduled jobs for interest calculations & statements

   Retry mechanism for failed transactions

4. API Features

   RESTful API design

   Proper HTTP status codes

   Input validation with FluentValidation

   API versioning support

5. Installation & Setup

 Prerequisites

Ensure you have the following installed:

.NET 8 SDK 

SQL Server 

Visual Studio 2022 / VS Code

6. Clone the Repository

git clone https://github.com/Lemmy731/PensionSystem.git
cd PensionManagement

7. Setup Database

Update appsettings.json with your SQL Server connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=PensionDB;User Id=your_user;Password=your_password;"
}

Run Entity Framework Core migrations:

dotnet ef database update

8. Run the Project

dotnet run --project API

9. Access Swagger API Documentation

Navigate to:

http://localhost:5000/swagger


10. Architecture & Design Decisions

Clean Architecture Implementation

Domain Layer: Contains domain models, interfaces, and validators.

Application Layer: Business logic, services, and DTOs.

Infrastructure Layer: Handles data access and repositories.

Presentation Layer: Contains controllers and middleware.

11. Repository Pattern

Data access logic is abstracted into repositories to promote testability and maintainability.

12. Dependency Injection

Services and repositories are injected into controllers to enhance modularity and flexibility.

13. Background Job Processing with Hangfire

Automated contribution validation

Monthly benefit calculations

Error-handling and retry mechanisms

14. API Endpoints

Member Management

Method

Endpoint

Description

POST

/api/members

Register a new member

PUT

/api/members/{id}

Update member details

GET

/api/members/{id}

Retrieve member details

DELETE

/api/members/{id}

Soft delete a member

Contribution Management

Method

Endpoint

Description

POST

/api/contributions

Add a new contribution

GET

/api/contributions/{id}

Get a contribution by ID

GET

/api/contributions/member/{memberId}

Get member’s contributions

Benefit Management

Method

Endpoint

Description

GET

/api/benefits/{memberId}

Calculate benefits for a member

15, Unit Testing

Run tests with:

dotnet test

Test coverage includes:

Contribution validation rules

Member age & eligibility checks

Business rules enforcement


GitHub: Lemmy731


