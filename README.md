# ServerSide Solution

## Overview

The `ServerSide` solution is a backend project designed to support applications with a clean and modular architecture. It separates concerns into distinct layers, ensuring maintainability, scalability, and testability.

## Project Structure

The solution is organized into the following layers:

1. **Bll_Services**: Contains the business logic and service implementations.
2. **Dal_Repository**: Handles data access and database interactions.
3. **Dto_Common_Enteties**: Defines Data Transfer Objects (DTOs) for communication between layers.
4. **IBll_Services**: Interfaces for the business logic layer.
5. **IDal_Repository**: Interfaces for the data access layer.
6. **ServerSide**: The main entry point for the application, exposing APIs.

### Folder Details

- **Bll_Services**:
  - Implements business logic for entities such as `Category`, `Company`, `Customer`, `Product`, and `Shopping`.
  - Example: `CategoryBll.cs` contains logic for managing categories.

- **Dal_Repository**:
  - Manages database operations for entities.
  - Example: `CategoryDal.cs` handles CRUD operations for categories.

- **Dto_Common_Enteties**:
  - Defines DTOs like `CategoryDto`, `CompanyDto`, and `CustomerDto` for data transfer between layers.

- **IBll_Services** and **IDal_Repository**:
  - Define interfaces for the business logic and data access layers, ensuring loose coupling and testability.

- **ServerSide**:
  - The main project that integrates all layers and exposes RESTful APIs.

## Getting Started

### Prerequisites

- **.NET SDK**: Version 6.0 or later.
- **IDE**: Visual Studio 2022 or any compatible editor.
- **Database**: SQL Server or any supported database.

### Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone <https://github.com/sari-Yona/CaremicaStore.server>
   cd ServerSide
2. Restore Dependencies:
   dotnet restore
3. Build the Solution:
  dotnet build
4. Run the Application:
  dotnet run --project ServerSide

5. Access the API:
    Open your browser or API client and navigate to https://localhost:5001.

Development Guidelines
Follow clean architecture principles.
Use DTOs for communication between layers.
Write unit tests for business logic and data access layers.
Ensure proper exception handling and logging.
Contributing
Contributions are welcome! To contribute:

Fork the repository.
Create a new branch for your feature or bugfix.
Submit a pull request with a detailed description of your changes.
License
This project is licensed under the MIT License.

Contact
For questions or support, please contact the project maintainer at [email@example.com].


