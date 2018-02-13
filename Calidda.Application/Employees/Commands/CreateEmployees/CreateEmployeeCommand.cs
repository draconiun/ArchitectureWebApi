using Calidda.Application.Employees.Commands.CreateEmployees.Factory;
using Calidda.Application.Interfaces;
using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.CreateEmployees
{
    public class CreateEmployeeCommand : ICreateEmployeeCommand
    {
        public readonly IDatabaseService _databaseService;
        public readonly ICreateEmployeeFactory _createEmployeeFactory;

        public CreateEmployeeCommand(IDatabaseService databaseService,
                                    ICreateEmployeeFactory createEmployeeFactory)
        {
            _databaseService = databaseService;
            _createEmployeeFactory = createEmployeeFactory;
        }

        public async Task<Employee> ExecuteAsync(CreateEmployeeModel model)
        {
            var employee = _createEmployeeFactory.Create(model);

            _databaseService.Employees.Add(employee);
            await _databaseService.SaveAsync();

            return employee;
        }
    }
}
