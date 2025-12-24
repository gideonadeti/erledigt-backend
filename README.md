# Erledigt Backend

Backend API for Erledigt, a modern todo application built with .NET, Angular, and SQL Server. This RESTful API provides secure authentication and comprehensive task management functionality.

## Table of Contents

- [Erledigt Backend](#erledigt-backend)
  - [Table of Contents](#table-of-contents)
  - [Features](#features)
    - [Authentication \& Authorization](#authentication--authorization)
    - [Task Management](#task-management)
    - [API Documentation](#api-documentation)
  - [Technologies Used](#technologies-used)
    - [Core Framework](#core-framework)
    - [Database \& ORM](#database--orm)
    - [Authentication](#authentication)
    - [Documentation Tools](#documentation-tools)
    - [Development Tools](#development-tools)
  - [Running Locally](#running-locally)
    - [Prerequisites](#prerequisites)
    - [Environment Setup](#environment-setup)
    - [Database Setup](#database-setup)
    - [Running the Application](#running-the-application)
    - [Stopping the Application](#stopping-the-application)
  - [Support](#support)

## Features

### Authentication & Authorization

- **User Registration** - Secure user account creation with email validation
- **User Login** - JWT-based authentication with ASP.NET Core Identity
- **User Logout** - Secure session termination
- **Protected Endpoints** - All task endpoints require authentication
- **User Isolation** - Users can only access their own tasks

### Task Management

- **Create Tasks** - Add new todo tasks with title, description, priority, and due date
- **Read Tasks** - Retrieve all tasks or a specific task by ID
- **Update Tasks** - Modify task details including title, description, priority, and due date
- **Delete Tasks** - Remove tasks from the system
- **Toggle Completion** - Mark tasks as completed or incomplete
- **Task Properties**:
  - Title (required, max 200 characters)
  - Description (optional, max 1000 characters)
  - Priority (Low, Medium, High)
  - Due Date (optional)
  - Completion status
  - Automatic timestamps (created/updated)

### API Documentation

- **OpenAPI/Swagger** - Interactive API documentation available in development mode
- **CORS Support** - Configured for cross-origin requests from the Angular frontend
- **RESTful Design** - Follows REST conventions for clean and intuitive endpoints

## Technologies Used

### Core Framework

- **.NET 10.0** - Modern, high-performance web framework
- **ASP.NET Core** - Cross-platform web framework for building APIs
- **C#** - Primary programming language

### Database & ORM

- **SQL Server 2025** - Relational database management system
- **Entity Framework Core 10.0.1** - Object-relational mapping framework
- **Entity Framework Core Migrations** - Database schema versioning and management

### Authentication

- **ASP.NET Core Identity** - Authentication and user management framework
- **Identity API Endpoints** - Built-in RESTful endpoints for user authentication
- **JWT Tokens** - Secure token-based authentication

### Documentation Tools

- **OpenAPI** - API specification standard
- **Swagger UI** - Interactive API documentation interface

### Development Tools

- **Docker Compose** - Container orchestration for SQL Server
- **Entity Framework Core Design Tools** - Database migration and scaffolding tools

## Running Locally

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/get-started) and Docker Compose (for SQL Server)
- A code editor (Visual Studio, Cursor, or VS Code)
- Git

### Environment Setup

1. **Clone the repository** (if you haven't already):

   ```bash
   git clone https://github.com/gideonadeti/erledigt-backend.git
   cd erledigt-backend
   ```

2. **Set up user secrets** (for connection string and other sensitive data):

   ```bash
   cd Erledigt.Api
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=ErledigtDb;User Id=sa;Password=YourSecureP@ss123;TrustServerCertificate=True;"
   ```

   Replace `YourSecureP@ss123` with your desired SQL Server password.

3. **Configure CORS** (if needed):

   By default, only `http://localhost:4200` is allowed. To allow others (e.g. `http://localhost:3000`), add them to the `AllowedOrigins` in `appsettings.Development.json`.

   ```json
   {
     "Cors": {
       "AllowedOrigins": ["http://localhost:4200", "http://localhost:3000"]
     }
   }
   ```

### Database Setup

1. **Set the SQL Server password**:

   The `compose.yaml` file requires the `MSSQL_SA_PASSWORD` environment variable. Create a `.env` file in the project root directory (same location as `compose.yaml`):

   ```bash
   # From the project root directory
   echo "MSSQL_SA_PASSWORD=YourSecureP@ss123" > .env
   ```

   Or manually create `.env` with:

   ```env
   MSSQL_SA_PASSWORD=YourSecureP@ss123
   ```

   **Important:** Use a strong password that meets SQL Server requirements (at least 6 characters, including uppercase, lowercase, numbers, and special characters).

2. **Start SQL Server using Docker Compose**:

   ```bash
   # From the project root directory
   docker compose up -d
   ```

   This command starts SQL Server 2025 in a container running in the background (`-d` means "detached" mode).

3. **Verify SQL Server is running**:

   ```bash
   docker ps
   ```

   You should see a container named `erledigt-sql-server` in the list.

4. **Run database migrations**:

   ```bash
   cd Erledigt.Api
   dotnet ef database update
   ```

   This will create the database schema and apply all migrations.

**Viewing SQL Server logs:**

If you need to view the SQL Server container logs:

```bash
docker logs erledigt-sql-server
```

### Running the Application

1. **Navigate to the API project directory**:

   ```bash
   cd Erledigt.Api
   ```

2. **Restore dependencies**:

   ```bash
   dotnet restore
   ```

3. **Run the application**:

   **Standard mode:**

   ```bash
   dotnet run
   ```

   Or use the specific profile:

   ```bash
   dotnet run --launch-profile https
   ```

   **Watch mode** (automatically restarts on code changes):

   ```bash
   dotnet watch run
   ```

   Or with the HTTPS profile:

   ```bash
   dotnet watch run --launch-profile https
   ```

4. **Access the API**:
   - API Base URL: `http://localhost:5211` or `https://localhost:7005`
   - Swagger UI (Development only): `http://localhost:5211/swagger` or `https://localhost:7005/swagger`
   - OpenAPI JSON: `http://localhost:5211/openapi/v1.json`

5. **Test the API**:
   - Use the Swagger UI to explore and test endpoints
   - Or use the provided `Erledigt.Api.http` file with REST Client extensions
   - Or use tools like Postman or curl

### Stopping the Application

- Press `Ctrl+C` in the terminal to stop the API
- To stop SQL Server: `docker compose down` (from project root)

## Support

If you find this project helpful or interesting, consider supporting me:

[☕ Buy me a coffee](https://buymeacoffee.com/gideonadeti)
