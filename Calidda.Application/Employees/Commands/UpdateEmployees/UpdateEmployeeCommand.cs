using Calidda.Application.Employees.Commands.UpdateEmployees.Factory;
using Calidda.Application.Interfaces;
using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.UpdateEmployees
{
    public class UpdateEmployeeCommand : IUpdateEmployeeCommand
    {
        public readonly IDatabaseService _databaseService;
        public readonly IUpdateEmployeeFactory _updateEmployeeFactory;

        public UpdateEmployeeCommand(IDatabaseService databaseService,
                                    IUpdateEmployeeFactory updateEmployeeFactory)
        {
            _databaseService = databaseService;
            _updateEmployeeFactory = updateEmployeeFactory;
        }

        public async Task<Employee> ExecuteAsync(int Id,UpdateEmployeeModel model)
        {

            var employee = await _databaseService.Employees.FirstOrDefaultAsync(x=>x.Id == Id);

            var employeeUpdate = _updateEmployeeFactory.Create(employee,model);

            _databaseService.Update(employee);

            await _databaseService.SaveAsync();

            return employee;
        }
    }
}
