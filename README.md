# TaxiH - Taxi Here Application

## DESCRIPTION

The TaxiH application is intended for people who are in need of a taxi. The application will track available taxis in your area.

## PROJECT TECHNOLOGIES & DEPENDENCIES

### Microsoft SQL Server 
- Version: 16.0

### .NET 8
- Language: C#
- Version: 12.0

### NUGET PACKAGES:
- #### AutoMapper
- Version: 12.0.1

- #### AutoMapper.Extensions.Microsoft.DependencyInjection
- Version: 12.0.1

- #### FluentValidation
- Version: 11.8.1

- #### FluentValidation.DependencyInjectionExtensions
- Version: 11.8.1

- #### MediatR
- Version 12.2.0

- #### Microsoft.EntityFrameworkCore
- Version: 8.0.0

- #### Microsoft.EntityFrameworkCore.SqlServer
- Version: 8.0.0

- #### Microsoft.EntityFrameworkCore.Tools
- Version: 8.0.0

- #### Swashbuckle.AspNetCore (Swagger)
- Version: 6.5.0

## MIGRATIONS:
### CMD: 
- dotnet ef migrations add <MigrationName> 
- dotnet ef database update --project <ProjectName> 
#### Tables
- New Table: dotnet ef migrations add <CT_TableName> - CT For CreateTable
- UpdatingTable: dotnet ef migrations add <UT_TableName> - UT For UpdateTable
#### Views
- New View: dotnet ef migrations add <CVW_ViewName> - CVW For CreateView
- UpdatingTable: dotnet ef migrations add <UVW_ViewName> - UVW For UpdateView
#### Stored procedures
- New Stored Procedure: dotnet ef migrations add <SP_C_StoredProcedureName> - SP for StoredProcedure ; C for Create
- Update Stored Procedure: dotnet ef migrations add <SP_U_StoredProcedureName> - SP for StoredProcedure ; U for Update
#### SQL Functions
- New Function: dotnet ef migrations add <F_C_FunctionName> - F for Function ; C for Create
- Update Function: dotnet ef migrations add <F_U_FunctionName> - F for Function ; U for Update

## CURRENT DB SCHEMA: 

![drawSQL-taxih-export-2023-12-02(2)](https://github.com/ghostl33t/TaxiH/assets/42142523/243636a3-9687-4023-a006-732ba3c5f2bd)

