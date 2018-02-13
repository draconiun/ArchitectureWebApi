using Calidda.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Queries.GetEmployees
{
    public class GetEmployeesQuery : IGetEmployeesQuery
    {
        public readonly IDatabaseService _databaseService;

        public GetEmployeesQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<GetEmployeesModel>> ExecuteAsync()
        {

            var employees = await _databaseService.Employees.ToListAsync();

            var returnEmployees = new List<GetEmployeesModel>();

            foreach (var oneEmployee in employees)
            {
                GetEmployeesModel oGetEmployeesModel = new GetEmployeesModel();

                oGetEmployeesModel.Id = oneEmployee.Id;
                oGetEmployeesModel.Name = oneEmployee.Name;
                oGetEmployeesModel.FirstName = oneEmployee.FirstName;
                oGetEmployeesModel.Age = oneEmployee.Age;

                returnEmployees.Add(oGetEmployeesModel);
            }

            return returnEmployees;
        }
    }
}
