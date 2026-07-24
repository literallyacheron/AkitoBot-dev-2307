FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY *.csproj ./
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
# DONT FORGET TO SET 8080 AS PORT!!!
EXPOSE 8080
ENTRYPOINT ["dotnet", "AkitoBot-dev-2307.dll"]
