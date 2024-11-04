It seems that the markdown might not be rendering correctly due to the presence of non-standard formatting. Here’s a refined version, ensuring it’s fully compatible with GitHub’s Markdown rendering:

```markdown
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

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```

2. Navigate to the project directory:
   ```bash
   cd BlogApp
   ```

3. Update the `appsettings.json` file with your database connection string.

4. Apply migrations and start the application:
   ```bash
   dotnet ef database update
   dotnet run
   ```

5. Access the API documentation and test endpoints via Swagger at `https://localhost:<port>/swagger`.

## Authentication

The application uses JWT Bearer tokens for authentication. Ensure to include the generated token in the `Authorization` header for protected endpoints when performing delete, add, or update operations.

## Contributing

Contributions are welcome! Feel free to submit issues or pull requests to help improve this project.

---

Enjoy using BlogApp API!
```

Ensure you replace `<repository-url>` with your repository’s actual URL, and this Markdown should render correctly in GitHub’s `README.md`. Let me know if you encounter any additional issues!
