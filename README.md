# CodeCircle

A community-style ASP.NET Core Razor Pages app: live project feed, profiles, celebrations, collaboration requests, and messaging UI. Data is stored with **Entity Framework Core** and **SQL Server** (LocalDB by default).

## Requirements

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- SQL Server **LocalDB** (included with Visual Studio) or another SQL Server instance you can point the connection string at

## Quick start

```bash
cd CodeCircle
dotnet restore
dotnet ef database update
dotnet run
```

Open the URL shown in the terminal (typically `https://localhost:7xxx`).

If you do not have the EF Core CLI globally:

```bash
dotnet tool install --global dotnet-ef
```

### Dev container (optional)

The repo includes **`.devcontainer/`** so you can use **Dev Containers** in VS Code or Cursor: **Reopen in Container**.

- **`docker-compose.yml`** starts the **.NET 7 dev image** plus **SQL Server 2022** on Linux.
- **`ConnectionStrings__DefaultConnection`** is set inside the app container to use the `db` service (not LocalDB).
- **`postCreateCommand`** runs `dotnet restore`, installs `dotnet-ef` if needed, and **`dotnet ef database update`**.

**Dev-only SQL password** (change in `.devcontainer/docker-compose.yml` if you like): `CodeCircle!Dev2024` for user `sa`. Port **1433** is forwarded so you can connect from tools on your host if needed.

On the host (outside the container), keep using `appsettings.json` / LocalDB as today; the compose file does not change your machine’s SQL Server.

## Configuration

| Setting | Where |
|--------|--------|
| Database | `appsettings.json` → `ConnectionStrings:DefaultConnection` |
| Email (registration / Identity) | User secrets: `BrevoKey`, `BrevoEmail` (see below) |

Default connection string uses LocalDB:

`Server=(localdb)\mssqllocaldb;Database=aspnet-CodeCircle-...`

### Email (Brevo)

Identity is configured with **confirmed account required** (`RequireConfirmedAccount = true`). Registration flows expect a working `IEmailSender` implementation (`Services/EmailSender.cs`), which uses Brevo SMTP.

Set secrets in development (from the project folder):

```bash
dotnet user-secrets set "BrevoKey" "<your-brevo-smtp-key>"
dotnet user-secrets set "BrevoEmail" "<your-brevo-sender-email>"
```

Without these, email-dependent flows will fail at runtime when sending mail.

## Tech stack

- ASP.NET Core 7, Razor Pages
- ASP.NET Core Identity (EF stores)
- EF Core 7 + SQL Server
- Custom CSS (`wwwroot/css/site.css`) and Bootstrap (under `wwwroot/lib`)

## Project layout (high level)

| Area | Purpose |
|------|---------|
| `Pages/` | Razor Pages (e.g. `Index`, `Profile`, `CollabRequests`, `Messages`, `CreateProject`) |
| `Data/` | `ApplicationDbContext`, migrations |
| `Models/` | `Project`, `CollabRequest`, `Celebration`, etc. |
| `Services/` | `EmailSender` (Brevo SMTP) |
| `Areas/Identity/` | Scaffolded Identity UI |

## Build

```bash
dotnet build
```

## License

Specify your license here if the repo is public.
