This project is following a Udemy course.
I'd estimate that about 90%-95% of it will be exactly as found in the course.


common commands used
for personal reference

dotnet watch run

Entity Framework
    Create migration
        dotnet ef migrations add <migration name>
    Remove migration
        dotnet ef migrations remove
    Update db
        dotnet ef database update 

SQLite
    view db via ctrl+shift+p and searching for SQLite

Debugging in VS Code
    1. dotnet watch --no-hot-reload
    2. .NET Core Attach
    3. breakpoint jazz aka profit?

Extensions
    alexcvzz.vscode-sqlite
    ms-dotnettools.csharp
    kreativ-software.csharpextensions
    Angular.ng-template

Program starts from Program.cs where the builder is.
This also contains the services container.