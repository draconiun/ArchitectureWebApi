using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.CreateEmployees.Factory
{
    public interface ICreateEmployeeFactory
    {
        Employee Create(CreateEmployeeModel modelCreate);
    }
}
