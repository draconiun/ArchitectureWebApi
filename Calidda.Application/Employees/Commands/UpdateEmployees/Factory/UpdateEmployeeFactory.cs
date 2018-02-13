using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.UpdateEmployees.Factory
{
    public class UpdateEmployeeFactory : IUpdateEmployeeFactory
    {
        public Employee Create(Employee model, UpdateEmployeeModel modelUpdate)
        {
            model.Name = modelUpdate.Name;
            model.FirstName = modelUpdate.FirstName;
            model.Age = modelUpdate.Age;

            return model;
        }
    }
}
