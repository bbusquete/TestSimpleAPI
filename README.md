# The Ballast Lane Applications Technical Exercise

## Introduction to Project
This project is a simple web application in .NET Core developed as a part of Technical Execise to Ballast Lane Applications. It provides a modular structure with separate layers for the API, application logic, domain entities, and infrastructure. The project incorporates popular frameworks and libraries such as ASP.NET Core, nPoco, Serilog, and Swagger. With Docker support, the application can be easily containerized and deployed in a Docker environment.

## About Use Story
This project is an Investiment Portifolio where the user can add investiments buyed on Investment Market, informing the Symbol (ticker) , price, quantity buyed and date buyed.
Also, the user can possibilty to list all investments (Historic of buyed).
When the user get a specific investiment by symbol, it's possible to know a sum quantity and the avarage price.

## About the Structure of Project
This project use Clean Architecture pattern that is an architectural pattern that emphasizes the separation of concerns and the independence of an application's business rules from the external frameworks and technologies it utilizes. It provides a structured approach to software development, promoting code maintainability, testability, and scalability.

#### Presentation Layer:
The Presentation Layer is responsible for handling the user interface and interaction. I didn't have time to develop a User Friendily Presentation, so considery "API" as a Presentation Layer and set it as a Statup Projetct

#### Application Layer:
The Application Layer contains the application-specific business logic and use cases. It acts as an intermediary between the Presentation Layer and the Domain Layer. This layer orchestrates the execution of use cases by coordinating the interactions between different components and applying business rules. It does not contain any infrastructure-related or implementation-specific details.

#### Domain Layer:
The Domain Layer encapsulates the core business logic and entities of the application. It represents the heart of the system and contains business rules, entities, value objects, and domain-specific logic. The Domain Layer is independent of any external frameworks or technologies and should be the most stable and reusable part of the architecture.

#### Infrastructure Layer:
The Infrastructure Layer handles external concerns and provides implementations for data access, external services, frameworks, and other infrastructure-related code.
I decided to use Npoco to connect with Database because it offers the flexibility to submit complex SQL queries without leaving the pattern used in simpler queries and with full control over parameterization


## Tecnologies Used
* .Net Core
* Npoco
* SQL Server
* Serilog
* Swagger


## Tests
### Architecture Tests
These tests examine the relationships and dependencies between various components, modules, layers, or projects within the architecture.

### Application Tests
These tests examine the Behaviors of application, testing if Behaviors is according the User's story

### Infrastructure Tests
These tests examine if the connection with database it's working good


## How Start Application
 1) Set "API" as Startup Project
 2) Configure the ConnectionString at appsettings.json
 3) Execute the script Infrastructure/CreateTables.sql in the same database configured




