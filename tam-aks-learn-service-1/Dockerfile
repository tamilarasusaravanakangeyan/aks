# filepath: /tam-aks-learn-service/Dockerfile
# Use the official .NET runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/tam-aks-learn-service.csproj", "./"]
RUN dotnet restore "tam-aks-learn-service.csproj"
COPY ./src .
WORKDIR "/src"
RUN dotnet publish -c Release -o /app/publish

# Create final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "tam-aks-learn-service.dll"]