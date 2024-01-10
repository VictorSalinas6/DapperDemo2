using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo2
{
    public interface IEmployeeRepo
    {
        public IEnumerable<Employee> GetAllEmployees();

        public void InsertEmployee(string newName);
    }
}
