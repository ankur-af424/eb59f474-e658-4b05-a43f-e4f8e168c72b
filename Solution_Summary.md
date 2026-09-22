Solution Summary — LongestIncrSubsequence

Overview
- Purpose: Find the longest contiguous increasing subsequence from space-separated integers.
- Language/Platform: C# / .NET 8

Projects
- LongestIncrSubsequence.Core
  - Type: Class Library
  - Purpose: Implements `LongestIncrSubsequenceFinder` with the algorithm to compute the longest contiguous increasing subarray.
- LongestIncrSubsequence.Console (ConsoleApp1)
  - Type: Console application
  - Purpose: CLI wrapper that reads input (interactive or args) and prints the result.
- LongestIncrSubsequence.Tests
  - Type: Test project (NUnit)
  - Purpose: Unit tests for the core logic.

Recent/Important changes
- `LongestIncrSubsequence.Core.csproj` was changed from `OutputType=Exe` to `OutputType=Library` so it builds a DLL (`LongestIncrSubsequence.Core.dll`) and can be referenced by the console and test projects.
- A local `NuGet.Config` was added to the solution root to control package sources during restore. For local development I trimmed the local config to use `nuget.org` to avoid issues with an HTTP-only corporate feed. If you need your private feed, re-add it to `NuGet.Config` and consider enabling secure HTTPS or configuring `allowInsecureProtocol` appropriately.

How to run
- Build and run locally:
  - `dotnet restore --configfile NuGet.Config`
  - `dotnet build`
  - `dotnet run --project ConsoleApp1`
- Run tests: `dotnet test`
- Docker:
  - `docker build -t longest-incr-subseq:latest .`
  - `docker run --rm longest-incr-subseq:latest "1 2 3 4 1 2"

Development notes
- `Program.cs` uses top-level statements; Visual Studio will show an error if the startup project is set to the library (`LongestIncrSubsequence.Core`). Ensure `LongestIncrSubsequence.Console` is the startup project when debugging.
- StyleCop analyzers are included in `LongestIncrSubsequence.Core`. They emit warnings about headers and XML doc analysis; reconfigure or add headers if you prefer zero warnings.

Contact
- If you want, I can add a CI workflow (GitHub Actions) to build, test, and publish Docker images.
