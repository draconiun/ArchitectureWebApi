using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.UpdateEmployees
{
    public interface IUpdateEmployeeCommand
    {
        Task<Employee> ExecuteAsync(int Id, UpdateEmployeeModel model);
    }
}
