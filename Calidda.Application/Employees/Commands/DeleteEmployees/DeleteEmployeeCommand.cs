using Calidda.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.DeleteEmployees
{
    public class DeleteEmployeeCommand : IDeleteEmployeeCommand
    {
        private readonly IDatabaseService _databaseService;

        public DeleteEmployeeCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task ExecuteAsync(int Id)
        {
            var _employee = await _databaseService.Employees.FirstOrDefaultAsync(s=>s.Id == Id);

            _databaseService.Employees.Remove(_employee);
            await _databaseService.SaveAsync();
        }
    }
}
