using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.UpdateEmployees.Factory
{
    public interface IUpdateEmployeeFactory
    {
        Employee Create(Employee model, UpdateEmployeeModel modelUpdate);
    }
}
