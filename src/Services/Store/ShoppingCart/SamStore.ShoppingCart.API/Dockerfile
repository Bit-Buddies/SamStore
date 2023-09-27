#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR "src"
COPY ["Services/Store/ShoppingCart/SamStore.ShoppingCart.API/SamStore.ShoppingCart.API.csproj", "Services/Store/ShoppingCart/SamStore.ShoppingCart.API/"]
COPY ["Services/Store/ShoppingCart/SamStore.ShoppingCart.Application/SamStore.ShoppingCart.Application.csproj", "Services/Store/ShoppingCart/SamStore.ShoppingCart.Application/"]
COPY ["Services/Store/ShoppingCart/SamStore.ShoppingCart.Domain/SamStore.ShoppingCart.Domain.csproj", "Services/Store/ShoppingCart/SamStore.ShoppingCart.Domain/"]
COPY ["Services/Store/ShoppingCart/SamStore.ShoppingCart.Infrastructure/SamStore.ShoppingCart.Infrastructure.csproj", "Services/Store/ShoppingCart/SamStore.ShoppingCart.Infrastructure/"]
COPY ["BuildingBlocks/SamStore.Core/SamStore.Core.csproj", "BuildingBlocks/SamStore.Core/"]
COPY ["BuildingBlocks/SamStore.WebAPI.Core/SamStore.WebAPI.Core.csproj", "BuildingBlocks/SamStore.WebAPI.Core/"]

RUN dotnet restore "Services/Store/ShoppingCart/SamStore.ShoppingCart.API/SamStore.ShoppingCart.API.csproj"

COPY . .
WORKDIR "/src/Services/Store/ShoppingCart/SamStore.ShoppingCart.API/"
RUN dotnet build "SamStore.ShoppingCart.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SamStore.ShoppingCart.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SamStore.ShoppingCart.API.dll"]