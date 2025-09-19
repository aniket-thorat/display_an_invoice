# Use the official .NET 8 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 8 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["InvoiceApp.csproj", "."]
RUN dotnet restore "./InvoiceApp.csproj"

# Copy the rest of the source code
COPY . .

# Build the application
WORKDIR "/src/."
RUN dotnet build "InvoiceApp.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "InvoiceApp.csproj" -c Release -o /app/publish

# Create final runtime image
FROM base AS final
WORKDIR /app

# Copy published application
COPY --from=publish /app/publish .

# Create directory for SQLite database
RUN mkdir -p /app/data

# Set environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80

# Expose port 80
EXPOSE 80

# Set entry point
ENTRYPOINT ["dotnet", "InvoiceApp.dll"]
