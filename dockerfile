# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Kopieer de solution-bestanden en voer een restore uit
COPY Album-Api.sln .
COPY Album.Api/*.csproj ./Album.Api/
COPY Album.Api.Tests/*.csproj ./Album.Api.Tests/
RUN dotnet restore

# Kopieer de rest van de broncode en voer een build uit
COPY . .
RUN dotnet build -c Release --no-restore

# Voer de unit tests uit
RUN dotnet test --no-restore --verbosity normal

# Publicatie Stage
FROM build AS publish
RUN dotnet publish Album.Api/Album.Api.csproj -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

# Exposeer de poort waarop de applicatie luistert
EXPOSE 80

# Definieer de opdracht die wordt uitgevoerd bij het starten van de container
ENTRYPOINT ["dotnet", "Album.Api.dll"]