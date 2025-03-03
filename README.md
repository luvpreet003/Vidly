# Vidly MVC Project

## Overview

This project is a **Video Store Management System** built using the **ASP.NET MVC Framework**. It includes core features like CRUD operations for managing movies and customers, dynamic UI elements like auto-complete, and data persistence using Entity Framework with migrations.

## Features

### 1. **Movies Management**

- Add, Edit, Delete, and View Movies.
- Manage movie details like title, genre, release date, stock availability, etc.

### 2. **Customers Management**

- Add, Edit, Delete, and View Customers.
- Track customer details like name, membership type, and more.

### 3. **Rentals Management**

- Auto-fill customer and movie details using **Twitter Typeahead**.
- Add new rentals dynamically.
- Validate stock availability before processing rentals.

### 4. **Dynamic UI Features**

- **Twitter Typeahead** for autocomplete in new rentals.
- **AJAX calls** for smooth interactions without full-page reloads.
- **Snackbar notifications** for success and error messages using Toastr.

### 5. **Pagination and Filtering**

- Implemented pagination for listing movies and customers.
- Filtering options for quick data searches.

### 6. **Database Management**

- Data persistence using **Entity Framework Code First**.
- Database initialized with **seeding** and maintained using **migrations**.

## Technologies Used

- **ASP.NET MVC Framework**
- **Entity Framework Code First**
- **SQL Server**
- **JavaScript (jQuery, AJAX)**
- **Twitter Typeahead**
- **CSS** for styling
- **Toastr** for notifications

## Installation Instructions

### Prerequisites

- Visual Studio (2022 or later recommended)
- SQL Server
- NuGet Package Manager

### Steps

1. **Clone the Repository:**

   ```bash
   git clone <repository-url>
   cd video-store-mvc
   ```

2. **Restore NuGet Packages:**

   - Open the solution in Visual Studio.
   - Right-click on the solution and select **Restore NuGet Packages**.

3. **Update Database:**

   - Open the **Package Manager Console** in Visual Studio.
   - Run the following commands to apply migrations and seed data:
     ```bash
     Update-Database
     ```

4. **Run the Application:**

   - Press `F5` or click **Start** in Visual Studio to run the application.
   - The application will open in your default browser.

## Key Functionalities

### 1. **New Rentals Workflow**

- **Customer Auto-fill:**

  - Uses **Twitter Typeahead** to fetch and auto-complete customer names based on input.
  - Dynamically updates the selected customer in the backend.

- **Movie Auto-fill:**

  - Similar implementation for movies.
  - Fetches available movies based on input and displays suggestions.

- **Submit Rentals:**

  - Validates stock availability.
  - Adds new rental records to the database.
  - Displays success or error messages via **Toastr notifications**.

### 2. **CRUD Operations**

- **Movies:**
  - Add, edit, delete, and view movies using forms and server-side validation.
- **Customers:**
  - Manage customer details with similar CRUD operations.

### 3. **Data Seeding and Migrations**

- The database is seeded with sample data for testing purposes.
- Migrations are used to maintain schema changes over time.

## Code Structure

### **Folders:**

- `Controllers`: Contains MVC controllers for handling requests.
- `Models`: Contains domain models and data annotations for validation.
- `Views`: Razor views for rendering UI.
- `Scripts`: JavaScript and jQuery scripts for frontend functionality.
- `Content`: CSS files for styling.

### **Key Files:**

- `NewRentalDTO.cs`: DTO for new rentals API.
- `RentalController.cs`: Handles rental-related actions.
- `MovieController.cs` & `CustomerController.cs`: Manage movie and customer CRUD operations.

## API Endpoints

### Customers

- `GET /api/customers?name={query}`: Fetch customers for autocomplete.

### Movies

- `GET /api/movies?title={query}`: Fetch movies for autocomplete.

### Rentals

- `POST /api/newRentals`: Submit new rental requests.

## Debugging Tips

- Use **Console Logs** in the browser's developer tools to debug AJAX calls.
- Check API responses in the **Network** tab.
- Enable detailed error messages in the development environment.

## Future Enhancements

- Add user authentication and authorization.
- Improve UI responsiveness with Bootstrap.
- Add return rentals functionality.
- Generate rental invoices.

