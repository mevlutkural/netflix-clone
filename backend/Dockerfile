FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/NetflixClone.API/NetflixClone.API.csproj", "src/NetflixClone.API/"]
COPY ["src/NetflixClone.Application/NetflixClone.Application.csproj", "src/NetflixClone.Application/"]
COPY ["src/NetflixClone.Domain/NetflixClone.Domain.csproj", "src/NetflixClone.Domain/"]
COPY ["src/NetflixClone.Infrastructure/NetflixClone.Infrastructure.csproj", "src/NetflixClone.Infrastructure/"]
RUN dotnet restore "src/NetflixClone.API/NetflixClone.API.csproj"
COPY . .
WORKDIR "/src/src/NetflixClone.API"
RUN dotnet build "NetflixClone.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetflixClone.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetflixClone.API.dll"] 