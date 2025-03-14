#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y net-tools iproute2 curl
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Shopping.API/Shopping.API.csproj", "Shopping.API/"]
RUN dotnet restore "Shopping.API/Shopping.API.csproj"
COPY . .
WORKDIR "/src/Shopping.API"
RUN dotnet build "Shopping.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopping.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.API.dll"]
