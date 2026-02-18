# Backend Assessment

A pre-configured boilerplate for a backend engineering technical assessment, built using **Clean Architecture** with **Domain-Driven Design (DDD)** principles in .NET 10.

---

## Project Overview

This project serves as a scaffold for a backend engineering assessment. It provides a fully configured development environment with all necessary infrastructure (PostgreSQL, RabbitMQ) running via Docker Compose. The codebase follows Clean Architecture / Onion Architecture with DDD patterns, giving candidates a production-grade foundation to build upon.

The boilerplate includes stub implementations with comprehensive XML documentation explaining what each method should do. Candidates are expected to implement the business logic during their interview session.

---

## Architecture

### Clean Architecture / Onion Architecture with DDD

This project follows the **Onion Architecture** pattern, where dependencies flow inward. The innermost layer (Domain) has no external dependencies, while outer layers depend on inner layers through abstractions.

```
┌──────────────────────────────────────────┐
│              API Layer                   │  Controllers, Middleware, Program.cs
│  ┌────────────────────────────────────┐  │
│  │       Infrastructure Layer        │  │  EF Core, Dapper, MassTransit, Hangfire
│  │  ┌──────────────────────────────┐ │  │
│  │  │     Application Layer       │ │  │  MediatR Handlers, DTOs, Commands/Queries
│  │  │  ┌────────────────────────┐ │ │  │
│  │  │  │    Domain Layer       │ │ │  │  Entities, Value Objects, Events, Interfaces
│  │  │  └────────────────────────┘ │ │  │
│  │  └──────────────────────────────┘ │  │
│  └────────────────────────────────────┘  │
└──────────────────────────────────────────┘
```

**Layer Responsibilities:**

| Layer | Project | Responsibility |
|-------|---------|---------------|
| **Domain** | `BackendAssessment.Domain` | Core business logic, entities, value objects, domain events, and repository interfaces. Has no external dependencies. |
| **Application** | `BackendAssessment.Application` | Use cases orchestrated via MediatR command/query handlers. Contains DTOs for data transfer. Depends only on Domain. |
| **Infrastructure** | `BackendAssessment.Infrastructure` | Technical implementations: EF Core, Dapper, MassTransit consumers, Hangfire jobs, repository implementations. |
| **API** | `BackendAssessment.Api` | HTTP entry point with controllers, middleware, dependency injection configuration, and service registration. |

### CQRS (Command Query Responsibility Segregation)

This project applies the **CQRS pattern** via MediatR:

- **Commands** (write operations) are handled by command handlers that modify state. Example: `CreateSampleCommand` creates a new entity.
- **Queries** (read operations) are handled by query handlers that return data without modifying state. Example: `GetSampleByIdQuery` retrieves an entity by Id.

---

## Tech Stack

