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

## REST API DOC
### MIGRATIONS:
#### CMD: 
- ``` dotnet ef migrations add <MigrationName> ```
- ``` dotnet ef database update --project <ProjectName> ``` 
##### Tables
- New Table: ``` dotnet ef migrations add <CT_TableName> ``` - CT For CreateTable
- UpdatingTable: ``` dotnet ef migrations add <UT_TableName> ``` - UT For UpdateTable
##### Views
- New View: ``` dotnet ef migrations add <CVW_ViewName> ``` - CVW For CreateView
- UpdatingTable: ``` dotnet ef migrations add <UVW_ViewName> ``` - UVW For UpdateView
##### Stored procedures
- New Stored Procedure: ``` dotnet ef migrations add <SP_C_StoredProcedureName> ``` - SP for StoredProcedure ; C for Create
- Update Stored Procedure: ``` dotnet ef migrations add <SP_U_StoredProcedureName> ``` - SP for StoredProcedure ; U for Update
##### SQL Functions
- New Function: ``` dotnet ef migrations add <F_C_FunctionName> ``` - F for Function ; C for Create
- Update Function: ``` dotnet ef migrations add <F_U_FunctionName> ``` - F for Function ; U for Update

### MEDIATR:
#### Usage:
##### POST / PATCH / DELETE
1. Create the new Command in the folder 'Commands'
```
public record Add<Name>Command(DTO dtoInstance) : IRequest;
```
- DTO dtoInstance - Parameter that will trigger handler.
2. Create a new handler. Inject required repository.
``` public class Add<Name>Handler : IRequestHandler<Add<Name>Command>
    async Task IRequestHandler<Add<Name>Command>.Handle(Add<Name>Command request, CancellationToken cancellationToken)
    {
      //Method from repository call
    }
```
3. Trigger handler in a Controller:
```
   await _mediator.Send(new Add<Name>Command(DTO));
```  
##### GET
1. Create the new Query in the folder 'Queries'.
```
    public record Get<Name>Query(DTO dtoInstance) : IRequest<ResponseInstance>;
```
- DTO dtoInstance: If request has any body parsed. 
- IRequest<ResponseInstance> - Generated under Services => ResponseService => ResponseInstance => Returns statusCode and message.  
2. Create a new handler. Inject required repository.
```
    public class Get<Name>Handler : IRequestHandler<DTO dtoInstance, ResponseInstance>
    public async Task<ResponseInstance> Handle(Get<Name>Query request, CancellationToken cancellationToken)
```
3. Trigger handler in a Controller: 
```
    var res = await _mediator.Send(new Get<Name>Query(dtoInstance));
```

## MAUI DOC: 
- To run properly, update Visual Studio version with neccessary dependencies related to the MAUI.
- Install HAXM (Turn On or Off Windows Features -> Hyper-V)
- Install Emulators
- Install SDK's (Current 8.0)
- Andorid
- IOS

### HTTPS SSL/TSL - ANDROID CERTIFICATION
- 1.Install the Visual Studio extension from: Conveyor by Keyoti 2022.
- 2.Run an API; it should be on port 45455/45456 (the original port, such as [7239/5136 or another], should also be available).
- 3.After the API application starts, the Conveyor window should appear in the left corner.
- 4.Download the certificate from: http://192.168.X.X:XXXXX/conveyor_root.crt.
- 5.Install the downloaded certificate on the Emulator or Android Phone.
- 6.Run https://192.168.X.X:XXXXX/swagger/index.html (if Swagger is enabled) to check if the site is secured.
- 7.In the Firewall, create an inbound rule for ports 45455 and 45456.
- 8.In the application code, generate the following files/folders (Use the Visual Studio Editor for file creation; otherwise, you'll need to manually modify the .csproj file):
###### Generate under Platforms/Android: 'xml' and 'raw' folders.
###### In the 'raw' folder, add the certificate as an existing item (located in Downloads).
###### In the 'xml' folder, add 'network_security_config.xml'.
###### Paste the following XML code: [Insert XML code here].
  ```
    <?xml version="1.0" encoding="utf-8"?>
    <network-security-config>
    	<domain-config>
    		<domain includeSubdomains="true">Your IPv4</domain>
    		<trust-anchors>
    			<certificates src="@raw/nameOfCertificate - by default converoy_root (without extension)">
    			</certificates>
    		</trust-anchors>
    	</domain-config>
    </network-security-config>
  ```
- 9.Press ALT + Left Mouse click to check if the certificate installation starts executing. If it does, then it is OK.
- 10.Edit the AndroidManifest.xml file (Open it with a right-click: Open With => Automatic Editor Selector (XML)) to access the XML schema.
- 11.Add android:networkSecurityConfig="@xml/network_security_config" to the application element.
- 12.Sometimes, Visual Studio could create some random bugs. Just exit it and run it again; it should resolve those issues.
- 13.Test if the application triggers requests.

## CURRENT DB SCHEMA: 

![drawSQL-taxih-export-2023-12-02(2)](https://github.com/ghostl33t/TaxiH/assets/42142523/243636a3-9687-4023-a006-732ba3c5f2bd)

