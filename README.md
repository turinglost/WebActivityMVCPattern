# WebActivityMVCPattern
 Example used for training on UI Patterns. This is an ASP.NET MVC example in .NET 6.0

# Setup
This project uses two packages for doing entity framework. These should be installed, but just in case here they are:
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.SqlServer

The first time this program is run on a new machine you will need to do a db migration in the Package Manager Console using Powershell:
Add-Migration InitialCreate
Update-Database