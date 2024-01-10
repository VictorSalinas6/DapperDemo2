using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo2
{
    public class EmployeeDepo : IEmployeeRepo
    {
        private readonly IDbConnection _connection;

        public EmployeeDepo(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _connection.Query<Employee>("SELECT * FROM employees;");
        }

        public void InsertEmployee(string newName)
        {
             _connection.Query<Employee>("INSERT INTO employees(FirstName) VALUES (@employeeName);",
                 new { employeeName = newName });

            //("INSERT INTO employees(FirstName) VALUES (@newName);", new { newName });
        }
    }
}
