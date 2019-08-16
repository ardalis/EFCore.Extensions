
[![NuGet](https://img.shields.io/nuget/v/Ardalis.EFCore.Extensions.svg)](https://www.nuget.org/packages/Ardalis.EFCore.Extensions)[![NuGet](https://img.shields.io/nuget/dt/Ardalis.EFCore.Extensions.svg)](https://www.nuget.org/packages/Ardalis.EFCore.Extensions)
[![Build Status](https://dev.azure.com/ardalis/EFCore.Extensions/_apis/build/status/ardalis.EFCore.Extensions?branchName=master)](https://dev.azure.com/ardalis/EFCore.Extensions/_build/latest?definitionId=7&branchName=master)

# EFCore.Extensions

Extension methods to make working with EF Core easier.

- ApplyAllConfigurationsFromCurrentAssembly

## Sample Usage

```
using Ardalis.EFCore.Extensions;
using Microsoft.EntityFrameworkCore

namespace YourNamespace
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        
            // ApplyConfiguration calls must follow base.OnModelCreating()
            builder.ApplyAllConfigurationsFromCurrentAssembly();

			// Apply configurations in a different assembly - just reference a type in that assembly
			modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(typeof(ToDoItem).Assembly);
        }
    }
}
```

## To Test, Run Migrations

A sample migration script to add migrations to a [Clean Architecture](https://github.com/ardalis/CleanArchitecture) solution template is shown here (run from the solution root):

```
dotnet ef migrations add Initial -p .\src\CleanArchitecture.Infrastructure\CleanArchitecture.Infrastructure.csproj -s .\src\CleanArchitecture.Web\CleanArchitecture.Web.csproj -o Data/Migrations
```
