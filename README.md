# CodeCircle

ASP.NET Core Razor Pages app with a live project feed, profiles, celebrations, collaboration requests, and a messaging UI. Persistence uses **Entity Framework Core** and **SQL Server** (LocalDB for local development).

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- SQL Server **LocalDB** (typical with Visual Studio on Windows) or any SQL Server instance you configure via connection string

## Run locally

From the project directory (the folder that contains `CodeCircle.csproj`):

```bash
dotnet restore
dotnet ef database update
dotnet run
```

Use the URL printed in the terminal (HTTPS port varies).

Install the EF Core CLI if needed:

```bash
dotnet tool install --global dotnet-ef
```

## Configuration

| Topic | Location |
|--------|-----------|
| Database | `appsettings.json` → `ConnectionStrings:DefaultConnection` |
| SMTP (registration / email confirmation) | [.NET user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) — see **Email** below |

Do **not** commit real passwords, API keys, or production connection strings. Use user secrets locally and environment variables or a secret store in deployed environments.

### Email

Identity uses **email confirmation** (`RequireConfirmedAccount = true`). Outgoing mail is sent via `Services/EmailSender.cs` (Brevo SMTP).

Local development (run from the project folder):

```bash
dotnet user-secrets set "BrevoKey" "<your-smtp-key>"
dotnet user-secrets set "BrevoEmail" "<your-sender-address>"
```

If these are missing, flows that send email will fail when mail is triggered.

## Dev container (optional)

The **`.devcontainer/`** folder supports **Dev Containers** in VS Code or Cursor (**Dev Containers: Reopen in Container**).

Compose runs a .NET 7 dev environment and SQL Server. The app container uses `ConnectionStrings__DefaultConnection` pointing at the `db` service. `postCreateCommand` runs `dotnet restore` and `dotnet ef database update`.

Configure the SQL Server **SA password** and the matching password in the app connection string inside **`.devcontainer/docker-compose.yml`**. Use a strong value; treat that file like any other credential-bearing config if the repo is shared or public. Port **1433** may be published for optional host access.

LocalDB / host `appsettings.json` are unchanged when you are **not** using the dev container.

## Tech stack

- ASP.NET Core 7, Razor Pages  
- ASP.NET Core Identity (EF Core stores)  
- EF Core 7, SQL Server  
- CSS in `wwwroot/css/site.css`; Bootstrap under `wwwroot/lib`

## Repository layout

| Path | Role |
|------|------|
| `Pages/` | Razor Pages |
| `Data/` | DbContext and EF migrations |
| `Models/` | Domain models |
| `Services/` | Email sender |
| `Areas/Identity/` | Identity UI |

## Build

```bash
dotnet build
```

## License

Add a license file and a one-line note here (for example MIT, Apache-2.0, or “All rights reserved”) when you publish the repository.
