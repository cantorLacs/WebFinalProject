I. PROJECT DESCRIPTION
    A web-based property management system developed using ASP.NET Core that facilitates the management of residential properties. The system allows interaction between property owners, managers, and tenants, providing features for apartment listings, appointment scheduling, and internal messaging.

II. PROJECT DEVELOPMENT
    PHASE I. PROJECT ANALYSIS
        1. Requirements Analysis:
           - Multi-user system with role-based access (Owner, Manager, Tenant)
           - Property management functionality (Buildings and Apartments)
           - Appointment scheduling system
           - Internal messaging system
           - Secure authentication and authorization
           - Responsive web interface

        2. Technical Requirements:
           - ASP.NET Core with Razor Pages
           - SQL Server database with Entity Framework Core
           - Bootstrap for responsive design
           - Cookie-based authentication
           - Form validation and data protection

    PHASE II. DESIGN
        1. Database Design:
           - Users table with role differentiation
           - Buildings and Apartments tables for property management
           - Appointments table for scheduling
           - Messages table for internal communication

        2. Application Architecture:
           - Presentation Layer (Pages/)
             * Razor Pages structure for each feature module:
               - Apartments and Apartments-search
               - Buildings and Buildings-search
               - Appointments
               - Messages
               - Auth (Login, Register, Logout)
             * Shared layouts and components
             * Bootstrap-based responsive UI

           - Business Logic Layer
             * Page Models (.cshtml.cs files)
             * Authorization handlers
             * Input validation
             * Business rules implementation

           - Data Layer
             * Models/ - Entity definitions:
               - User.cs (Owner, Manager, Tenant roles)
               - Building.cs
               - Apartment.cs
               - Appointment.cs
               - Message.cs
             * Data/FinalProjectContext.cs - EF Core DbContext
             * Migrations/ - Database schema versioning

           - Infrastructure
             * Authentication: Cookie-based with claims
             * Authorization: Role-based access control
             * Static file serving (wwwroot/)
             * Configuration (appsettings.json)

    PHASE III: IMPLEMENTATION
        1. Core Features Implemented:
           - User authentication and authorization
           - Building and apartment management
           - Appointment scheduling system
           - Internal messaging
           - Search and filter functionality
           
        2. Technical Implementation:
           - Secure user authentication using cookies
           - Data validation using model annotations
           - Entity Framework migrations
           - Responsive UI with Bootstrap
           - Role-based access control

    PHASE IV: TESTING THE PROGRAM
        Test Results Table:
        | User Type | Functional Requirement              | Test Result/Problem(s)     |
        |-----------|-------------------------------------|---------------------------|
        | Owner     | Create/manage buildings             | Passed                   |
        | Manager   | Manage apartments                   | Passed                   |
        | Manager   | Handle appointments                 | Passed                   |
        | Tenant    | View available apartments          | Passed                   |
        | Tenant    | Schedule appointments              | Passed                   |
        | All Users | Authentication                     | Passed                   |
        | All Users | Messaging system                   | Passed                   |

III. CONCLUSION
    Through this project, significant knowledge and experience was gained in:
    - Building enterprise-level web applications using ASP.NET Core
    - Implementing secure authentication and authorization
    - Working with Entity Framework Core and SQL Server
    - Developing responsive web interfaces
    - Applying software development best practices
    - Managing complex data relationships
    - Implementing role-based security

IV. BIBLIOGRAPHY
    1. Microsoft ASP.NET Core Documentation
       https://docs.microsoft.com/en-us/aspnet/core

    2. Entity Framework Core Documentation
       https://docs.microsoft.com/en-us/ef/core/

    3. Bootstrap Documentation
       https://getbootstrap.com/docs

    4. C# Programming Guide
       https://docs.microsoft.com/en-us/dotnet/csharp/

    5. Microsoft SQL Server Documentation
       https://docs.microsoft.com/en-us/sql/

V. ARCHITECTURE DIAGRAM PROMPT
    To generate an architecture diagram for this project, use the following prompt with an AI image generation tool:

    "Create a technical architecture diagram for an ASP.NET Core web application with the following components and their relationships:

    Core Components:
    - Web Browser (Client)
    - ASP.NET Core Web Server
    - Razor Pages
    - Entity Framework Core
    - SQL Server Database

    Key Features to Show:
    1. Client Layer:
       - Web Browser
       - Bootstrap UI
       - JavaScript
       - HTTP Requests

    2. Web Server Layer:
       - ASP.NET Core Pipeline
       - Authentication Middleware
       - Authorization
       - Razor Pages Router

    3. Application Layer:
       - Page Models
       - Business Logic
       - Data Models (User, Building, Apartment, Appointment, Message)
       - Validation

    4. Data Access Layer:
       - Entity Framework Core
       - Database Context
       - Model Configurations
       - Migrations

    5. Database Layer:
       - SQL Server
       - Tables
       - Relationships

    Flow Visualization:
    - Show HTTP request flow from client
    - Authentication/Authorization process
    - Data flow through layers
    - Database operations
    - Response return path

    Style:
    - Use different colors for each layer
    - Include arrows showing data flow
    - Add clear labels for components
    - Use professional technical diagram style
    - Include a legend

    Layout:
    - Vertical layout with client at top
    - Database at bottom
    - Clear separation between layers
    - Show security boundary
    - Include external service connections"

