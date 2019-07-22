
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
        }
    }
}
```
