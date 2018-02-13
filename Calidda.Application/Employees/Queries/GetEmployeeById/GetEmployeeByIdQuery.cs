using Calidda.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IGetEmployeeByIdQuery
    {
        public readonly IDatabaseService _databaseService;

        public GetEmployeeByIdQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<GetEmployeeByIdModel> ExecuteAsync(int Id)
        {

            var employee = await _databaseService.Employees.FirstOrDefaultAsync(s=>s.Id == Id);

            var returnEmployee = new GetEmployeeByIdModel();

            returnEmployee.Id = employee.Id;
            returnEmployee.Name = employee.Name;
            returnEmployee.FirstName = employee.FirstName;
            returnEmployee.Age = employee.Age;

            return returnEmployee;
        }
    }
}
