FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["WebAPIMarcaAutos/WebAPIMarcaAutos.csproj", "WebAPIMarcaAutos/"]
RUN dotnet restore "WebAPIMarcaAutos/WebAPIMarcaAutos.csproj"
COPY . .
WORKDIR "/src/WebAPIMarcaAutos"
RUN dotnet build "WebAPIMarcaAutos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPIMarcaAutos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Ejecutar migraciones antes de iniciar la API
ENTRYPOINT ["sh", "-c", "dotnet WebAPIMarcaAutos.dll && dotnet ef database update"]
