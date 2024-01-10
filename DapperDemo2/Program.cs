using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DapperDemo2;
using Org.BouncyCastle.Utilities;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

//Console.WriteLine(connString);


var repo = new EmployeeDepo(conn);

var employees = repo.GetAllEmployees();

foreach (var employee in employees)
{
    Console.WriteLine($"{employee.EmployeeID} | {employee.FirstName} {employee.LastName} | {employee.EmailAddress} | {employee.DateOfBirth}");
}

Console.WriteLine();

var pRepo = new ProductDepo(conn);

var products = pRepo.GetAllProducts();
int longestName = 0;

foreach (var product in products)
{
    if (product.Name.Length > longestName)
        longestName = product.Name.Length;
}

//Creating a new product
//pRepo.InsertProduct("New Product", 98.00, 1);

//Updating a product
//pRepo.UpdateProduct(945, "Updated Product", 100.50, 2);

//Deleting a product
//pRepo.DeleteProduct(945);

products = pRepo.GetAllProducts();

Console.WriteLine($"{"ID".PadRight(3)} | {"Name".PadRight(longestName)} | Price\t| Category ID");
Console.WriteLine();
foreach (var product in products)
{
    Console.WriteLine( $"{product.ProductID.ToString().PadRight(3)} | {product.Name.PadRight(longestName)} | {product.Price}\t| {product.CategoryID}");
}
