Enjoy using BlogApp API!
## BlogApp API

BlogApp API is an ASP.NET Core-based application that provides CRUD operations (Create, Read, Update, Delete) for blogs and categories. The application supports JWT authentication for delete, add, and update operations, and it creates a default admin user automatically upon first launch.

## Requirements

- .NET 6 or later
- SQL Server Database

## Features

- **Blog Management**: Create, update, read, and delete blogs.
- **Category Management**: Associate blogs with categories for organized classification.
- **JWT Authentication**: Protects sensitive operations like adding, updating, and deleting blogs.
- **Automatic Admin User Creation**: An admin user is created on the first run if no users are found in the database.

## Default Admin User

Upon the first run of the application, a default admin user will be created with the following credentials:

- **Email**: `laith@l.com`
- **Password**: `password`

You can use these credentials to log in and manage the application.

## Getting Started

1. Clone the repository

2. Navigate to the project directory:
   ```bash
   cd BlogApp
