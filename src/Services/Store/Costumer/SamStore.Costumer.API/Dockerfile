#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR "src"
COPY ["Services/Store/Costumer/SamStore.Costumer.API/SamStore.Costumer.API.csproj", "Services/Store/Costumer/SamStore.Costumer.API/"]
COPY ["Services/Store/Costumer/SamStore.Costumer.Application/SamStore.Costumer.Application.csproj", "Services/Store/Costumer/SamStore.Costumer.Application/"]
COPY ["Services/Store/Costumer/SamStore.Costumer.Domain/SamStore.Costumer.Domain.csproj", "Services/Store/Costumer/SamStore.Costumer.Domain/"]
COPY ["Services/Store/Costumer/SamStore.Costumer.Infrastructure/SamStore.Costumer.Infrastructure.csproj", "Services/Store/Costumer/SamStore.Costumer.Infrastructure/"]
COPY ["BuildingBlocks/SamStore.Core/SamStore.Core.csproj", "BuildingBlocks/SamStore.Core/"]
COPY ["BuildingBlocks/SamStore.WebAPI.Core/SamStore.WebAPI.Core.csproj", "BuildingBlocks/SamStore.WebAPI.Core/"]

RUN dotnet restore "Services/Store/Costumer/SamStore.Costumer.API/SamStore.Costumer.API.csproj"

COPY . .
WORKDIR "/src/Services/Store/Costumer/SamStore.Costumer.API/"
RUN dotnet build "SamStore.Costumer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SamStore.Costumer.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SamStore.Costumer.API.dll"]