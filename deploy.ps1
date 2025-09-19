# PowerShell deployment script for Invoice Application

Write-Host "Starting Invoice Application deployment..." -ForegroundColor Green

# Check if .NET 8 is installed
try {
    $dotnetVersion = dotnet --version
    Write-Host "Found .NET version: $dotnetVersion" -ForegroundColor Green
} catch {
    Write-Host "Error: .NET 8 SDK is not installed. Please install it from https://dotnet.microsoft.com/download" -ForegroundColor Red
    exit 1
}

# Restore packages
Write-Host "Restoring NuGet packages..." -ForegroundColor Yellow
dotnet restore

if ($LASTEXITCODE -ne 0) {
    Write-Host "Error: Failed to restore packages" -ForegroundColor Red
    exit 1
}

# Build the application
Write-Host "Building the application..." -ForegroundColor Yellow
dotnet build

if ($LASTEXITCODE -ne 0) {
    Write-Host "Error: Failed to build application" -ForegroundColor Red
    exit 1
}

# Run the application
Write-Host "Starting the application..." -ForegroundColor Green
Write-Host "The application will be available at:" -ForegroundColor Cyan
Write-Host "  - Frontend: http://localhost:5000" -ForegroundColor Cyan
Write-Host "  - API Documentation: http://localhost:5000/swagger" -ForegroundColor Cyan
Write-Host "  - API Endpoint: http://localhost:5000/api/invoice" -ForegroundColor Cyan
Write-Host ""
Write-Host "Press Ctrl+C to stop the application" -ForegroundColor Yellow

dotnet run
