#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Devops.Tests/Devops.Tests.csproj", "Devops.Tests/"]
COPY ["Devops.App/Devops.App.csproj", "Devops.App/"]
RUN dotnet restore "./Devops.Tests/./Devops.Tests.csproj"
COPY . .
WORKDIR "/src/Devops.Tests"
RUN dotnet build "./Devops.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Devops.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Devops.Tests.dll"]