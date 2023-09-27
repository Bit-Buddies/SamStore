#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR "src"
COPY ["Services/Store/Payment/SamStore.Payment.API/SamStore.Payment.API.csproj", "Services/Store/Payment/SamStore.Payment.API/"]
COPY ["BuildingBlocks/SamStore.Core/SamStore.Core.csproj", "BuildingBlocks/SamStore.Core/"]
COPY ["BuildingBlocks/SamStore.WebAPI.Core/SamStore.WebAPI.Core.csproj", "BuildingBlocks/SamStore.WebAPI.Core/"]

RUN dotnet restore "Services/Store/Payment/SamStore.Payment.API/SamStore.Payment.API.csproj"

COPY . .
WORKDIR "/src/Services/Store/Payment/SamStore.Payment.API/"
RUN dotnet build "SamStore.Payment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SamStore.Payment.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SamStore.Payment.API.dll"]