# C# Learning Projects

A solution containing multiple C# projects for learning and experimentation.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (17.10+) or [VS Code](https://code.visualstudio.com/) with C# extension

## Project Structure

~~~
csharp-projects/
├── csharp.slnx              # Solution file (contains all projects)
├── README.md
├── guess-game/              # Project 1: Number guessing game
│   ├── guess-game.csproj
│   └── Program.cs
├── another-project/         # Project 2: ...
│   ├── another-project.csproj
│   └── Program.cs
└── ...
~~~

## Quick Start

### Build All Projects

~~~bash
dotnet build
~~~

### Run a Specific Project

~~~bash
dotnet run --project guess-game
~~~

## Managing Projects

### Create a New Project

1. **Create the project** (from solution root folder):

~~~bash
# Console app
dotnet new console -n my-new-project

# Class library
dotnet new classlib -n my-library

# Other templates: webapi, blazor, maui, etc.
dotnet new list   # See all available templates
~~~

2. **Add project to solution**:

~~~bash
dotnet sln add my-new-project
~~~

3. **Verify it was added**:

~~~bash
dotnet sln list
~~~

### Delete a Project

1. **Remove from solution**:

~~~bash
dotnet sln remove my-old-project
~~~

2. **Delete the project folder**:

~~~bash
# Windows (Command Prompt)
rmdir /s /q my-old-project

# Windows (PowerShell)
Remove-Item -Recurse -Force my-old-project

# macOS/Linux
rm -rf my-old-project
~~~

### Rename a Project

~~~bash
# 1. Remove old project from solution
dotnet sln remove old-name

# 2. Rename the folder
mv old-name new-name              # macOS/Linux
ren old-name new-name             # Windows

# 3. Rename the .csproj file inside
mv new-name/old-name.csproj new-name/new-name.csproj    # macOS/Linux
ren new-name\old-name.csproj new-name.csproj            # Windows

# 4. Add back to solution
dotnet sln add new-name
~~~

## Build & Run

### Build

| Command | Description |
|---------|-------------|
| `dotnet build` | Build all projects in solution |
| `dotnet build my-project` | Build specific project |
| `dotnet build -c Release` | Build in Release mode |

### Run

| Command | Description |
|---------|-------------|
| `dotnet run --project guess-game` | Run specific project |
| `dotnet run --project guess-game -- arg1 arg2` | Run with arguments |

### Clean

~~~bash
# Remove build outputs
dotnet clean
~~~

### Restore Dependencies

~~~bash
dotnet restore
~~~

## Common Project Templates

| Template | Command | Description |
|----------|---------|-------------|
| Console App | `dotnet new console -n name` | Command-line application |
| Class Library | `dotnet new classlib -n name` | Reusable library |
| xUnit Tests | `dotnet new xunit -n name` | Unit test project |
| Web API | `dotnet new webapi -n name` | REST API |
| Blazor | `dotnet new blazor -n name` | Web UI framework |

## Adding Project References

If one project depends on another:

~~~bash
# Add reference: my-app depends on my-library
dotnet add my-app reference my-library
~~~

## Projects

| Project | Description | Run Command |
|---------|-------------|-------------|
| guess-game | Number guessing game | `dotnet run --project guess-game` |
| | | |
| | | |

---

## Cheat Sheet

~~~bash
# Create and add new project
dotnet new console -n project-name && dotnet sln add project-name

# Remove and delete project
dotnet sln remove project-name && rm -rf project-name

# Build and run
dotnet build && dotnet run --project project-name

# List all projects in solution
dotnet sln list
~~~