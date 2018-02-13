using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Queries.GetEmployees
{
    public interface IGetEmployeesQuery
    {
        Task<List<GetEmployeesModel>> ExecuteAsync();
    }
}
