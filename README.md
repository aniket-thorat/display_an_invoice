# Invoice Display Application

This is a .NET 8 Web API application that displays invoice data with a web frontend.

## Features

- RESTful API with Swagger documentation
- SQLite database with Entity Framework Core
- Web frontend displaying invoice items
- CORS enabled for cross-origin requests

## Prerequisites

- .NET 8 SDK
- Visual Studio Code or Visual Studio (optional)

## Running the Application

1. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

2. **Build the application:**
   ```bash
   dotnet build
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

4. **Access the application:**
   - **Frontend (Invoice Display):** http://localhost:5000
   - **API Documentation (Swagger):** http://localhost:5000/swagger
   - **API Endpoint:** http://localhost:5000/api/invoice

## API Endpoints

- `GET /api/invoice` - Returns invoice data with items
- `GET /api/data` - Returns sample data

## Database

The application uses SQLite database with Entity Framework Core. The database file (`invoices.db`) will be created automatically when the application runs for the first time.

## Project Structure

```
├── Controllers/          # API Controllers
├── Data/                # Entity Framework Context
├── Models/              # Data Models
├── wwwroot/             # Static files (HTML, CSS, JS)
├── Program.cs           # Application entry point
├── InvoiceApp.csproj    # Project file
└── README.md           # This file
```

## Deployment

For production deployment, you can:

1. **Publish the application:**
   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. **Run the published application:**
   ```bash
   cd publish
   dotnet InvoiceApp.dll
   ```

## Notes

- The application includes sample invoice data that is seeded automatically
- CORS is configured to allow all origins (configure appropriately for production)
- The database is created automatically on first run
