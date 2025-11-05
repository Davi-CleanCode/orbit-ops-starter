
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OrbitOps.API/OrbitOps.API.csproj", "OrbitOps.API/"]
RUN dotnet restore "OrbitOps.API/OrbitOps.API.csproj"
COPY . .
WORKDIR "/src/OrbitOps.API"
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "OrbitOps.API.dll"]
