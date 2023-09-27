#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR "src"
COPY ["Services/Store/Order/SamStore.Order.API/SamStore.Order.API.csproj", "Services/Store/Order/SamStore.Order.API/"]
COPY ["Services/Store/Order/SamStore.Order.Application/SamStore.Order.Application.csproj", "Services/Store/Order/SamStore.Order.Application/"]
COPY ["Services/Store/Order/SamStore.Order.Domain/SamStore.Order.Domain.csproj", "Services/Store/Order/SamStore.Order.Domain/"]
COPY ["Services/Store/Order/SamStore.Order.Infrastructure/SamStore.Order.Infrastructure.csproj", "Services/Store/Order/SamStore.Order.Infrastructure/"]
COPY ["BuildingBlocks/SamStore.Core/SamStore.Core.csproj", "BuildingBlocks/SamStore.Core/"]
COPY ["BuildingBlocks/SamStore.WebAPI.Core/SamStore.WebAPI.Core.csproj", "BuildingBlocks/SamStore.WebAPI.Core/"]

RUN dotnet restore "Services/Store/Order/SamStore.Order.API/SamStore.Order.API.csproj"

COPY . .
WORKDIR "/src/Services/Store/Order/SamStore.Order.API/"
RUN dotnet build "SamStore.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SamStore.Order.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SamStore.Order.API.dll"]