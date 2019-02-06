# Visual Studio shortcuts
Visual Studio provides many shortcuts accessed both from keyboard combinations and/or menu items.

* Visual Studio has different profiles that are setup either when Visual Studio is installed or after the initial installation.
  * Installation of third party products can affect shortcuts and menu items. For example, using Jet Brains [Resharper](https://www.jetbrains.com/dotnet/?gclid=CjwKCAiAqOriBRAfEiwAEb9oXaBp4XBMON9HbyjtQ7rSXqDplW0cDW9HBqTVxl0Y16jFOg8GJ9XeeRoCS3EQAvD_BwE&gclsrc=aw.ds). 
  * There are several key combinations that will not be affected such as save the current file <kbd>Ctrl</kbd>+<kbd>S</kbd> while [Peek at definition](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-view-and-edit-code-by-using-peek-definition-alt-plus-f12?view=vs-2017) <kbd>Alt</kbd>+<kbd>F2</kbd> can be different between developers dependent on perferences set which means <kbd>Alt</kbd>+<kbd>F12</kbd> may be the keyboard shortcut for another developer.
  
 ## How to: Move around in the Visual Studio IDE

[Documentation](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-move-around-in-the-visual-studio-ide?view=vs-2017)

The integrated development environment (IDE) has been designed to allow you to move from window to window and file to file in several different ways, depending on your preference or project requirements. You can choose to cycle through open files in the editor, or cycle through all active tool windows in the IDE. You also can switch directly to any file open in the editor, regardless of the order in which it was last accessed. These features can help increase your productivity when working in the IDE.

> Learn 
> * Keyboard shortcuts.
> * Navigating files in the editor.
> * Navigate tool windows in the IDE.

## Solutions and projects in Visual Studio

[Documentation](https://docs.microsoft.com/en-us/visualstudio/ide/solutions-and-projects-in-visual-studio?view=vs-2017)

The integrated development environment (IDE) has been designed to allow you to move from window to window and file to file in several different ways, depending on your preference or project requirements. You can choose to cycle through open files in the editor, or cycle through all active tool windows in the IDE. You also can switch directly to any file open in the editor, regardless of the order in which it was last accessed. These features can help increase your productivity when working in the IDE.

> Learn
> * Projects
> * Solutions
> * Creating new projects
> * Managing projects in Solution Explorer


## Compile and build in Visual Studio

When you build source code, the build engine creates assemblies and executable applications. In general, the build process is very similar across many different project types such as Windows, ASP.NET, mobile apps, and others. The build process is also similar across programming languages such as C#.

By building your code often, you can quickly identify compile-time errors, such as incorrect syntax, misspelled keywords, and type mismatches. You can also detect and correct run-time errors, such as logic errors and semantic errors, by building and running debug versions of the code.

A successful build validates that the application's source code contains correct syntax and that all static references to libraries, assemblies, and other components can resolve. An application executable is produced that can be tested for proper functioning in both a [debugging environment](https://docs.microsoft.com/en-us/visualstudio/debugger/index?view=vs-2017) and through a variety of manual and automated tests to validate code quality. Once the application has been fully tested, you can compile a release version to deploy to your customers. For an introduction to this process, see Walkthrough: Building an application.

> [Debugging in Visual Studio](https://docs.microsoft.com/en-us/visualstudio/debugger/?view=vs-2017).
> 
> [Getting started with debugging in Visual Studio video](https://mva.microsoft.com/en-US/training-courses-embed/getting-started-with-visual-studio-2017-17798/Debugger-Feature-tour-of-Visual-studio-2017-sqwiwLD6D_1111787171) . 

## Testing tools in Visual Studio

[Documentation](https://docs.microsoft.com/en-us/visualstudio/test/improve-code-quality?view=vs-2017)
* The Test Explorer window makes it easy to integrate unit tests into your development practice. You can use the Microsoft [unit test](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-your-code?view=vs-2017) framework or one of several third-party and open source frameworks.
* [IntelliTest](https://docs.microsoft.com/en-us/visualstudio/test/generate-unit-tests-for-your-code-with-intellitest?view=vs-2017) automatically generates unit tests and test data for your managed code. 
* [Live Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/live-unit-testing?view=vs-2017) automatically runs unit tests in the background, and graphically displays code coverage and test results in the Visual Studio code editor.

## Connect to databases
 
[Documentation](https://docs.microsoft.com/en-us/visualstudio/ide/advanced-feature-overview?view=vs-2017)

Server Explorer helps you browse and manage SQL Server instances and assets locally, remotely, and on Azure, Salesforce.com, Office 365, and websites. To open Server Explorer, on the main menu, choose View > Server Explorer. For more information on using Server Explorer, see Add new connections.

SQL Server Data Tools (SSDT) is a powerful development environment for SQL Server, Azure SQL Database, and Azure SQL Data Warehouse. It enables you to build, debug, maintain, and refactor databases. You can work with a database project, or directly with a connected database instance on- or off-premises.

SQL Server Object Explorer in Visual Studio provides a view of your database objects similar to SQL Server Management Studio. SQL Server Object Explorer enables you to do light-duty database administration and design work. Work examples include editing table data, comparing schemas, executing queries by using contextual menus right from SQL Server Object Explorer, and more.

> Tip: Use **SSMS** (SQL-Management Studio for larger task)

[SSMS](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017) is an integrated environment for managing any SQL infrastructure, from SQL Server to Azure SQL Database. SSMS provides tools to configure, monitor, and administer instances of SQL. Use SSMS to deploy, monitor, and upgrade the data-tier components used by your applications, as well as build queries and scripts.

Use SQL Server Management Studio (SSMS) to query, design, and manage your databases and data warehouses, wherever they are - on your local computer, or in the cloud.

SSMS is free!

---
[Back to main page](https://github.com/karenpayneoregon/VisualStudioEducation).
  