## Book Inventory Project Setup

To run the Book Inventory project, follow these steps:

1. Clone the project repository to your local machine.
    
    bashCopy code
    
    `git clone <repository-url>`
    
2. Open the solution file (`BookInventory.sln`) in Visual Studio.
    
3. Build the solution to restore NuGet packages and compile the project.
    
4. Set up the database:
    
    - Locate the `BookInventory.LocalDatabaseSeeder` project in the solution explorer.
    - Right-click on the project and select "Set as StartUp Project".
    - Run the project to execute the database seeder.
        - This project will set up the database, run any necessary migrations, and seed some initial data.
5. Once the database setup is complete, you can run the main project: