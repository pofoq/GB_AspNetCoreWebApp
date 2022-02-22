# Markdown File

https://github.com/evgshk/gb-ts-app/ 

-- EntityFramework

dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design

-- Создание миграции. Создает папку Migrations в проекте "-p"
CMD: \GB_AspNetCoreWebApp> dotnet ef migrations add InitialCreate -p Timesheets.DataLayer -s WebApi

-- Применение миграции. Создает БД и таблицы.
CMD: \GB_AspNetCoreWebApp> dotnet ef database update -p Timesheets.DataLayer -s WebApi

-p - Project with DbContext
-s - Startup Project
