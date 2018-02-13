using Calidda.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Queries.ExistEmployee
{
    public class ExistEmployeeQuery : IExistEmployeeQuery
    {
        public readonly IDatabaseService _databaseService;

        public ExistEmployeeQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<Boolean> ExecuteAsync(int Id)
        {
            return await _databaseService.Employees.AnyAsync(s => s.Id == Id);
        }
    }
}
