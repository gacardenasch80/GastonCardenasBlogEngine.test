# Zemoga .NET Blog Engine App Solution
Public repository with .NET Test in MVC. Solution to Zemoga .Net Technical Assessment (Jan 2021)

# Specification
1. The project works with .Net Core 3.1 and Entity Framework Core 3.1
2. GastonCardenasBlogEngine.test.Web: Is the UI project implemented with ASP.NET Core
3. GastonCardenas.Test.Tests: Unit tests for application services, built with NUnit
4. GastonCardenas.Test.Domain: Domain model and business rules
5. GastonCardenas.Test.Infrastructure: Data infrastructure with Entity Framework Code First, Repository and Unit of Work patterns
6. GastonCardenas.Test.Common: Common classes and helpers

# Time Spent
The total amount of time used to create this Application was thirty (30) hours

## Prerequisites
.Net Core 3.1
MS SQL Server 

## Installation
1. Open solution folder in file explore
2. locate file DatabaseCreationScript.sql and execute it in local machine, database objects will be created locally (ConnectionString are set locally)
3. Navigate to GastonCardenasBlogEngine.test.Web folder and open a command prompt in Administrator mode
4. Type dotnet run and wait for application initialization be confirmed (will be hosted in http://localhost:5000)

# How to use
You should be able to navigate the app here <http://localhost:5000> as an anonymous user.

## Login as a viewer user
Go to <http://localhost:5000/Security/Login> and login with username "viewer" and any password.

## Login as a writer user
Go to <http://localhost:5000/Security/Login> and login with username "Writer" and any password.

## Login as a editor user
Go to <http://localhost:5000/Security/Login> and login with username "Editor" and any password.

Assessment Test Navigations and functionalities are followed as requested, so from login the use of the functionalities is restricted by the user's role. 