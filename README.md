# Header Level 1
## Header Level 2
### Header Level 3
etc...

*Italic*
**Bold**
***ItalicBold***

> Blockquotes
>
> with Multiple Paragraphs
>>Nested Blockquotes

- Unordered list
- Use it

---
Learn [more](https://www.markdownguide.org/basic-syntax/ "Basic syntax | Markdown Guid")...
---

## EntityFramework

dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design

-- Создание миграции. Создает папку Migrations в проекте "-p"
**CMD:** \GB_AspNetCoreWebApp> dotnet ef migrations add InitialCreate -p Timesheets.DataLayer -s WebApi

-- Применение миграции. Создает БД и таблицы.
**CMD:** \GB_AspNetCoreWebApp> dotnet ef database update -p Timesheets.DataLayer -s WebApi

-p - *Project with DbContext*
-s - *Startup Project*

##  JWT токен
<https://jwt.io/>

<https://github.com/evgshk/gb-ts-app/>
