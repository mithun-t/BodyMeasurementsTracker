# Body Measurements Tracker API

This project is a web-based API for tracking body measurements, implemented using .NET Core 8, Entity Framework Core, and PostgreSQL.

---

## Features

- User Management
  - Create, Read, Update, Delete (CRUD) operations for users.
- Body Measurements Tracking
  - Record and track various body metrics such as weight, height, waist size, and more.
  - CRUD operations for body measurements.
- CORS Configuration
  - Allows cross-origin requests to enable communication with a frontend application (e.g., React).
- RESTful API with endpoints mapped to controllers.
- Swagger UI for testing and documentation.

---

## Technologies Used

- **Backend:** .NET Core 8
- **Database:** PostgreSQL
- **ORM:** Entity Framework Core
- **Dependency Injection:** Built-in .NET Core DI
- **API Documentation:** Swagger UI

---

## Prerequisites

1. **.NET SDK**: Install the .NET SDK (version 8 or higher).
2. **PostgreSQL**: Ensure PostgreSQL is installed and running.
3. **Database Connection**: Update the `DefaultConnection` string in the `appsettings.json` file with your PostgreSQL connection details.
4. **Frontend (optional):** React or any other frontend framework that communicates with the API.

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/mithun-t/BodyMeasurementsTracker.git
cd BodyMeasurementsTracker
```

### 2. Configure the Database Connection

Edit the `appsettings.json` file and update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=BodyMeasurementsDB;Username=yourusername;Password=yourpassword"
}
```

### 3. Apply Migrations

Run the following commands to create the database and apply migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the Application

Start the API server:

```bash
dotnet run
```

The API will be available at `https://localhost:5147` (or a different port if specified).

### 5. Test the API

- Open Swagger UI at `https://localhost:5147/swagger` to explore and test API endpoints.

---

## API Endpoints

### User Endpoints

- **GET** `/api/User`: Get all users.
- **POST** `/api/User`: Create a new user.
- **PUT** `/api/User/{id}`: Update a user.
- **DELETE** `/api/User/{id}`: Delete a user.

### Body Measurements Endpoints

- **GET** `/api/BodyMeasurement?userId={userId}`: Get measurements for a user.
- **POST** `/api/BodyMeasurement`: Add a new measurement.
- **PUT** `/api/BodyMeasurement/{id}`: Update an existing measurement.
- **DELETE** `/api/BodyMeasurement/{id}`: Delete a measurement.

---

## CORS Configuration

To enable cross-origin requests for your frontend (e.g., React):

- Update the CORS policy in `Program.cs` to allow requests from your frontend's URL:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Replace with your frontend's URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
```

---

## Future Enhancements

- Add user authentication and authorization (e.g., JWT).
- Integrate frontend application (React or Angular).
- Add features for data visualization and analytics.

---

## License

This project is licensed under the MIT License. Feel free to modify and use it as needed
