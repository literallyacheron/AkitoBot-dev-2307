# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY *.csproj ./
COPY . ./
RUN dotnet restore

# Build and publish the release
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime environment
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set the entry point to your compiled bot assembly
ENTRYPOINT ["dotnet", "AkitoBot-dev-2307"]
