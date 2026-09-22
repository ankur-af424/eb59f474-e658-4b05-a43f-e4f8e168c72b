# LongestIncrSubsequence

A small .NET console application that finds the longest contiguous increasing subsequence from a space-separated list of integers.

Projects
- `LongestIncrSubsequence.Core` — logic for finding the subsequence (class library)
- `LongestIncrSubsequence.Console` (ConsoleApp1) — console app using the core library
- `LongestIncrSubsequence.Tests` — unit tests (NUnit)

Prerequisites
- .NET 8 SDK (https://dotnet.microsoft.com)
- Docker (optional, for container builds)

Quick build & run

Restore and build the solution:
```powershell
dotnet restore --configfile NuGet.Config
dotnet build
```

Run the console app from the solution root:
```powershell
dotnet run --project ConsoleApp1
```

Or run with arguments:
```powershell
dotnet run --project ConsoleApp1 -- "1 2 3 1 2 3 4"
```

Run tests:
```powershell
dotnet test
```

Docker
Build the image (from repository root where `Dockerfile` sits):
```bash
docker build -t longest-incr-subseq:latest .
```

Run the container (it runs the console app; pass input as args):
```bash
docker run --rm longest-incr-subseq:latest "1 2 3 4 1 2"
```

Notes
- If your environment uses a private NuGet feed, keep or update `NuGet.Config` in the solution root. The provided `Dockerfile` copies `NuGet.Config` into the build context so private feeds work in Docker builds.
- `Program.cs` uses top-level statements (no explicit `Main`); this is supported on .NET 6+.

## Project Structure

- `LongestIncrSubsequence.sln` — solution file
- `ConsoleApp1/` (`LongestIncrSubsequence.Console.csproj`) — Console application (startup project)
- `LongestIncrSubsequence.Core/` (`LongestIncrSubsequence.Core.csproj`) — Core library containing `LongestIncrSubsequenceFinder`
- `LongestIncrSubsequence.Tests/` (`LongestIncrSubsequence.Tests.csproj`) — Unit tests (NUnit)

## Test Cases

- Tests live in the `LongestIncrSubsequence.Tests` project. See `TestCases.cs` for example unit tests and inputs.
- Run unit tests with:
```powershell
dotnet test
```

### Code Coverage

- The test project includes `coverlet.collector` to produce coverage data. To collect coverage locally run:
```powershell
dotnet test --collect:"XPlat Code Coverage"
```
- Coverage files are generated under the test result directory (e.g., `TestResults`). Use report converters (e.g., `reportgenerator`) to produce readable HTML reports.

## CI/CD Pipeline

- Recommended: GitHub Actions workflow that runs on every `push` and `pull_request` to build the solution, run tests (with coverage), and optionally build and push a Docker image.
- Jobs:
	- `restore-and-build`: `dotnet restore` and `dotnet build` (fail fast on errors)
	- `test`: `dotnet test` with coverage collection
	- `publish-image` (optional): `docker build` and `docker push` to your registry

### Workflow Triggers

- `push` to the `main` branch (or your primary branch)
- `pull_request` targeting `main`
- Optional: `schedule` (cron) nightly run to produce daily coverage or build artifacts

## Verification Steps

1. Restore and build locally:
```powershell
dotnet restore --configfile NuGet.Config
dotnet build
```
2. Run tests and collect coverage:
```powershell
dotnet test --collect:"XPlat Code Coverage"
```
3. Run the console app interactively:
```powershell
dotnet run --project ConsoleApp1
```
4. Build and run Docker image (optional):
```bash
docker build -t longest-incr-subseq:latest .
docker run --rm longest-incr-subseq:latest "1 2 3 4 1 2"
```

## Projectfiles

- `LongestIncrSubsequence.sln` — solution entry
- `ConsoleApp1/Program.cs` — console entry (top-level statements)
- `LongestIncrSubsequence.Core/LongestIncrSubsequenceFinder.cs` — core algorithm
- `LongestIncrSubsequence.Tests/TestCases.cs` — sample tests

## configurationfiles

- `NuGet.Config` — local package source configuration (solution root)
- `.gitignore`, `.dockerignore` — repository ignores
- `Dockerfile` — multi-stage Docker build for the console app
- Project `.csproj` files — per-project build configuration (see each project folder)
