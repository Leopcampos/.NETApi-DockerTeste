#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DockerTeste.Api/DockerTeste.Api.csproj", "DockerTeste.Api/"]
COPY ["DockerTeste.Infra.Data/DockerTeste.Infra.Data.csproj", "DockerTeste.Infra.Data/"]
COPY ["DockerTeste.Domain/DockerTeste.Domain.csproj", "DockerTeste.Domain/"]
RUN dotnet restore "./DockerTeste.Api/DockerTeste.Api.csproj"
COPY . .
WORKDIR "/src/DockerTeste.Api"
RUN dotnet build "./DockerTeste.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DockerTeste.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerTeste.Api.dll"]