# Saschas Clean Architecture Project Template

This is a template for a clean architecture project in C# Console. It is based on the clean architecture principles by Uncle Bob. 
The project is structured in a way that it is easy to understand and to extend. It is also easy to test and to maintain.

I have published this Template on Visual Studio Marketplace. You can [download](https://marketplace.visualstudio.com/search?term=SaschaManns&target=VS&category=All%20categories&vsVersion=&sortBy=Relevance) it from there and use it in your projects.


## Features

1. Preconfigured for Dependency Injection
1. Preinstalled the following Nuget Packages:
	1. Ardalis.GuardClauses
	1. Coverlet.Collector
	1. FluentAssertions
	1. FluentValidationq
	1. JunitXml.TestLogger
	1. Mapster
	1. Mapster.EFCore
	1. Microsoft.Extensions.Hosting
	1. Microsoft.Extensions.Configuration
	1. Microsoft.EntityFrameworkCore
	1. Microsoft.EntityFrameworkCore.Analyzer
	1. Microsoft.EntityFrameworkCore.Design
	1. Microsoft.EntityFrameworkCore.SqlServer
	1. Microsoft.EntityFrameworkCore.Tools
	1. NLog
	1. NLog.Extensions.Logging
	1. Sentry
	1. Sentry.Extensions.Logging
	1. SimdLinq
	1. SonarAnalyzer.CSharp
	1. Spectre.Console

## How to use this template

Download the VSIX from Visual Studio Marketplace and install it. Then create a new project in Visual Studio and select the "Clean Architecture Project" template.

## Project structure

1. **Application**: This layer contains the use cases of the application. It is the most high-level layer and contains the business logic of the application. It is independent of the infrastructure and can be tested without any dependencies.
    1. **Entities**: This directory contains the entities of the use cases.
    1. **Interfaces**: This directory contains the interfaces of the use cases in underlying layers.
    1. **Mappers**: This directory contains the mappers that map entities to DTOs and vice versa.
    1. **Models**: This directory contains the models of the use cases and other stuff.
    1. **Pipelines**: This directory contains the pipelines that are used to process the use cases.
    1. **Services**: This directory contains the services that are used in the use cases.
    1. **Validators**: This directory contains the validators that are used to validate the input of the use cases.
1. **Assets**: This directory contains the assets of the application like images, fonts, etc.
1. **Domain**: This layer contains the entities and value objects of the application. It is the most high-level layer and contains the business logic of the application. It is independent of the infrastructure and can be tested without any dependencies.
    1. **Aggregates**: This directory contains the aggregates of the domain.
        1. **Entities**: This directory contains the entities of the domain.
        1. **Specifications**: This directory contains the specifications that are used to query the entities.
        1. **ValueObjects**: This directory contains the value objects of the domain.
    1. **Interfaces**: This directory contains the interfaces from underlying layers.
    1. **Mappers**: This directory contains the mappers that map entities to DTOs and vice versa.
    1. **Models**: This directory contains the models of the domain and other stuff.
    1. **Pipelines**: This directory contains the pipelines that are used to process the domain.
    1. **Services**: This directory contains the services that are used in the domain.   
    1. **Validators**: This directory contains the validators that are used to validate the entities.	
1. **Infrastructure**: This layer contains the implementations of the interfaces from the application layer. It is the most low-level layer and contains the implementation details of the application. It is dependent on the application and domain layer.
	1. **Data**: This directory contains the data access layer of the application.
        1. **DBContexts**: This directory contains the EF Contexts.
		1. **EF-Diagrams**: This directory contains the EF Diagrams.
        1. **Migrations**: This directory contains the EF Migrations.
        1. **Repositories**: This directory contains the EF Repositories.
    1. **Entities**: This directory contains the EF Entities.
    1. **Helpers**: This directory contains the helpers that are used in the implementations.
	1. **Interfaces**: This directory contains the interfaces of the implementations.
	1. **Mappers**: This directory contains the mappers that map entities to DTOs and vice versa.
	1. **Models**: This directory contains the models of the implementations and other stuff.
	1. **Pipelines**: This directory contains the pipelines that are used to process the implementations.
	1. **Services**: This directory contains the services that are used in the implementations.
	1. **Validators**: This directory contains the validators that are used to validate the input of the implementations.

## Documentation

In Program.cs a host service is set up (`ConsoleService`). This step was considered to enable both Dependency Injection and configuration via a JSON file. Also, a clean initialization and termination of the application is done via AppLifetime.

### Configuration

The configuration is done via the `appsettings.json` file. Here you can adjust the database connection and the other stuff.

Also, the configuration of the logging is done via the `nlog.config` file.

### Error Handling

We use the NLog framework to log the errors. The configuration for this is in the `nlog.config` file.

Errors and exceptions are logged in an Sentry instance and the affected developers are informed.

## Contributing

If you want to contribute to this project, please fork the repository and create a pull request. I will review it and merge it if it is good.