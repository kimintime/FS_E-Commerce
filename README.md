# Fullstack Project

![TypeScript](https://img.shields.io/badge/TypeScript-v.4-green)
![SASS](https://img.shields.io/badge/SASS-v.4-hotpink)
![React](https://img.shields.io/badge/React-v.18-blue)
![Redux toolkit](https://img.shields.io/badge/Redux-v.1.9-brown)
![.NET Core](https://img.shields.io/badge/.NET%20Core-v.7-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-v.7-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-v.14-drakblue)

* Frontend: SASS, TypeScript, React, Redux Toolkit
* Backend: ASP .NET Core, Entity Framework Core, PostgreSQL

## Coming Soon:

- E-commerce FullStack project. It's early days yet, but feel free to keep an eye on the progress!

### Todo:
- Install all the needed packages:
    - [ ] AutoMapper
    - [ ] AutoMapper.Extensions.Microsoft.DependencyInjection
    - [ ] Microsoft.EntityFrameworkCore
    - [ ] Microsoft.EntityFrameworkCore.Design
    - [ ] Npgsql.EntityFrameworkCore.PostgreSQL

## Setting Up the Backend (When it exists)
- Create the appsettings.json file in the root of folder Backend. You can refer to the content of file example.json

### Required to run the backend:

- .Net Core (this project is version 7)
- dotnet ef commandline tools
- PostgresSQL

You can change .NET Core version to be compatible with your local machine in the `backend.csproj´ file

1. Run the command `dotnet restore` to restore all the required libraries, then dotnet run to start the server.

2. Add a new migration by running `dotnet ef migrations add <InitialMigration>` and then `dotnet ef database update` to create the new database.

The project is using Swagger UI to run the Api, so you have the option to navigate to `localhost:5001/swagger/index.html` to test out the Api. Note that the port depends on your own configuration of the server settings in the `Program.cs` file.




