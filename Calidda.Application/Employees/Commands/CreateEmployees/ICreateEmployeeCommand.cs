using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.CreateEmployees
{
    public interface ICreateEmployeeCommand
    {
        Task<Employee> ExecuteAsync(CreateEmployeeModel model);
    }
}
