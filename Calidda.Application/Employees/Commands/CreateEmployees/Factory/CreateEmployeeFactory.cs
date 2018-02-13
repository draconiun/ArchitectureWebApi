using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.CreateEmployees.Factory
{
    public class CreateEmployeeFactory : ICreateEmployeeFactory
    {
        public Employee Create(CreateEmployeeModel modelCreate)
        {
            var model = new Employee();
            model.Name = modelCreate.Name;
            model.FirstName = modelCreate.FirstName;
            model.Age = modelCreate.Age;

            return model;
        }
    }
}
