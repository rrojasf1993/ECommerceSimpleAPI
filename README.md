# 🛒 ECommerceTechnicalTest

This project is a technical test for a distributed e-commerce system, built with .NET 8 and designed around clean architecture principles, resilience, validation, and testability. The solution is modular, scalable, and ready for microservice environments.

---

## 📁 Folder Structure

The project is organized into clearly separated layers:

<img width="1024" height="1536" alt="image" src="https://github.com/user-attachments/assets/3ddc46b3-31b9-4049-bcd1-ec00115aa6af" />


---

## 🧩 Layer Breakdown

### **1. Dtos Layer**
Defines the data transfer objects used across the application. These are clean representations of input/output models, decoupled from persistence logic.

- `ProductDto`, `OrderDto`, `OrderItemDto`
- Validators using FluentValidation to enforce structure and business rules.

---

### **2. Data Layer**
Handles persistence and database access. Uses Entity Framework Core with Oracle as the underlying database.

- `AppDbContext`: EF Core context.
- `Entities`: Domain models mapped to database tables.
- `UnitOfWork`: Centralized transaction management and repository access.

---

### **3. Domain Layer**
Encapsulates business logic and application flow using CQRS.

- `Commands`: Represent intent (e.g., `CreateOrderCmd`).
- `Handlers`: Execute command logic (e.g., `CreateOrderHandler`).
- `Enums`: Domain-specific constants like `OrderStatus`.
- `MappingProfile`: AutoMapper configuration for DTO ↔ Entity mapping.

---

### **4. Services Layer**
Implements reusable business services and orchestrates logic between layers.

- `OrdersService`: CRUD operations for orders.
- `ProductVerifierService`: Validates product existence via HTTP.
- `IProductVerifier`: Interface for decoupling external verification logic.

---

### **5. Cross Layer**
Contains shared utilities and infrastructure concerns.

- `RetryingHttpClient`: Encapsulates Polly-based HTTP resilience.
- `GlobalExceptionMiddleware`: Centralized error handling across the API.

---

### **6. Web Layer**
Exposes the API endpoints and configures the application.

- `Controllers`: RESTful endpoints (`OrdersController`).
- `Filters`: Custom validation filters.
- `Program.cs` / `Startup.cs`: Application bootstrap and DI configuration.

---

### **7. Tests Layer**
Ensures correctness and reliability through unit testing.

- `OrdersServiceTests`, `OrdersControllerTests`, `ValidatorsTests`
- Uses `xUnit` and `Moq` for mocking dependencies and verifying behavior.

---
### 🔧 Key Technical Decisions
- RetryingHttpClient encapsulates Polly-based resilience.
- ProductVerifierService decoupled via IProductVerifier.
- Distributed validation before persisting orders.
- CreateOrderHandler free of external dependencies (SRP).
- Tests cover both happy paths and expected failures.
- GlobalExceptionMiddleware centralizes error handling.



## 🚀 How to Run

1. Ensure Oracle is running locally.
2. Configure the connection string in `appsettings.json`.
3. Run the Web project:

```bash
dotnet run --project ECommerce.TechnicalTest.Web

