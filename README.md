# FinitiSolutions

## Database Setup (PostgreSQL)

This project requires a **running PostgreSQL database**.  
Make sure PostgreSQL is installed and running on **port 5432** (default).

### 1. **Install PostgreSQL**

If you don’t already have PostgreSQL installed, follow these instructions:

- **Windows / macOS:** Download from the official [PostgreSQL website](https://www.postgresql.org/download/)
- **Linux (Ubuntu):**  
  ```bash
  sudo apt update
  sudo apt install postgresql postgresql-contrib
  
### 2. Start PostgreSQL Service

Make sure PostgreSQL is running:

- **Windows:** The service starts automatically after installation.
- **macOS (Homebrew)**:
  ```bash
  brew services start postgresql
- **Linux**:
  ```bash
  sudo service postgresql start

### 3. Create the Database

Once PostgreSQL is running, create the database for the project:

    CREATE DATABASE finiti;
You can use psql (PostgreSQL's command line interface) or any GUI tool like pgAdmin to execute the above command.

### 4. Set up the User

By default, the project expects the following credentials:

  - Username: postgres
  - Password: admin123

To set or update the password, use the following SQL command:

    ALTER USER postgres WITH PASSWORD 'admin123';
You can use psql (PostgreSQL's command line interface) or any GUI tool like pgAdmin to execute the above command.

## Back-end (.NET 6.0)
Make sure to have version 6.0

### 1. Install NuGet Dependencies
Navigate to the project folder (where the .csproj file exists) and restore all NuGet packages:
    
    dotnet restore

This will install all required dependencies listed in the project file.

### 2. Apply Entity Framework Migrations
Before running the app, ensure your PostgreSQL database is correctly set up (see the database setup section above).
Then apply the Entity Framework Core migrations:

    dotnet ef database update

### 3. Run the Application
Start the API by running:
     
    dotnet run

## Front-end (Angular)
This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 19.2.8.

### Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`.

## Tests (MSTest)
This project includes a dedicated **.NET 6.0 test project** configured for MSTest, Moq, and Entity Framework Core testing.

### Run tests
Make sure you're in the right soulution, and just run the:

    dotnet test


