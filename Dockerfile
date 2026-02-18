FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copy solution and project files
COPY BackendAssessment.sln .
COPY src/BackendAssessment.Api/BackendAssessment.Api.csproj src/BackendAssessment.Api/
COPY src/BackendAssessment.Application/BackendAssessment.Application.csproj src/BackendAssessment.Application/
COPY src/BackendAssessment.Domain/BackendAssessment.Domain.csproj src/BackendAssessment.Domain/
COPY src/BackendAssessment.Infrastructure/BackendAssessment.Infrastructure.csproj src/BackendAssessment.Infrastructure/
COPY tests/BackendAssessment.Tests/BackendAssessment.Tests.csproj tests/BackendAssessment.Tests/

# Restore dependencies
RUN dotnet restore

# Copy source code
COPY . .

# Build
RUN dotnet build -c Release --no-restore

# Publish
FROM build AS publish
RUN dotnet publish src/BackendAssessment.Api/BackendAssessment.Api.csproj -c Release -o /app/publish --no-build

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendAssessment.Api.dll"]
