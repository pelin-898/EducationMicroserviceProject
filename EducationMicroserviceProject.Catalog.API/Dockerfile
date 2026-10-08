# 1. runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# 2. build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# csproj kopyala
COPY ["EducationMicroserviceProject.Catalog.API.csproj", "./"]

# restore
RUN dotnet restore

# tüm dosyalarý kopyala
COPY . .

# build
RUN dotnet build "EducationMicroserviceProject.Catalog.API.csproj" -c Release -o /app/build

# publish
FROM build AS publish
RUN dotnet publish "EducationMicroserviceProject.Catalog.API.csproj" -c Release -o /app/publish

# final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EducationMicroserviceProject.Catalog.API.dll"]