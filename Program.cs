using CodingTracker.Crud;
using CodingTracker.Model;
using CodingTracker.Console;

DbOperations operations = new DbOperations();

ConsoleOperations console = new ConsoleOperations(operations);
console.GetMainInput();






