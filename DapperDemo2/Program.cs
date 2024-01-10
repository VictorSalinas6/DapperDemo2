using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DapperDemo2;
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