## Require

```
>= Windows 10 Pro 22H2 OS Build 19045.3693
Visual Studio 2022
PostgreSQL 16
ComponentOne 2023v2 (Active). Install UWP Edition (>=2023v2 790)
.NET 7.0 SDK >= 7.0.404
dotnet --list-runtimes support Microsoft.NETCore.App 5.0.17
dotnet-ef version 5.0.17
```


## Extensions

```
https://marketplace.visualstudio.com/items?itemName=TemplateStudio.TemplateStudioForUWP
```


## How to setup?

![Alt text](./images/visual_studio_installer.png)
```
Open application:
  Visual Studio Installer
  import ~/project/universal-windows-platform-c#/.vsconfig
```

## Migration

### Document

```bash
https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
https://github.com/dotnet/EntityFramework.Docs/tree/main/samples/core/GetStarted
```

### How to install?

```bash
dotnet tool install --global dotnet-ef --version 5.0.17
dotnet-ef --version
```

### Using an Existing Database

```bash
cd ~\project\universal-windows-platform-c#.Migration
dotnet ef dbcontext scaffold "Host=[localhost];Username=[user];Password=[pass];Database=[database]" Npgsql.EntityFrameworkCore.PostgreSQL
```

### How to use?

Update config
```
~\project\universal-windows-platform-cs.Migration/appsettings.json

{
    "ConnectionString": {
        "PostgreSQL": "Host=[localhost];Username=[user];Password=[pass];Database=[database]"
    }
}
```

Init
```bash 
cd ~project\universal-windows-platform-cs.Migration
dotnet ef migrations add InitialCreate --framework net5.0
```

Update
```bash 
cd ~project\universal-windows-platform-cs.Migration
dotnet ef database update --framework net5.0
```