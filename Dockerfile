# Multi-stage Dockerfile for building and running the Console app (net8.0)

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy NuGet config if present (helps with private feeds)
COPY NuGet.Config .

# Copy project files and restore
COPY LongestIncrSubsequence.Core/LongestIncrSubsequence.Core.csproj LongestIncrSubsequence.Core/
COPY ConsoleApp1/LongestIncrSubsequence.Console.csproj ConsoleApp1/
COPY LongestIncrSubsequence.Tests/LongestIncrSubsequence.Tests.csproj LongestIncrSubsequence.Tests/

RUN dotnet restore ConsoleApp1/LongestIncrSubsequence.Console.csproj --configfile NuGet.Config

# Copy the rest of the sources
COPY . .
WORKDIR /src/ConsoleApp1

# Publish release
RUN dotnet publish -c Release -o /app --no-restore

# Runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .

# Entry point: runs the console app
ENTRYPOINT ["dotnet", "LongestIncrSubsequence.Console.dll"]