| Tool / Library | Description | Why It's Included | Documentation |
|---|---|---|---|
| **.NET 10** | Cross-platform application framework | Target runtime for the assessment | [docs.microsoft.com](https://learn.microsoft.com/en-us/dotnet/) |
| **Entity Framework Core** | Full-featured ORM for .NET | Handles database operations, migrations, and schema management via code-first approach | [EF Core Docs](https://learn.microsoft.com/en-us/ef/core/) |
| **Dapper** | Lightweight micro-ORM | Maps SQL results directly to objects with minimal overhead | [github.com/DapperLib/Dapper](https://github.com/DapperLib/Dapper) |
| **Npgsql** | PostgreSQL provider for EF Core | Enables EF Core and Dapper to connect to PostgreSQL | [npgsql.org](https://www.npgsql.org/) |
| **MediatR v14** | Implements the Mediator pattern for in-process messaging | Enables CQRS by routing commands and queries to their respective handlers (using version 14.x) | [github.com/jbogard/MediatR](https://github.com/jbogard/MediatR) |
| **MassTransit v8** | Abstraction over message brokers for publish/subscribe | Provides a clean API for publishing and consuming domain events via RabbitMQ (using version 8.x) | [masstransit.io](https://masstransit.io) |
| **RabbitMQ** | Open-source message broker | Handles asynchronous event publishing between services/components | [rabbitmq.com](https://www.rabbitmq.com/) |
| **Hangfire** | Background job processing framework | Schedules and executes deferred/recurring tasks (e.g., follow-up reminders) | [hangfire.io](https://www.hangfire.io/) |
| **Hangfire.PostgreSql** | PostgreSQL storage for Hangfire | Persists job state in the same PostgreSQL database | [nuget.org/packages/Hangfire.PostgreSql](https://www.nuget.org/packages/Hangfire.PostgreSql) |
| **Serilog** | Structured logging library | Provides structured, queryable logging with console output | [serilog.net](https://serilog.net/) |
| **Swashbuckle (Swagger)** | API documentation generator | Auto-generates interactive API documentation at `/swagger` | [github.com/domaindrivendev/Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) |
| **xUnit** | Testing framework for .NET | Industry-standard unit testing framework | [xunit.net](https://xunit.net/) |
| **NSubstitute** | Mocking library for .NET | Creates test doubles for interfaces, enabling isolated unit tests | [nsubstitute.github.io](https://nsubstitute.github.io/help/getting-started/) |
| **FluentAssertions** | Assertion library with expressive syntax | Makes test assertions more readable and descriptive | [fluentassertions.com](https://fluentassertions.com/) |
| **Docker & Docker Compose** | Container orchestration | Runs PostgreSQL, RabbitMQ, and the API in isolated containers | [docs.docker.com](https://docs.docker.com/) |

---

## Getting Started

### Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (includes Docker Compose)
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

### Clone the Repository

```bash
git clone <repository-url>
cd backend-assessment
```

### Run with Docker Compose

Start all services (PostgreSQL, RabbitMQ, and the API):

```bash
docker compose up
```

This will:
1. Start PostgreSQL on port 5432
2. Start RabbitMQ on ports 5672 (AMQP) and 15672 (Management UI)
3. Build and start the .NET API on port 8080
4. Automatically apply database migrations

### Verify the Environment

| Service | URL | Credentials |
|---------|-----|-------------|
| **Swagger UI** | [http://localhost:8080/swagger](http://localhost:8080/swagger) | — |
| **Hangfire Dashboard** | [http://localhost:8080/hangfire](http://localhost:8080/hangfire) | — |
| **RabbitMQ Management** | [http://localhost:15672](http://localhost:15672) | user: `guest`, password: `guest` |

### Run Without Docker (Local .NET SDK)

If you prefer to run the API directly:

1. Ensure PostgreSQL and RabbitMQ are running (e.g., via `docker compose up postgres rabbitmq`)
2. Run the API:

```bash
dotnet run --project src/BackendAssessment.Api
```

### Run Tests

```bash
dotnet test
```

### Troubleshooting

| Issue | Solution |
|-------|----------|
| Port 5432 already in use | Stop any local PostgreSQL instance: `brew services stop postgresql` or change the port in `docker-compose.yml` |
| Port 5672/15672 already in use | Stop any local RabbitMQ instance: `brew services stop rabbitmq` |
| Docker build fails | Ensure Docker Desktop is running and has sufficient resources allocated |
| API can't connect to PostgreSQL | Wait for the PostgreSQL health check to pass before the API starts. Check logs: `docker compose logs api` |
| Migrations fail | Ensure the database is accessible. Check: `docker compose logs postgres` |

---

## Project Structure

```
backend-assessment/
├── docker-compose.yml              # Orchestrates PostgreSQL, RabbitMQ, and API
├── docker-compose.override.yml     # Environment variable overrides for Docker
├── Dockerfile                      # Multi-stage build for the API
├── BackendAssessment.sln           # .NET solution file
├── README.md                       # This file
│
├── src/
│   ├── BackendAssessment.Domain/           # Core domain layer (no external dependencies)
│   │   ├── Entities/
│   │   │   └── SampleEntity.cs             # Domain entity with factory method and domain events
│   │   ├── ValueObjects/
│   │   │   └── Money.cs                    # Value object for monetary amounts
│   │   ├── Events/
│   │   │   └── SampleEntityCreatedEvent.cs # Domain event raised on entity creation
│   │   └── Interfaces/
│   │       └── ISampleRepository.cs        # Repository interface (abstraction)
│   │
│   ├── BackendAssessment.Application/      # Application layer (use cases)
│   │   ├── Commands/
│   │   │   ├── CreateSampleCommand.cs      # Command record for creating entities
│   │   │   └── CreateSampleCommandHandler.cs # Handler stub (implements IRequestHandler)
│   │   ├── Queries/
│   │   │   ├── GetSampleByIdQuery.cs       # Query record for fetching by Id
│   │   │   └── GetSampleByIdQueryHandler.cs # Handler stub (implements IRequestHandler)
│   │   └── DTOs/
│   │       ├── SampleDto.cs                # Full entity DTO
│   │       └── SampleSummaryDto.cs         # Lightweight summary DTO
│   │
│   ├── BackendAssessment.Infrastructure/   # Infrastructure layer (implementations)
│   │   ├── Persistence/
│   │   │   ├── AppDbContext.cs             # EF Core DbContext with entity configuration
│   │   │   ├── SampleRepository.cs         # Repository implementation
│   │   │   └── Migrations/                 # EF Core migrations
│   │   ├── Messaging/
│   │   │   └── SampleEntityCreatedEventConsumer.cs # MassTransit consumer stub
│   │   └── Jobs/
│   │       └── SampleFollowUpJob.cs        # Hangfire job stub
│   │
│   └── BackendAssessment.Api/              # API layer (entry point)
│       ├── Controllers/
│       │   └── SampleController.cs         # REST controller with POST and GET endpoints
│       ├── Middleware/
│       │   └── ExceptionHandlingMiddleware.cs # Global exception handler
│       ├── Program.cs                      # Application bootstrap and DI configuration
│       ├── appsettings.json                # Base configuration
│       └── appsettings.Development.json    # Docker/development configuration
│
└── tests/
    └── BackendAssessment.Tests/            # Unit tests
        └── CreateSampleCommandHandlerTests.cs # Test scaffolds with xUnit + NSubstitute
```

---

## Key Concepts to Review

Before your interview, familiarize yourself with these concepts:

### Clean Architecture / Onion Architecture
Architectural pattern where dependencies point inward. The domain layer is at the center with no external dependencies, and outer layers implement abstractions defined by inner layers.
- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

### Domain-Driven Design (DDD)
Strategic and tactical design approach that focuses on the core domain. Key patterns used here: Entities, Value Objects, Domain Events, Repository Pattern.
- [Domain-Driven Design Reference](https://www.domainlanguage.com/ddd/reference/)

### CQRS Pattern
Separates read and write operations into different models.
- [CQRS Pattern - Martin Fowler](https://martinfowler.com/bliki/CQRS.html)

### Repository Pattern
Abstracts data access behind an interface, allowing the domain layer to remain independent of persistence technology.
- [Repository Pattern - Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)

### Domain Events
Events that represent something meaningful that happened in the domain. In this project, they are published via MassTransit to RabbitMQ for asynchronous processing.
- [Domain Events - Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/domain-events-design-implementation)

### Dapper and Entity Framework Core
Both are available in this project as data access tools. Understanding when and why you might use each is valuable.
- [Dapper](https://github.com/DapperLib/Dapper)
- [EF Core](https://learn.microsoft.com/en-us/ef/core/)

### MassTransit and Message-Based Architecture
MassTransit provides an abstraction over message brokers (RabbitMQ in this project) for publishing and consuming messages. This enables loose coupling between components and asynchronous processing of domain events.
- [MassTransit Documentation](https://masstransit.io/documentation/concepts)

---

## What's Next

This boilerplate has been provided ahead of your technical interview. Please ensure you can run the project successfully and familiarize yourself with the architecture and tools. The actual assessment task will be shared at the beginning of your interview session.
